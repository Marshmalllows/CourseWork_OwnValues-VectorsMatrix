using System;

namespace CourseWork
{
    public class LeveryeFadeev
    {
        private static Matrix _matrix = Gui.Current;
        public static void LeveryeFadeev_Method()
        {
            _matrix = Gui.Current;
            Gui.Difficulty = 0;
                
            var trailCoefficients = new double[_matrix.Length];

            for (var i = 0; i < trailCoefficients.Length; i++)
            {
                trailCoefficients[i] = 0;
            }

            var extraMatrixArray = new Matrix[_matrix.Length];
            var ownMatrixArray = new Matrix[_matrix.Length];

            for (var i = 0; i < _matrix.Length; i++)
            {
                extraMatrixArray[i] = new Matrix(_matrix.Length);
                ownMatrixArray[i] = new Matrix(_matrix.Length);
            }

            for (var i = 0; i < _matrix.Length; i++)
            {
                extraMatrixArray[0].MatrixData[i][i] = 1;
                Gui.Difficulty++;
                for (var j = 0; j < _matrix.Length; j++)
                {
                    Gui.Difficulty++;
                    ownMatrixArray[0].MatrixData[i][j] = _matrix.MatrixData[i][j];
                }
            }

            for (var i = 0; i < _matrix.Length - 1; i++)
            {
                for (var j = 0; j < trailCoefficients.Length; j++)
                {
                    Gui.Difficulty++;
                    trailCoefficients[i] += ownMatrixArray[i].MatrixData[j][j];
                }
                
                Gui.Difficulty++;
                trailCoefficients[i] /= i + 1;

                extraMatrixArray[i + 1] = ownMatrixArray[i]
                    .SubtractionMatrix(extraMatrixArray[0].MultiplicationValue(trailCoefficients[i]));
                
                ownMatrixArray[i + 1] = _matrix.MultiplicationMatrix(extraMatrixArray[i + 1]);
            }
            
            for (var j = 0; j < trailCoefficients.Length; j++)
            {
                Gui.Difficulty++;
                trailCoefficients[_matrix.Length - 1] += ownMatrixArray[_matrix.Length - 1].MatrixData[j][j];
            }
            
            trailCoefficients[_matrix.Length - 1] /= _matrix.Length;
            Gui.Difficulty++;

            Gui.Difficulty++;
            var characteristicEquation = new Polynomial(_matrix.Length, trailCoefficients);
            var ownValues = new double[_matrix.Length];
            var valuesFound = 0;
            
            var minX = -500d;
            var maxX = 500d;

            var epsilon = 1e-9;
                
            var step = 0.1;
            for (var x = minX; x <= maxX; x += step)
            {
                var x1 = x;
                var x2 = x + step;
                var y1 = characteristicEquation.Function(x1);
                var y2 = characteristicEquation.Function(x2);
                
                if (Math.Sign(y1) != Math.Sign(y2))
                {
                    var root = characteristicEquation.BinarySearchRoot(x1, x2, epsilon);
                    ownValues[valuesFound] = root;
                    valuesFound++;
                }
            }

            var extraMatrixVectors = new double[_matrix.Length][];
            for (var i = 0; i < _matrix.Length; i++)
            {
                extraMatrixVectors[i] = new double[_matrix.Length];
            }

            for (var i = 0; i < extraMatrixVectors.Length; i++)
            {
                for (var j = 0; j < extraMatrixVectors.Length; j++)
                {
                    Gui.Difficulty++;
                    extraMatrixVectors[i][j] = extraMatrixArray[i].MatrixData[j][0];
                }
            }

            var ownVectors = new double[ownValues.Length][];
            for (var i = 0; i < ownValues.Length; i++)
            {
                ownVectors[i] = new double[_matrix.Length];
            }

            for (var i = 0; i < ownValues.Length; i++)
            {
                var ownYVectors = new double[ownValues.Length - 1][];
                for (var j = 0; j < ownYVectors.Length; j++)
                {
                    ownYVectors[j] = new double[_matrix.Length];
                }

                for (var j = 0; j < _matrix.Length; j++)
                {
                    Gui.Difficulty++;
                    ownYVectors[0][j] = ownValues[i] * extraMatrixVectors[0][j] + extraMatrixVectors[1][j];
                }

                for (var j = 1; j < ownYVectors.Length; j++)
                {
                    for (var k = 0; k < _matrix.Length; k++)
                    {
                        Gui.Difficulty++;
                        ownYVectors[j][k] = ownValues[i] * ownYVectors[j - 1][k] + extraMatrixVectors[j + 1][k];
                    }
                }

                for (var j = 0; j < ownYVectors[0].Length; j++)
                {
                    Gui.Difficulty++;
                    ownVectors[i][j] = ownYVectors[ownYVectors.Length - 1][j];
                }
            }

            foreach (var ownVector in ownVectors)
            {
                var length = 0d;
                
                for (var i = 0; i < ownVector.Length; i++)
                {
                    Gui.Difficulty++;
                    length += Math.Pow(ownVector[i], 2);
                }

                Gui.Difficulty++;
                length = Math.Sqrt(length);

                for (var i = 0; i < ownVector.Length; i++)
                {
                    Gui.Difficulty++;
                    ownVector[i] /= length;
                }
            }

            for (var i = 0; i < _matrix.Length; i++)
            {
                if (ownValues[i] == 0 && characteristicEquation.Function(ownValues[i]) != 0)
                {
                    Gui.OwnValuesLabels[i].Text = "---";
                }
                else
                {
                    Gui.OwnValuesLabels[i].Text = ownValues[i].ToString("F4");
                }
                
                for (var j = 0; j < _matrix.Length; j++)
                {
                    if (ownValues[i] == 0 && characteristicEquation.Function(ownValues[i]) != 0)
                    {
                        Gui.OwnVectorsLabels[i][j].Text = "---";
                    }
                    else
                    {
                        Gui.OwnVectorsLabels[i][j].Text = ownVectors[i][j].ToString("F4");
                    }
                }
            }

            Gui.GraphEquation = characteristicEquation;
            Gui.DifficultyLabel.Text = "Практична складність: " + Gui.Difficulty;
        }
    }
}