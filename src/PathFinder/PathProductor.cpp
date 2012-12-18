#include "StdAfx.h"
#include "PathProductor.h"

initialiseSingleton(CPathProductor);
CPathProductor::CPathProductor(void)
{
	sLog.outBasic("Path Productor is Started.");
}


CPathProductor::~CPathProductor(void)
{
}


void CPathProductor::GetLaneData(void)
{
	DBLane dbLane;
	auto vecLane = dbLane.GetLaneTable(1);

	for (auto it = vecLane.cbegin();
		it != vecLane.cend(); ++it)
	{
		printf("Lane: %d, s: %d e: %d, p: %d n: %d, f: %d, t: %d, l: %d\r\n",
			it->nID, it->nStart, it->nEnd, it->nPrevLane, it->nNextLane, it->nNextFork, it->nType, 
			it->nLength);
	}
}


void CPathProductor::InitGraph(void)
{
	const int N = 14;
	int nBarCodeBegin = 100;
	int nBarCodeEnd = 1000;

	for (int i=0; i<N; i++)
	{
		m_arrayBarCode.push_back(nBarCodeBegin);
		nBarCodeBegin += 100;

		location loc;
		loc.x = nBarCodeBegin;
		loc.y = 10;
		m_arrayLocation.push_back(loc);

		if (i<N-1)
		{
			m_arrayEdge.push_back(lane_edge(i, i+1));
			m_arrayWeights.push_back(nBarCodeBegin);
		}
	}

	m_arrayEdge.push_back(lane_edge(13, 0));
	m_arrayWeights.push_back(0);
}

vec_int CPathProductor::ProductPath(int nFrom, int nTo)
{ 
	m_nFrom = nFrom;
	m_nTo = nTo;
	
	InitGraph();
	
	if (AStarFind() > 0)
	{
		return m_arrayPath;
	}
	return vec_int();
}


int CPathProductor::AStarFind(void)
{
	m_arrayPath.clear();

	size_t num_edges =m_arrayEdge.size();

	if (num_edges <= 0)
	{
		return 0;
	}

	size_t szCount = m_arrayBarCode.size() + 1;
	
	// create graph
	mygraph_t g(szCount);
	WeightMap weightmap = get(edge_weight, g);
	for(std::size_t j = 0; j < num_edges; ++j)
	{
		edge_descriptor e; 
		bool inserted;
		boost::tie(e, inserted) = add_edge(m_arrayEdge[j].first,
			m_arrayEdge[j].second, g);
		weightmap[e] = m_arrayWeights[j];
	}

	// from will be the first element
	int nIndexFrom = 0;
	for (auto it = m_arrayBarCode.cbegin();
		it != m_arrayBarCode.cend(); ++it, ++nIndexFrom)
	{
		if (*it == m_nFrom)
		{
			nIndexFrom;
			break;
		}
	}

	// to will be the last element
	int nIndexTo = m_arrayBarCode.size();
	for (auto it = m_arrayBarCode.crbegin();
		it != m_arrayBarCode.crend(); ++it, --nIndexTo)
	{
		if (*it == m_nTo)
		{
			--nIndexTo;
			break;
		}
	}

	lane_vertex start = nIndexFrom;
	lane_vertex goal = nIndexTo;


	cout << "Start vertex: " << m_arrayBarCode[start] << endl;
	cout << "Goal vertex: " << m_arrayBarCode[goal] << endl;

	vector<mygraph_t::vertex_descriptor> p(num_vertices(g));
	vector<cost> d(num_vertices(g));
	try 
	{
		// call astar named parameter interface
		astar_search
			(g, start,
			distance_heuristic<mygraph_t, cost, vec_location >
			(m_arrayLocation, goal),
			predecessor_map(&p[0]).distance_map(&d[0]).
			visitor(astar_goal_visitor<lane_vertex>(goal)));
	} 
	catch(found_goal /*fg*/) 
	{ 
		// found a path to the goal
		list<lane_vertex> shortest_path;
		for(auto v = goal;; v = p[v]) 
		{
			shortest_path.push_front(v);
			if(p[v] == v)
				break;
		}

		int nBCStart = m_arrayBarCode[start];
		int nBCGoal = m_arrayBarCode[goal];
		cout << "Shortest path from " << nBCStart << " to "
			<< nBCGoal << ": ";
		auto spi = shortest_path.begin();
		
		cout << nBCStart;
		m_arrayPath.push_back(nBCStart);
		for(++spi; spi != shortest_path.end(); ++spi)
		{
			int nBarCode = m_arrayBarCode[*spi];
			cout << " -> " << nBarCode;
		}
		m_arrayPath.push_back(nBCGoal);
		
		//getchar();
		int nTotalTravel = (int)d[goal];
		cout << endl << "Total travel time: " << nTotalTravel << endl;
		return nTotalTravel;
	}


	return 0;
}
