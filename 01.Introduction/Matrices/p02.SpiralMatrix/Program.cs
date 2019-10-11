namespace p02.SpiralMatrix
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = 5;
            var matrix = new int[input, input];

            SpiralFill(matrix, input);
            PrintMatrix(matrix);
        }

        public static void SpiralFill(int[,] matrix, int rowColLength)
        {
            int currentRowColLength = rowColLength;
            var startRow = 0;
            var startCol = 0;
            var number = 0;
            while (startRow < currentRowColLength)
            {
                for (int row = startRow; row < currentRowColLength; row++)
                {
                    if (matrix[row, startCol] == default(int))
                    {
                        matrix[row, startCol] = ++number;
                    }
                }

                for (int col = startCol; col < currentRowColLength; col++)
                {
                    if (matrix[currentRowColLength - 1, col] == default(int))
                    {
                        matrix[currentRowColLength - 1, col] = ++number;
                    }
                }

                for (int row = currentRowColLength - 1; row >= 0; row--)
                {
                    if (matrix[row, currentRowColLength - 1] == default(int))
                    {
                        matrix[row, currentRowColLength - 1] = ++number;
                    }
                }

                for (int col = currentRowColLength - 1; col >= 0; col--)
                {
                    if (matrix[startRow, col] == default(int))
                    {
                        matrix[startRow, col] = ++number;
                    }
                }

                startCol++;
                startRow++;
                currentRowColLength--;
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
