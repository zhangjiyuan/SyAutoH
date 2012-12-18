

//
//=======================================================================
// Copyright (c) 2004 Kristopher Beevers
//
// Distributed under the Boost Software License, Version 1.0. (See
// accompanying file LICENSE_1_0.txt or copy at
// http://www.boost.org/LICENSE_1_0.txt)
//=======================================================================
//

#include "stdafx.h"
#include <boost/graph/astar_search.hpp>
#include <boost/graph/adjacency_list.hpp>

#include <vector>
#include <list>
#include <math.h>    // for sqrt

using namespace boost;
using namespace std;

// auxiliary types
struct location
{
	float y, x; // lat, long
};
typedef float cost;

// euclidean distance heuristic
template <class Graph, class CostType, class LocMap>
class distance_heuristic : public astar_heuristic<Graph, CostType>
{
public:
	typedef typename graph_traits<Graph>::vertex_descriptor Vertex;
	distance_heuristic(LocMap l, Vertex goal)
		: m_location(l), m_goal(goal) 
	{
		//m_location = l;
	}
	CostType operator()(Vertex u)
	{
		CostType dx = m_location[m_goal].x - m_location[u].x;
		CostType dy = m_location[m_goal].y - m_location[u].y;
		return ::sqrt(dx * dx + dy * dy);
	}
private:
	LocMap m_location;
	Vertex m_goal;
};


struct found_goal {}; // exception for termination

// visitor that terminates when we find the goal
template <class Vertex>
class astar_goal_visitor : public boost::default_astar_visitor
{
public:
	astar_goal_visitor(Vertex goal) : m_goal(goal) {}
	template <class Graph>
	void examine_vertex(Vertex u, Graph& g) {
		if(u == m_goal)
			throw found_goal();
	}
private:
	Vertex m_goal;
};


int main(int argc, char **argv)
{
	// specify some types
	typedef adjacency_list<listS, vecS, directedS, no_property,
		property<edge_weight_t, cost> > mygraph_t;
	typedef property_map<mygraph_t, edge_weight_t>::type WeightMap;
	typedef mygraph_t::vertex_descriptor vertex;
	typedef mygraph_t::edge_descriptor edge_descriptor;
	typedef mygraph_t::vertex_iterator vertex_iterator;
	typedef std::pair<int, int> edge;

	//// specify data
	const int N = 14;
	vector<int> listBarCode;
	vector<location> listLocation;
	vector<edge> edge_array;
	vector<cost> weights;

	int nBarCodeBegin = 100;
	for (int i=0; i<N; i++)
	{
		listBarCode.push_back(nBarCodeBegin);
		nBarCodeBegin += 10;

		location loc;
		loc.x = nBarCodeBegin;
		loc.y = 10;
		listLocation.push_back(loc);

		if (i<N-1)
		{
			edge_array.push_back(edge(i, i+1));
			weights.push_back(nBarCodeBegin);
		}
	}

	edge_array.push_back(edge(13, 0));
	weights.push_back(0);

	unsigned int num_edges = edge_array.size();


	// create graph
	mygraph_t g(N);
	WeightMap weightmap = get(edge_weight, g);
	for(std::size_t j = 0; j < num_edges; ++j)
	{
		edge_descriptor e; 
		bool inserted;
		boost::tie(e, inserted) = add_edge(edge_array[j].first,
			edge_array[j].second, g);
		weightmap[e] = weights[j];
	}

	vertex start = 6;
	vertex goal = 5;


	cout << "Start vertex: " << listBarCode[start] << endl;
	cout << "Goal vertex: " << listBarCode[goal] << endl;

	vector<mygraph_t::vertex_descriptor> p(num_vertices(g));
	vector<cost> d(num_vertices(g));
	try 
	{
		// call astar named parameter interface
		astar_search
			(g, start,
			distance_heuristic<mygraph_t, cost, vector<location> >
			(listLocation, goal),
			predecessor_map(&p[0]).distance_map(&d[0]).
			visitor(astar_goal_visitor<vertex>(goal)));
	} 
	catch(found_goal fg) 
	{ 
		// found a path to the goal
		list<vertex> shortest_path;
		for(vertex v = goal;; v = p[v]) 
		{
			shortest_path.push_front(v);
			if(p[v] == v)
				break;
		}
		cout << "Shortest path from " << listBarCode[start] << " to "
			<< listBarCode[goal] << ": ";
		list<vertex>::iterator spi = shortest_path.begin();
		cout << listBarCode[start];
		for(++spi; spi != shortest_path.end(); ++spi)
			cout << " -> " << listBarCode[*spi];
		cout << endl << "Total travel time: " << d[goal] << endl;
		getchar();
		return 0;
	}

	cout << "Didn't find a path from " << listBarCode[start] << "to"
		<< listBarCode[goal] << "!" << endl;
	getchar();
	return 0;

}
