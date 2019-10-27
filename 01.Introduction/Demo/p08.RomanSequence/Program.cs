namespace p08.RomanSequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = "MDCL";
            //DCCCLXXXVIII 888
            //CMXCIX 999
            //CDXCIX 499
            //III
            //XXX
            //CCC
            //MMM
            //VIII

            //I < V < X < L < C < D < M

            // 1-9 -> I, V
            // 4-8 -> V

            // 10 - 90 -> X, L
            // 40 - 80 -> L

            // 100 - 900 -> C, D
            // 400 - 800 -> D

            bool isValid = true;
            var allowedLetterIndex = -1;

            var lettersAllowed = new char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
            if (input.Count(l => l == 'V') > 1 || input.Count(l => l == 'L') > 1 || input.Count(l => l == 'D') > 1)
            {
                isValid = false;
            }

            for (int i = 0, timesRepeated = 1; i < input.Length; i++)
            {
                if (!isValid) break;

                var currentChar = input[i];
                if (!lettersAllowed.Any(l => l == currentChar)) { isValid = false; break; }

                var currentCharIndex = Array.IndexOf(lettersAllowed, currentChar);

                if (currentCharIndex % 2 == 0)
                {
                    if (allowedLetterIndex < currentCharIndex)
                    {
                        if (i + 1 < input.Length)
                        {
                            var nextChar = input[i + 1];
                            var nextCharIndex = Array.IndexOf(lettersAllowed, nextChar);

                            if (0 < currentCharIndex - nextCharIndex && currentCharIndex - nextCharIndex <= 2) { i++; }
                        }

                        allowedLetterIndex = currentCharIndex;
                        timesRepeated = 1;
                    }
                    else if (allowedLetterIndex > currentCharIndex || Array.IndexOf(lettersAllowed, input[i - 1]) < allowedLetterIndex) { isValid = false; break; }
                    else timesRepeated++;

                    if (allowedLetterIndex == currentCharIndex && timesRepeated == 4) { isValid = false; break; } 
                }

                if (currentCharIndex % 2 == 1)
                {
                    if (allowedLetterIndex < currentCharIndex)
                    {
                        if (i + 1 < input.Length)
                        {
                            var nextChar = input[i + 1];
                            var nextCharIndex = Array.IndexOf(lettersAllowed, nextChar);

                            if (nextCharIndex <= currentCharIndex) { isValid = false; break; }
                        }

                        ;
                    }
                    else { isValid = false; break; }
                    //if (i + 1 >= input.Length) continue;

                    //if (nextCharIndex % 2 == 1) { isValid = false; break; }

                    //if (allowedLetterIndex < currentCharIndex && currentCharIndex < nextCharIndex) allowedLetterIndex = currentCharIndex;
                    //else { isValid = false; break; }
                }
            }

            Console.WriteLine("The Roman number equal to {0} is {1} number", input, isValid ? "valid" : "not valid");
        }
    }
}
