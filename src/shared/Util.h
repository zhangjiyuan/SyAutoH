#pragma once

#include <string>
#include <vector>

typedef std::vector<std::string> STR_VEC;

STR_VEC GetVecStrings(const std::string& input);
STR_VEC SplitString(const std::string& input, const std::string& split);
