#include "Errors.h"
#include "Common.h"

extern void arcAssertFailed(const char* fname, int line, const char* expr)
{
	printf("Assertion Failed: (%s)\n", expr);
	printf("Location: %s(%i)\n", fname, line);
	//printf( "Expression: %s\n", expr );
//#if defined(WIN32) && defined(_DEBUG)
	//printf("Stack trace:\n");
	//printStackTrace();
//#endif
}