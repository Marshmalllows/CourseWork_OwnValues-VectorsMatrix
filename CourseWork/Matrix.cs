namespace CourseWork
{
    public class Matrix
    {
        public double[][] MatrixData { get; }

        public int Length { get; }

        public Matrix(int size)
        {
            MatrixData = new double[size][];
            Length = size;
            for (var i = 0; i < size; i++)
            {
                MatrixData[i] = new double[size];
            }

            for (var i = 0; i < MatrixData.Length; i++)
            {
                for (var j = 0; j < MatrixData.Length; j++)
                {
                    MatrixData[i][j] = 0;
                }
            }
        }
        
        public Matrix(double[][] value)
        {
            MatrixData = new double[value.Length][];
            Length = value.Length;
            for (var i = 0; i < value.Length; i++)
            {
                MatrixData[i] = new double[value.Length];
            }

            for (var i = 0; i < MatrixData.Length; i++)
            {
                for (var j = 0; j < MatrixData.Length; j++)
                {
                    MatrixData[i][j] = value[i][j];
                }
            }
        }

        public double[] MultiplicationVector(double[] vector)
        {
            var result = new double[Length];
            for (var i = 0; i < Length; i++)
            {
                result[i] = 0;
            }

            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    Gui.Difficulty++;
                    result[i] += MatrixData[i][j] * vector[j];
                }
            }

            return result;
        }
        
        public Matrix MultiplicationMatrix(Matrix matrix2)
        {
            var matrixData = new double[Length][];

            for (var i = 0; i < Length; i++)
            {
                matrixData[i] = new double[matrix2.MatrixData[0].Length];
                for (var j = 0; j < matrix2.MatrixData[0].Length; j++)
                {
                    matrixData[i][j] = 0;
                }
            }

            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < matrix2.MatrixData[0].Length; j++)
                {
                    for (var k = 0; k < MatrixData[0].Length; k++)
                    {
                        Gui.Difficulty++;
                        matrixData[i][j] += MatrixData[i][k] * matrix2.MatrixData[k][j];
                    }
                }
            }

            return new Matrix(matrixData);
        }

        public Matrix MultiplicationValue(double value)
        {
            var matrixCopy = new double[Length][];
            for (var i = 0; i < Length; i++)
            {
                matrixCopy[i] = new double[Length];
            }
            
            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    Gui.Difficulty++;
                    matrixCopy[i][j] = MatrixData[i][j] * value;
                }
            }

            return new Matrix(matrixCopy);
        }
        
        public Matrix SubtractionMatrix(Matrix matrix)
        {
            var matrixCopy = new double[Length][];
            for (var i = 0; i < Length; i++)
            {
                matrixCopy[i] = new double[Length];
            }
            
            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    Gui.Difficulty++;
                    matrixCopy[i][j] = MatrixData[i][j] - matrix.MatrixData[i][j];
                }
            }

            return new Matrix(matrixCopy);
        }
        
        public static double[] GaussSlaeMethod(double[][] matrix, double[] subMatrix, int size)
        {
            var results = new double[size];
            
            if (matrix[0][0] == 0)
            {
                for (var i = 1; i < size; i++)
                {
                    if (matrix[i][0] == 0)
                    {
                        continue;
                    }

                    var temp1 = subMatrix[0];
                    subMatrix[0] = subMatrix[i];
                    subMatrix[i] = temp1;

                    for (var j = 0; j < size; j++)
                    {
                        var temp2 = matrix[0][j];
                        matrix[0][j] = matrix[i][j];
                        matrix[i][j] = temp2;
                    }
                    break;
                }
            }

            for (var i = 0; i < size; i++)
            {
                var diagonalElement = matrix[i][i];
                subMatrix[i] /= diagonalElement;

                for (var k = i; k < size; k++)
                {
                    matrix[i][k] /= diagonalElement;
                }

                if (i == size - 1)
                {
                    continue;
                }

                for (var j = i + 1; j < size; j++)
                {
                    var difference = -matrix[j][i] / matrix[i][i];
                    subMatrix[j] += subMatrix[i] * difference;

                    for (var k = 0; k < size; k++)
                    {
                        matrix[j][k] += matrix[i][k] * difference;
                    }
                }
            }

            for (var i = size - 1; i >= 0; i--)
            {
                for (var j = size - 1; j > i; j--)
                {
                    subMatrix[i] -= matrix[i][j] * results[j];
                }

                results[i] = subMatrix[i] / matrix[i][i];
            }

            return results;
        }
    }
}