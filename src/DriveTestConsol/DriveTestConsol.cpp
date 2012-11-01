// DriveTestConsol.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include "../shared/Util.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	//CAMHSDrive amhsDev;
	//amhsDev.Init();
	////amhsDev.SetOHTLocation( 200);
	//amhsDev.OHTStatusBackTime(254, 150);


	//getchar();
	//amhsDev.Clean();

	string strVal = "<12,34><34,45><23,77><34,56,78,90,98><33,44,55,66>";

	STR_VEC list = GetVecStrings(strVal);
	for (STR_VEC::iterator it = list.begin();
		it != list.end(); ++it)
	{
		cout << it->c_str() << endl;
		STR_VEC ln = SplitString(*it, ",");
		for (STR_VEC::iterator nit = ln.begin();
			nit != ln.end(); ++ nit)
		{
			cout << nit->c_str() << endl;
		}
	}
	
	getchar();

	return 0;
}
//
//#include <boost/regex.hpp>
//#include <iostream>
//#include <string>
//
//void print_captures(const std::string& regx, const std::string& text)
//{
//	boost::regex e(regx);
//	boost::smatch mathc_what;
//	std::cout << "Expression: \"" << regx << "\"\n";
//	std::cout << "Text: \"" << text << "\"\n";
//	if(boost::regex_match(text, mathc_what, e, boost::match_extra))
//	{
//		unsigned i, j = 0;
//		std::cout << "** Match found **\n Sub-Expressions:\n";
//		for(i = 0; i < mathc_what.size(); ++i)
//			std::cout << " $" << i << " = \"" << mathc_what[i] << "\"\n";
//		std::cout << " Captures:\n";
//		for(i = 0; i < mathc_what.size(); ++i)
//		{
//			std::cout << " $" << i << " = {";
//			//for(j = 0; j < what.captures(i).size(); ++j)
//			{
//				if(j)
//					std::cout << ", ";
//				else
//					std::cout << " ";
//				std::cout << "\"" << mathc_what.captures(i)[j] << "\"";
//				//mathc_what.match_results();
//			}
//			std::cout << " }\n";
//		}
//	}
//	else
//	{
//		std::cout << "** No Match found **\n";
//	}
//}
//int main(int , char* [])
//{
//	print_captures("(([[:lower:]]+)|([[:upper:]]+))+", "aBBcccDDDDDeeeeeeee");
//	print_captures("(.*)bar|(.*)bah", "abcbar");
//	print_captures("(.*)bar|(.*)bah", "abcbah");
//	print_captures("^(?:(\\w+)|(?>\\W+))*$",
//		"now is the time for all good men to come to the aid of the party");
//
//	getchar();
//
//	return 0;
//}



//#include <iostream>
//#include <boost/regex.hpp>
//
//using namespace std;
//int main(int argc, char* argv[])
//{    //( 1 )   ((  3  )  2 )((  5 )4)(    6    )   
//	//(/w+)://((/w+/.)*/w+)((//w*)*)(//w+/./w+)?
//	//^协议://网址(x.x...x)/路径(n个/字串)/网页文件(xxx.xxx)
//	const char *szReg = ".*?(<[123].*?>).*?";
//	const char *szStr = "<12, 34><23,45>";
//
//	{    //字符串匹配
//		boost::regex reg( szReg );
//		bool r=boost::regex_match( szStr , reg);
//		//assert(r);
//	}
//
//	{    //提取子串
//		boost::cmatch mat;
//		boost::regex reg( szReg );
//		bool r=boost::regex_match( szStr, mat, reg);
//		if(r) //如果匹配成功
//		{
//			//显示所有子串
//			for(boost::cmatch::iterator itr=mat.begin(); itr!=mat.end(); ++itr)
//			{
//				//       指向子串对应首位置        指向子串对应尾位置          子串内容
//				cout << itr->first-szStr << ' ' << itr->second-szStr << ' ' << *itr << endl;
//			}
//		}
//		//也可直接取指定位置信息
//		if(mat[4].matched) cout << "Path is" << mat[4] << endl;
//	}
//
//	{ //查找
//		boost::cmatch mat;
//		boost::regex reg( "<.*?>" );    //查找字符串里的数字
//		if(boost::regex_search(szStr, mat, reg))
//		{
//			cout << "searched:" << mat[0] << endl;
//			for(boost::cmatch::iterator itr=mat.begin(); itr!=mat.end(); ++itr)
//			{
//				//       指向子串对应首位置        指向子串对应尾位置          子串内容
//				cout << itr->first-szStr << ' ' << itr->second-szStr << ' ' << *itr << endl;
//			}
//		}
//	}
//
//	{ //替换
//		boost::regex reg( szReg );
//		string s = boost::regex_replace( string(szStr), reg, "ftp://$2$5");
//		cout << "ftp site:"<< s << endl;
//	}
//	{ //替换2，把<>&转换成网页字符
//		string s1 = "(<)|(>)|(&)";
//		string s2 = "(?1&lt;)(?2&gt;)(?3&amp;)";
//		boost::regex reg( s1 );
//		string s = boost::regex_replace( string("cout << a&b << endl;"), reg, s2, boost::match_default | boost::format_all);
//		cout << "HTML:"<< s << endl;
//	}
//
//	{ //使用迭代器找出所有数字
//		boost::regex reg( "//d+" );    //查找字符串里的数字
//		boost::cregex_iterator itrBegin = make_regex_iterator(szStr,reg); //(szStr, szStr+strlen(szStr), reg);
//		boost::cregex_iterator itrEnd;
//		for(boost::cregex_iterator itr=itrBegin; itr!=itrEnd; ++itr)
//		{
//			//       指向子串对应首位置        指向子串对应尾位置          子串内容
//			cout << (*itr)[0].first-szStr << ' ' << (*itr)[0].second-szStr << ' ' << *itr << endl;
//		}
//	}
//
//	{ //使用迭代器拆分字符串
//		boost::regex reg("/");  //按/符拆分字符串
//		boost::cregex_token_iterator itrBegin = make_regex_token_iterator(szStr,reg,-1); //使用-1参数时拆分，使用其它数字时表示取第几个子串，可使用数组取多个串
//		boost::cregex_token_iterator itrEnd;
//		for(boost::cregex_token_iterator itr=itrBegin; itr!=itrEnd; ++itr)
//		{
//			cout << *itr << endl;
//		}
//	}
//
//	{ //使用迭代器拆分字符串2
//		boost::regex reg("(.)/(.)");  //取/的前一字符和后一字符（这个字符串形象貌似有点邪恶-_-）
//		int subs[] = {1,2};        // 第一子串和第二子串
//		boost::cregex_token_iterator itrBegin = make_regex_token_iterator(szStr,reg,subs); //使用-1参数时拆分，使用其它数字时表示取第几个子串，可使用数组取多个串
//		boost::cregex_token_iterator itrEnd;
//		for(boost::cregex_token_iterator itr=itrBegin; itr!=itrEnd; ++itr)
//		{
//			cout << *itr << endl;
//		}
//	}
//
//
//	cin.get();
//	return 0;
//}
//
