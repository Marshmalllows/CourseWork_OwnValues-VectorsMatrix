using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace CourseWork
{
    public partial class Gui : Form
    {
        public static ZedGraphControl ZedGraphControl;
        
        public Gui()
        {
            InitializeComponent();
            SizeCBox.SelectedIndex = 0;
            MethodCBox.SelectedIndex = 0;
            InitializeZedGraph();
        }

        private void InitializeZedGraph()
        {
            ZedGraphControl = new ZedGraphControl();
            
            ZedGraphControl.Location = new Point(395, 40);
            ZedGraphControl.Name = "zedGraphControl";
            ZedGraphControl.Size = new Size(475, 400);
            ZedGraphControl.TabIndex = 0;
            
            var myPane = ZedGraphControl.GraphPane;
            myPane.Title.Text = "Характеристичний поліном";
            myPane.XAxis.Title.Text = "X Вісь";
            myPane.YAxis.Title.Text = "Y Вісь";
            
            var myCurve = myPane.AddCurve("Характеристичний поліном", new PointPairList(), Color.Blue, SymbolType.None);
            
            ZedGraphControl.ZoomEvent += ZedGraphControl_ZoomEvent;
            ZedGraphControl.ScrollEvent += ZedGraphControl_ScrollEvent;
        }
        
        private void ZedGraphControl_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            UpdateGraph(sender.GraphPane);
        }

        private void ZedGraphControl_ScrollEvent(object sender, ScrollEventArgs e)
        {
            UpdateGraph((sender as ZedGraphControl).GraphPane);
        }

        public static Polynomial GraphEquation;
            
        private TextBox[][] _textBoxes;

        private static System.Windows.Forms.Label[] _ownV1Labels;
        
        private static System.Windows.Forms.Label[] _ownV2Labels;
        
        public static System.Windows.Forms.Label[] OwnValuesLabels;

        public static System.Windows.Forms.Label[][] OwnVectorsLabels;

        public static System.Windows.Forms.Label DifficultyLabel;

        public static int Difficulty = 0;

        private TextBox[][] TextBoxMatrix
        {
            get
            {
                return _textBoxes;
            }
            set
            {
                _textBoxes = value;

                for (var i = 0; i < _textBoxes.Length; i++)
                {
                    for (var j = 0; j < _textBoxes.Length; j++)
                    {
                        _textBoxes[i][j].TextChanged += textBox_TextChanged;
                        _textBoxes[i][j].KeyPress += textBox_KeyPress;
                    }
                }
            }
        }

        public static Matrix Current;

        public static string Method;

        private void sizeCBox_Click(object sender, EventArgs e)
        {
            SizeCBox.BackColor = SystemColors.Window;
        }

        private void sizeCBox_IndexChanged(object sender, EventArgs e)
        {
            SizeCBox.BackColor = SystemColors.Window;
            InitializeZedGraph();
            var matrixTBox = new TextBox[6][];
            var ownValuesLabels = new System.Windows.Forms.Label[6];
            var ownValuesValueLabels = new System.Windows.Forms.Label[6];
            var ownVectorsLabels = new System.Windows.Forms.Label[6];
            var ownVectorsValuesLabels = new System.Windows.Forms.Label[6][];

            for (var i = 0; i < 6; i++)
            {
                matrixTBox[i] = new TextBox[6];
                ownVectorsValuesLabels[i] = new System.Windows.Forms.Label[6];
                for (var j = 0; j < 6; j++)
                {
                    matrixTBox[i][j] = new TextBox();
                    ownVectorsValuesLabels[i][j] = new System.Windows.Forms.Label();
                }
                ownValuesLabels[i] = new System.Windows.Forms.Label();
                ownValuesValueLabels[i] = new System.Windows.Forms.Label();
                ownVectorsLabels[i] = new System.Windows.Forms.Label();
            }

            DifficultyLabel = new System.Windows.Forms.Label();
            DifficultyLabel.Name = "difficultyLabel";
            DifficultyLabel.Text = "Практична складність:";
            DifficultyLabel.Location = new Point(530, 10);
            DifficultyLabel.AutoSize = true;
            DifficultyLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            
            for (var i = 0; i < 6; i++)
            {
                ownValuesLabels[i].Name = "ownValueLabel";
                ownValuesLabels[i].Text = $"λ{i + 1}:";
                ownValuesLabels[i].Location = new Point(14 + 64 * i , 40);
                ownValuesLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                ownValuesLabels[i].Size = new Size(50, 18);
                ownValuesLabels[i].Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
                ownValuesValueLabels[i].Name = "ownValueLabel";
                ownValuesValueLabels[i].Text = "";
                ownValuesValueLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                ownValuesValueLabels[i].Location = new Point(14 + 64 * i , 40);
                ownValuesValueLabels[i].Size = new Size(50, 18);
                ownValuesValueLabels[i].Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
                ownVectorsLabels[i].Name = "ownValueLabel";
                ownVectorsLabels[i].Text = $"--x{i + 1}->";
                ownVectorsLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                ownVectorsLabels[i].Location = new Point(14 + 64 * i , 40);
                ownVectorsLabels[i].Size = new Size(50, 18);
                ownVectorsLabels[i].Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);

                for (var j = 0; j < 6; j++)
                {
                    matrixTBox[i][j].Name = $"matrixTBox{i + 1}.{j + 1}";
                    matrixTBox[i][j].Location = new Point(14 + 64 * i, 40 + 32 * j);
                    matrixTBox[i][j].Size = new Size(50, 18);
                    matrixTBox[i][j].Font = new Font(matrixTBox[i][j].Font.FontFamily, 10);
                    ownVectorsValuesLabels[i][j].Name = "ownValueLabel";
                    ownVectorsValuesLabels[i][j].Text = "";
                    ownVectorsValuesLabels[i][j].TextAlign = ContentAlignment.MiddleCenter;
                    ownVectorsValuesLabels[i][j].Location = new Point(14 + 64 * i , 40);
                    ownVectorsValuesLabels[i][j].Size = new Size(50, 18);
                    ownVectorsValuesLabels[i][j].Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
                }
            }

            for (var i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is TextBox)
                {
                    Controls.RemoveAt(i);
                } 
                else if (Controls[i] is System.Windows.Forms.Label)
                {
                    var label = (System.Windows.Forms.Label)Controls[i];
                    if (label.Name == "ownValueLabel" || label.Name == "difficultyLabel")
                    {
                        Controls.RemoveAt(i);
                    }
                }
                else if (Controls[i] is ZedGraphControl)
                {
                    Controls.RemoveAt(i);
                }
            }

            if (SizeCBox.SelectedIndex > 0)
            {
                for (var i = 0; i < SizeCBox.SelectedIndex + 1; i++)
                {
                    for (var j = 0; j < SizeCBox.SelectedIndex + 1; j++)
                    {
                        Controls.Add(matrixTBox[i][j]);
                        ownValuesLabels[i].Location = new Point(14 + 64 * i, 40 + 32 * (SizeCBox.SelectedIndex + 1));
                        ownValuesValueLabels[i].Location = new Point(14 + 64 * i, 56 + 32 * (SizeCBox.SelectedIndex + 1));
                        ownVectorsLabels[i].Location = new Point(14 + 64 * i, 80 + 32 * (SizeCBox.SelectedIndex + 1));
                        ownVectorsValuesLabels[i][j].Location = new Point(14 + 64 * i, 104 + 32 * (SizeCBox.SelectedIndex + 1) + 24 * j); 
                    }
                }
            }

            var sizedMatrix = new TextBox[SizeCBox.SelectedIndex + 1][];
            for (var i = 0; i < SizeCBox.SelectedIndex + 1; i++)
            {
                sizedMatrix[i] = new TextBox[SizeCBox.SelectedIndex + 1];
                for (var j = 0; j < SizeCBox.SelectedIndex + 1; j++)
                {
                    sizedMatrix[i][j] = new TextBox();
                    sizedMatrix[i][j] = matrixTBox[i][j];
                }
            }

            OwnVectorsLabels = ownVectorsValuesLabels;
            TextBoxMatrix = sizedMatrix;
            OwnValuesLabels = ownValuesValueLabels;
            _ownV1Labels = ownValuesLabels;
            _ownV2Labels = ownVectorsLabels;
        }

        private void methodCBox_Click(object sender, EventArgs e)
        {
            MethodCBox.BackColor = SystemColors.Window;
        }

        private void methodCBox_IndexChanged(object sender, EventArgs e)
        {
            MethodCBox.BackColor = SystemColors.Window;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (TextBoxMatrix is null || SizeCBox.SelectedIndex < 1)
            {
                SizeCBox.BackColor = Color.LightCoral;
                MessageBox.Show("Вкажіть розмірність матриці!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var randomizer = new Random();
            
            for (var i = 0; i < TextBoxMatrix.Length; i++)
            {
                for (var j = 0; j < TextBoxMatrix.Length; j++)
                {
                    TextBoxMatrix[i][j].Text = (randomizer.NextDouble() * 200d - 100d).ToString("0.###");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e) {}

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (TextBoxMatrix is null || SizeCBox.SelectedIndex < 1)
            {
                SizeCBox.BackColor = Color.LightCoral;
                MessageBox.Show("Вкажіть розмірність матриці!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            for (var i = 0; i < TextBoxMatrix.Length; i++)
            {
                for (var j = 0; j < TextBoxMatrix.Length; j++)
                {
                    TextBoxMatrix[i][j].Text = null;
                }
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (SizeCBox.SelectedIndex < 1 && MethodCBox.SelectedIndex < 1)
            {
                SizeCBox.BackColor = Color.LightCoral;
                MethodCBox.BackColor = Color.LightCoral;
                WriteWarning("Вкажіть розмірність матриці та метод обчислення!");
                return;
            }
            if (SizeCBox.SelectedIndex < 1)
            {
                SizeCBox.BackColor = Color.LightCoral;
                WriteWarning("Вкажіть розмірність матриці!"); 
                return;
            }

            if (MethodCBox.SelectedIndex < 1)
            {
                MethodCBox.BackColor = Color.LightCoral;
                WriteWarning("Вкажіть метод обчислення!");
                return;
            }

            var isMatrixFull = true;

            for (var i = 0; i < TextBoxMatrix.Length; i++)
            {
                for (var j = 0; j < TextBoxMatrix[i].Length; j++)
                {
                    if (TextBoxMatrix[i][j].Text.Length == 0)
                    {
                        TextBoxMatrix[i][j].BackColor = Color.LightCoral;
                        isMatrixFull = false;
                    }

                    if (TextBoxMatrix[i][j].Text.Length != 0 && TextBoxMatrix[i][j].Text[TextBoxMatrix[i][j].Text.Length - 1] == '-')
                    {
                        TextBoxMatrix[i][j].Text = "";
                        TextBoxMatrix[i][j].BackColor = Color.LightCoral;
                        isMatrixFull = false;
                    }
                    else if (TextBoxMatrix[i][j].Text.Length != 0 && TextBoxMatrix[i][j].Text[TextBoxMatrix[i][j].Text.Length - 1] == ',')
                    {
                        var text = TextBoxMatrix[i][j].Text;
                        TextBoxMatrix[i][j].Text = "";
                        for (var k = 0; k < text.Length - 1; k++)
                        {
                            TextBoxMatrix[i][j].Text += text[k];
                        }
                    }
                }
            }

            if (!isMatrixFull)
            {
                WriteWarning("Введіть усі елементи матриці!");
                return;
            }
            
            var matrix = new double[TextBoxMatrix.Length][];

            for (var i = 0; i < TextBoxMatrix.Length; i++)
            {
                matrix[i] = new double[TextBoxMatrix.Length];
                for (var j = 0; j < TextBoxMatrix.Length; j++)
                {
                    matrix[i][j] = double.Parse(TextBoxMatrix[j][i].Text);
                }
            }

            Current = new Matrix(matrix);

            if (MethodCBox.SelectedIndex == 1)
            {
                ANKrylov.Krylov_Method();
                Method = "А.Н.Крилова";
            }
            else
            {
                LeveryeFadeev.LeveryeFadeev_Method();
                Method = "Левер'є-Фадєєва";
                ZedGraphControl.Visible = true;
            }

            Controls.Add(DifficultyLabel);
            for (var i = 0; i < _ownV1Labels.Length; i++)
            {
                Controls.Add(OwnValuesLabels[i]);
                Controls.Add(_ownV1Labels[i]);
                Controls.Add(_ownV2Labels[i]);
                for (var j = 0; j < OwnVectorsLabels.Length; j++)
                {
                    Controls.Add(OwnVectorsLabels[i][j]);
                }
            }

            if (ANKrylov.CanCalculate || Method == "Левер'є-Фадєєва")
            {
                Controls.Add(ZedGraphControl);
                UpdateGraph(ZedGraphControl.GraphPane);

                if (toSave.Checked)
                {
                    WriteFile.WriteFileResults();
                }
            }
            else
            {
                for (var i = 0; i < Current.Length; i++)
                {
                    OwnValuesLabels[i].Text = "---";
                    for (var j = 0; j < Current.Length; j++)
                    {
                        OwnVectorsLabels[i][j].Text = "---";
                    }
                }
                
                for (var i = Controls.Count - 1; i >= 0; i--)
                {
                    if (Controls[i] is System.Windows.Forms.Label)
                    {
                        var label = (System.Windows.Forms.Label)Controls[i];
                        if (label.Name == "ownValueLabel" || label.Name == "difficultyLabel")
                        {
                            Controls.RemoveAt(i);
                        }
                    }
                    else if (Controls[i] is ZedGraphControl)
                    {
                        Controls.RemoveAt(i);
                    }
                }
            }
        }

        public static void WriteWarning(string message)
        {
            MessageBox.Show(message, "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                textBox.BackColor = SystemColors.Window;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && textBox.SelectionStart != 0)
            {
                e.Handled = true;
            }
            
            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (textBox.Text.Length == 0 || (textBox.Text.Contains("-") && textBox.Text.Length == 1)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                if (textBox.Text.Contains("-") && textBox.SelectionStart == 1)
                {
                    e.Handled = true;
                }

                if (!textBox.Text.Contains("-") && textBox.SelectionStart == 0)
                {
                    e.Handled = true;
                }
            }

            if (textBox.Text.Contains("-") && textBox.SelectionStart == 0)
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar))
            {
                var isNegative = textBox.Text.Contains("-");
                var text = textBox.Text;
                var parts = text.Split(',');
                if (parts.Length < 2)
                {
                    if (!isNegative && textBox.Text.Length > 1)
                    {
                        e.Handled = true;
                    }

                    if (isNegative && textBox.Text.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.SelectionStart <= parts[0].Length)
                    {
                        if (!isNegative && parts[0].Length > 1)
                        {
                            e.Handled = true;
                        }

                        if (isNegative && parts[0].Length > 2)
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (parts[1].Length > 2)
                        {
                            e.Handled = true;
                        }

                        if (parts[1].Length > 3)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }

            if (e.KeyChar == (char)Keys.Back && textBox.Text.Contains(","))
            {
                var newText = "";
                var index = 0;
                var isNegative = textBox.Text.Contains("-");
                var text = textBox.Text;
                var parts = text.Split(',');
                for (var i = 0; i < textBox.Text.Length; i++)
                {
                    if (textBox.Text[i] == ',')
                    {
                        index = i;
                        break;
                    }
                }

                if (index == textBox.SelectionStart && (parts[0].Length == 1 && !isNegative || parts[0].Length == 2 && isNegative))
                {
                    newText = parts[1];
                    textBox.Text = newText;
                    textBox.SelectionStart = index - 1;
                    e.Handled = true;
                } else if (index + 1 == textBox.SelectionStart)
                {
                    newText += parts[0];
                    var moreChars = 0;
                    
                    if (isNegative)
                    {
                        moreChars = 3 - parts[0].Length;
                    }
                    else
                    {
                        moreChars = 2 - parts[0].Length;
                    }

                    if (moreChars > parts[1].Length)
                    {
                        moreChars = parts[1].Length;
                    }
                    
                    for (var i = 0; i < moreChars; i++)
                    {
                        newText += parts[1][i];
                    }
                    
                    textBox.Text = newText;
                    textBox.SelectionStart = index;
                    e.Handled = true;
                }
            }
        }
        
        private void UpdateGraph(GraphPane myPane)
        {
            myPane.CurveList[0].Clear();
            
            var xMin = myPane.XAxis.Scale.Min;
            var xMax = myPane.XAxis.Scale.Max;
            
            var points = new PointPairList();
            for (var x = xMin; x <= xMax; x += (xMax - xMin) * 0.0001)
            {
                var y = GraphEquation.Function(x);
                points.Add(x, y);
            }
            
            myPane.CurveList[0].Points = points;
            
            ZedGraphControl.AxisChange();
            ZedGraphControl.Invalidate();
        }

        private void toSave_CheckedChanged(object sender, EventArgs e) {}
    }
}