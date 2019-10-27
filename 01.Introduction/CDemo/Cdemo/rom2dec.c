#include <stdio.h>
#include <string.h>
#define MAXN 50;

const char* roman1_9[] = {"", "A", "AA", "AAA", "AB", "B", "BA", "BAA", "BAAA", "AC"};
const char* romanDigits[] = { "IVX", "XLC", "CDM", "M" };

int main() 
{
	char rslt[50];
	unsigned number = 100;
	decimal2Roman(rslt, number);
	return 0;
}

void getRomanDigit(char* rslt, char x, unsigned char power) 
{
	const char* pch;
	for (pch = roman1_9[x]; '\0' != *pch; pch++)
	{
		*rslt++ = romanDigits[power][*pch - 'A'];
		*rslt = '\0';
	}
}

char* decimal2Roman(char* rslt, unsigned x) 
{
	unsigned char power;
	char buf[10];
	char oldRslt[200];
	for (*rslt = '\0', power = 0; x > 0; power++, x /= 10)
	{
		getRomanDigit(buf, (char)(x % 10), power);
		strcpy_s(oldRslt, rslt);
		strcpy_s(rslt, buf);
		strcat(rslt, oldRslt);
	}
	return rslt;
}