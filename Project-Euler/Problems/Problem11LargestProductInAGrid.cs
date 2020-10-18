using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 11
    /// </summary>
    public static class Problem11LargestProductInAGrid
    {
        private static readonly int[,] data;

        static Problem11LargestProductInAGrid()
        {
            data = new int[20, 20]
            {
                {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}
            };
        }

        #region Solution 1
        public static int GetMaxProduct1()
        {
            int result = 0;

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    int maxProduct = GetMaxProduct(CutMatrix(i, j));
                    if (maxProduct > result)
                    {
                        result = maxProduct;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a submatrix of 4x4 with a specific top left corner.
        /// </summary>
        /// <param name="startTop"> The first row in the wanted submatrix. </param>
        /// <param name="startLeft"> The first column in the wanted submatrix. </param>
        /// <returns> A matrix of 4x4 which has a top left
        /// corner (startTop, startLeft). </returns>
        private static int[,] CutMatrix(int startTop, int startLeft)
        {
            int[,] result = new int[4, 4];
            int currentLeft = startLeft;
            int currentTop = startTop;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = data[currentTop, currentLeft];
                    currentLeft++;
                }

                currentTop++;
                currentLeft = startLeft;
            }

            return result;
        }

        private static int GetMaxProduct(int[,] data)
        {
            int result = 0;

            for (int i = 0; i < 4; i++)
            {
                int rowProd = MultArray(GetRow(i));
                int columnProd = MultArray(GetColumn(i));

                if (rowProd > result)
                {
                    result = rowProd;
                }
                if (columnProd > result)
                {
                    result = columnProd;
                }
            }

            if (data[0, 0] * data[1, 1] * data[2, 2] * data[3, 3] > result)
            {
                result = data[0, 0] * data[1, 1] * data[2, 2] * data[3, 3];
            }
            if (data[0, 3] * data[1, 2] * data[2, 1] * data[3, 0] > result)
            {
                result = data[0, 3] * data[1, 2] * data[2, 1] * data[3, 0];
            }

            return result;

            int[] GetRow(int i)
            {
                int[] row = new int[4];
                for (int j = 0; j < 4; j++)
                    row[j] = data[i, j];

                return row;
            }
            int[] GetColumn(int i)
            {
                int[] column = new int[4];

                for (int j = 0; j < 4; j++)
                    column[j] = data[j, i];

                return column;
            }
            int MultArray(int[] array)
            {
                return array[0] * array[1] * array[2] * array[3];
            }
        }
        #endregion

        #region Solution 2
        public static int GetMaxProduct2()
        {
            int maxProduxt = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    int[] products = new int[4];

                    if (i < 17)
                    {
                        products[0] = MultDown(i, j);

                        if (j < 17)
                        {
                            products[1] = MultDiagonalDown(i, j);
                        }
                    }
                    if (j < 17)
                    {
                        products[2] = MultRight(i, j);

                        if (i > 2)
                        {
                            products[1] = MultDiagonalUp(i, j);
                        }
                    }

                    for (int k = 0; k < 4; k++)
                    {
                        if(maxProduxt < products[k])
                        {
                            maxProduxt = products[k];
                        }
                    }
                }
            }

            return maxProduxt;
        }

        private static int MultDown(int startRow, int startColumn)
        {
            int result = 1;

            for (int i = 0; i < 4; i++)
            {
                result *= data[startRow + i, startColumn];
            }

            return result;
        }
        private static int MultRight(int startRow, int startColumn)
        {
            int result = 1;

            for (int i = 0; i < 4; i++)
            {
                result *= data[startRow, startColumn + i];
            }

            return result;
        }
        private static int MultDiagonalDown(int startRow, int startColumn)
        {
            int result = 1;

            for (int i = 0; i < 4; i++)
            {
                result *= data[startRow + i, startColumn + i];
            }

            return result;
        }
        private static int MultDiagonalUp(int startRow, int startColumn)
        {
            int result = 1;

            for (int i = 0; i < 4; i++)
            {
                result *= data[startRow - i, startColumn + i];
            }

            return result;
        }
        #endregion
    }
}