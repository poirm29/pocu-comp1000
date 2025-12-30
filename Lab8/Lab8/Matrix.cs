using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab8
{
    public static class Matrix
    {
        public static int DotProduct(int[] v1, int[] v2)
        {
            int dot = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                int sumOfEachElement = v1[i] * v2[i];
                dot += sumOfEachElement;
            }
            return dot;
        }

        public static int[,] Transpose(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);

            int[,] transposedMatrix = new int[column, row];

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    transposedMatrix[i, j] = matrix[j, i];
                }
            }
            return transposedMatrix;
        }

        public static int[,] GetIdentityMatrix(int size)
        {
            int[,] identityMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                identityMatrix[i, i] = 1;
            }

            return identityMatrix;
        }

        public static int[] GetRowOrNull(int[,] matrix, int row)
        {
            int[] rowArray = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                rowArray[i] = matrix[row, i];
            }

            return rowArray;
        }

        public static int[] GetColumnOrNull(int[,] matrix, int col)
        {
            int[] columnArray = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                columnArray[i] = matrix[i, col];
            }

            return columnArray;
        }

        public static int[] MultiplyMatrixVectorOrNull(int[,] matrix, int[] vector)
        {
            if (matrix.GetLength(1) != vector.Length)
            {
                return null;
            }
            else
            {
                int[] product = new int[matrix.GetLength(0)];
                
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int eachProduct = 0;
                    
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        eachProduct += vector[j] * matrix[i, j];
                    }

                    product[i] = eachProduct;
                }

                return product;
            }
        }

        public static int[] MultiplyVectorMatrixOrNull(int[] vector, int[,] matrix)
        {
            if (vector.Length != matrix.GetLength(0))
            {
                return null;
            }
            else
            {
                int[] product = new int[matrix.GetLength(1)];

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    int eachProduct = 0;

                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        eachProduct += vector[j] * matrix[j, i];
                    }

                    product[i] = eachProduct;
                }

                return product;
            };
        }

        public static int[,] MultiplyOrNull(int[,] multiplicandMatrix, int[,] multiplierMatrix)
        {
            if (multiplicandMatrix.GetLength(1) != multiplierMatrix.GetLength(0))
            {
                return null;
            }
            else
            {
                int[,] product = new int[multiplicandMatrix.GetLength(0), multiplierMatrix.GetLength(1)];
                int[] eachRowProduct = new int[multiplierMatrix.GetLength(1)];

                for (int i = 0; i < multiplicandMatrix.GetLength(0); i++)
                {
                    int[] featureVector = new int[multiplicandMatrix.GetLength(1)];
                    for (int j = 0; j < multiplicandMatrix.GetLength(1); j++)
                    {
                        featureVector[j] = multiplicandMatrix[i, j];
                    }

                    eachRowProduct = MultiplyVectorMatrixOrNull(featureVector, multiplierMatrix);

                    for (int j = 0; j < eachRowProduct.Length; j++)
                    {
                        product[i, j] = eachRowProduct[j];
                    }
                }

                return product;
            }
        }
    }
}
