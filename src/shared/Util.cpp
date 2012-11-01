#include "StdAfx.h"
#include "Util.h"

STR_VEC GetVecStrings(const std::string& input)
{
	STR_VEC strList;
	int nS = 0;
	int nE = 0;
	string strVal = input;
	nS = strVal.find_first_of("<");
	nE = strVal.find_first_of(">");
	while(nS >= 0)
	{
		string strFind = strVal.substr(nS+1, nE - nS - 1);
		strList.push_back(strFind);
		strVal = strVal.substr(nE+1, strVal.length() - nE -1);
		nS = strVal.find_first_of("<");
		nE = strVal.find_first_of(">");
	}

	return strList;
}

STR_VEC SplitString(const std::string& input, const std::string& split)
{
	STR_VEC strList;
	int nFind = 0;
	int nBegin = 0;
	nFind = input.find_first_of(split);
	while(nFind >= 0)
	{
		string strOne = input.substr(nBegin, nFind - nBegin);
		strList.push_back(strOne);
		nBegin = nFind + 1;
		nFind = input.find(split, nBegin);
	}
	if (nBegin > 0 && nBegin < input.length())
	{
		string strLast = input.substr(nBegin, input.length() - nBegin);
		strList.push_back(strLast);
	}


	return strList;
}