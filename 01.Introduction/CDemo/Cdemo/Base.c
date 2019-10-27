#include <stdio.h>

int main() 
{
	unsigned char test2;
	test2 = 22;
	unsigned long test;
	const char* numb = &test2;
	unsigned char base = 8;
	test = calculate(numb, base);
	return 0;
}

char getValue(char c) 
{
	char temp = (c >= 0 && c <= 9) ? c - '0' : c - 'A' + 10;
	return temp;
}

unsigned long calculate(const char* numb, unsigned char base) 
{
	unsigned long result;
	for (result = 0; '\0' != *numb; numb++)
	{
		result = result * base + getValue(*numb);
	}
	return result;
}
