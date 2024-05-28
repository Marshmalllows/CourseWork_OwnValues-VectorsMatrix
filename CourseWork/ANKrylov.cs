using System;

namespace CourseWork
{
    public class ANKrylov
    {
        private static Matrix _matrix = Gui.Current;

        public static bool CanCalculate;
        public static void Krylov_Method()
        {
            _matrix = Gui.Current;
            Gui.Difficulty = 0;
            var yVectors = new double[_matrix.Length + 1][];
            for (var i = 0; i < yVectors.Length; i++)
            {
                yVectors[i] = new double[yVectors.Length - 1];
                for (var j = 0; j < yVectors.Length - 1; j++)
                {
                    yVectors[i][j] = 0;
                }
            }

            Gui.Difficulty++;
            yVectors[0][0] = 1;

            for (var i = 1; i < yVectors.Length; i++)
            {
                Gui.Difficulty++;
                yVectors[i] = _matrix.MultiplicationVector(yVectors[i - 1]);
            }

            var slaeCoefficients = new double[_matrix.Length][];
            var slaeVector = new double[_matrix.Length];

            for (var i = 0; i < slaeCoefficients.Length; i++)
            {
                slaeVector[i] = yVectors[yVectors.Length - 1][i];
                Gui.Difficulty++;
                slaeCoefficients[i] = new double[slaeCoefficients.Length];
                for (var j = 0; j < slaeCoefficients[0].Length; j++)
                {
                    Gui.Difficulty++;
                    slaeCoefficients[i][j] = yVectors[yVectors.Length - 2 - j][i];
                }
            }

            var slaeResults = Matrix.GaussSlaeMethod(slaeCoefficients, slaeVector, slaeCoefficients.Length);
            var isNan = false;
            
            for (var i = 0; i < slaeResults.Length; i++)
            {
                Gui.Difficulty++;
                if (slaeResults[i] is Double.NaN)
                {
                    isNan = true;
                    break;
                }
            }

            if (isNan)
            {
                Gui.ZedGraphControl.Visible = false;
                Gui.WriteWarning("Цим методом неможливо обчислити дану матрицю!");
                CanCalculate = false;
                return;
            }
            else
            {
                CanCalculate = true;
                Gui.ZedGraphControl.Visible = true;
            }
            
            var characteristicEquation = new Polynomial(_matrix.Length, slaeResults);
            var ownValues = new double[_matrix.Length];

            for (var i = 0; i < _matrix.Length; i++)
            {
                Gui.Difficulty++;
                ownValues[i] = 0;
            }
            
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

            var ownVectors = new double[ownValues.Length][];
            
            for (var i = 0; i < ownValues.Length; i++)
            {
                ownVectors[i] = new double[_matrix.Length];
            }

            for (var i = 0; i < ownValues.Length; i++)
            {
                var q = new double[_matrix.Length];
                Gui.Difficulty++;
                q[0] = 1;

                for (var j = 1; j < q.Length; j++)
                {
                    Gui.Difficulty++;
                    q[j] = ownValues[i] * q[j - 1] - slaeResults[j - 1];
                }
                
                for (var j = 0; j < _matrix.Length; j++)
                {
                    ownVectors[i][j] = yVectors[_matrix.Length - 1][j];
                    Gui.Difficulty++;

                    for (var k = 1; k < q.Length; k++)
                    {
                        Gui.Difficulty++;
                        ownVectors[i][j] += q[k] * yVectors[_matrix.Length - 1 - k][j];
                    }
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