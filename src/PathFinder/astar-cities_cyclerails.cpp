

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
#include "boost/graph/astar_search.hpp"
#include <boost/graph/adjacency_list.hpp>
#include <boost/graph/random.hpp>
#include <boost/random.hpp>
#include <boost/graph/graphviz.hpp>
//#include <sys/time.h>
#include <vector>
#include <list>
#include <iostream>
#include <fstream>
#include <math.h>    // for sqrt

using namespace boost;
using namespace std;


// auxiliary types
struct location
{
  float y, x; // lat, long
};
typedef float cost;

template <class Name, class LocMap>
class city_writer 
{
public:
  city_writer(Name n, LocMap l, float _minx, float _maxx,
              float _miny, float _maxy,
              unsigned int _ptx, unsigned int _pty)
    : name(n), loc(l), minx(_minx), maxx(_maxx), miny(_miny),
      maxy(_maxy), ptx(_ptx), pty(_pty) {}
  template <class Vertex>
  void operator()(ostream& out, const Vertex& v) const {
    float px =  (loc[v].x - minx) / (maxx - minx);
    float py = (loc[v].y - miny) / (maxy - miny);
    out << "[label=\"" << name[v] << "\", pos=\""
        << static_cast<unsigned int>(ptx * px) << ","
        << static_cast<unsigned int>(pty * py)
        << "\", fontsize=\"11\"]";
  }
private:
  Name name;
  LocMap loc;
  float minx, maxx, miny, maxy;
  unsigned int ptx, pty;
};

template <class WeightMap>
class time_writer {
public:
  time_writer(WeightMap w) : wm(w) {}
  template <class Edge>
  void operator()(ostream &out, const Edge& e) const {
    out << "[label=\"" << wm[e] << "\", fontsize=\"11\"]";
  }
private:
  WeightMap wm;
};


// euclidean distance heuristic
template <class Graph, class CostType, class LocMap>
class distance_heuristic : public astar_heuristic<Graph, CostType>
{
public:
  typedef typename graph_traits<Graph>::vertex_descriptor Vertex;
  distance_heuristic(LocMap l, Vertex goal)
    : m_location(l), m_goal(goal) {}
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

int _tmain(int argc, _TCHAR* argv[])
//int main(int argc, char **argv)
{
  
  // specify some types
  typedef adjacency_list<listS, vecS, directedS, no_property,
    property<edge_weight_t, cost> > mygraph_t;
  typedef property_map<mygraph_t, edge_weight_t>::type WeightMap;
  typedef mygraph_t::vertex_descriptor vertex;
  typedef mygraph_t::edge_descriptor edge_descriptor;
  typedef mygraph_t::vertex_iterator vertex_iterator;
  typedef std::pair<int, int> edge;
  
  // specify data
  enum nodes 
  {
    A1, A2, A3, A4, A5, A6,
    A7, A8, A9, A10, A11, A12,
    A13, N
  };

  const char *name[] = 
  {
    "A1", "A2", "A3", "A4",
    "A5", "A6", "A7", "A8", "A9",
    "A10", "A11", "A12", "A13"
  };

  location locations[] = 
  { // lat/long  y/x
    {10.00, 10.0}, {10.00, 11.0}, {10.00, 12.0},
    {10.00, 13.0}, {10.00, 15.0}, {10.00, 16.0},
    {10.00, 17.0}, {10.00,18.0}, {10.00, 19.0},
    {10.00, 20.0}, {10.00, 21.0}, {10.00, 22.0},
    {10.00, 23.0}
  };

  edge edge_array[] = 
  {
    edge(A1,A2), edge(A2,A3),
    edge(A3,A4), edge(A4,A5),
    edge(A5,A6), edge(A6,A7),
    edge(A7,A8), edge(A8,A9),
    edge(A9,A10), edge(A10,A11),
    edge(A11,A12), edge(A12,A13),
    edge(A13,A1)
  };

  unsigned int num_edges = sizeof(edge_array) / sizeof(edge);
  cost weights[] = 
  { // estimated travel time (mins)
   10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
    10, 10, 10
  };
  
  
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
  
  
  // pick random start/goal
  mt19937 gen(time(0));
  vertex start = random_vertex(g, gen);
  vertex goal = random_vertex(g, gen);
  
  
  cout << "Start vertex: " << name[start] << endl;
  cout << "Goal vertex: " << name[goal] << endl;
  
  ofstream dotfile;
  dotfile.open("test-astar-cities.dot");
  write_graphviz(dotfile, g,
                 city_writer<const char **, location*>
                  (name, locations, 10.0, 24.0, 0.0, 20.0,
                   480, 200),
                 time_writer<WeightMap>(weightmap));
  
  
  vector<mygraph_t::vertex_descriptor> p(num_vertices(g));
  vector<cost> d(num_vertices(g));
  try 
  {
    // call astar named parameter interface
    astar_search
      (g, start,
       distance_heuristic<mygraph_t, cost, location*>
        (locations, goal),
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
    cout << "Shortest path from " << name[start] << " to "
         << name[goal] << ": ";
    list<vertex>::iterator spi = shortest_path.begin();
    cout << name[start];
    for(++spi; spi != shortest_path.end(); ++spi)
      cout << " -> " << name[*spi];
    cout << endl << "Total travel time: " << d[goal] << endl;
	getchar();
    return 0;
  }
  
  cout << "Didn't find a path from " << name[start] << "to"
       << name[goal] << "!" << endl;
  getchar();
  return 0;
  
}
