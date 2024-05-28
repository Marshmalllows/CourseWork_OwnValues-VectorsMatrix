namespace CourseWork
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SizeTStrip = new System.Windows.Forms.ToolStrip();
            this.SizeCBox = new System.Windows.Forms.ToolStripComboBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.MethodLabel = new System.Windows.Forms.Label();
            this.MethodTStrip = new System.Windows.Forms.ToolStrip();
            this.MethodCBox = new System.Windows.Forms.ToolStripComboBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.MatrixControlGroup = new System.Windows.Forms.GroupBox();
            this.toSave = new System.Windows.Forms.CheckBox();
            this.SizeTStrip.SuspendLayout();
            this.MethodTStrip.SuspendLayout();
            this.MatrixControlGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // SizeTStrip
            // 
            this.SizeTStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SizeTStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.SizeCBox });
            this.SizeTStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.SizeTStrip.Location = new System.Drawing.Point(184, 9);
            this.SizeTStrip.Name = "SizeTStrip";
            this.SizeTStrip.Size = new System.Drawing.Size(124, 28);
            this.SizeTStrip.TabIndex = 0;
            this.SizeTStrip.Text = "SizeTStrip";
            // 
            // SizeCBox
            // 
            this.SizeCBox.AccessibleName = "";
            this.SizeCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SizeCBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeCBox.Items.AddRange(new object[] { "--", "2", "3", "4", "5", "6" });
            this.SizeCBox.Name = "SizeCBox";
            this.SizeCBox.Size = new System.Drawing.Size(121, 28);
            this.SizeCBox.Tag = "";
            this.SizeCBox.SelectedIndexChanged += new System.EventHandler(this.sizeCBox_IndexChanged);
            this.SizeCBox.Click += new System.EventHandler(this.sizeCBox_Click);
            // 
            // SizeLabel
            // 
            this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeLabel.Location = new System.Drawing.Point(12, 9);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(169, 23);
            this.SizeLabel.TabIndex = 1;
            this.SizeLabel.Text = "Розмірність матриці:";
            // 
            // MethodLabel
            // 
            this.MethodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MethodLabel.Location = new System.Drawing.Point(321, 9);
            this.MethodLabel.Name = "MethodLabel";
            this.MethodLabel.Size = new System.Drawing.Size(70, 23);
            this.MethodLabel.TabIndex = 2;
            this.MethodLabel.Text = "Метод:";
            // 
            // MethodTStrip
            // 
            this.MethodTStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.MethodTStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MethodCBox });
            this.MethodTStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.MethodTStrip.Location = new System.Drawing.Point(394, 9);
            this.MethodTStrip.Name = "MethodTStrip";
            this.MethodTStrip.Size = new System.Drawing.Size(124, 28);
            this.MethodTStrip.TabIndex = 0;
            this.MethodTStrip.Text = "MethodTStrip";
            // 
            // MethodCBox
            // 
            this.MethodCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodCBox.Items.AddRange(new object[] { "--", "А.Н.Крилова", "Левер\'є-Фадєєва" });
            this.MethodCBox.Name = "MethodCBox";
            this.MethodCBox.Size = new System.Drawing.Size(121, 28);
            this.MethodCBox.SelectedIndexChanged += new System.EventHandler(this.methodCBox_IndexChanged);
            this.MethodCBox.Click += new System.EventHandler(this.methodCBox_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(8, 21);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(114, 33);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Очистити";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(128, 21);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(114, 33);
            this.CalculateButton.TabIndex = 4;
            this.CalculateButton.Text = "Обчислити";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(248, 21);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(114, 33);
            this.GenerateButton.TabIndex = 5;
            this.GenerateButton.Text = "Згенерувати";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // MatrixControlGroup
            // 
            this.MatrixControlGroup.Controls.Add(this.ClearButton);
            this.MatrixControlGroup.Controls.Add(this.GenerateButton);
            this.MatrixControlGroup.Controls.Add(this.CalculateButton);
            this.MatrixControlGroup.Location = new System.Drawing.Point(265, 443);
            this.MatrixControlGroup.Name = "MatrixControlGroup";
            this.MatrixControlGroup.Size = new System.Drawing.Size(369, 68);
            this.MatrixControlGroup.TabIndex = 6;
            this.MatrixControlGroup.TabStop = false;
            this.MatrixControlGroup.Text = "Керування матрицею";
            this.MatrixControlGroup.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // toSave
            // 
            this.toSave.Location = new System.Drawing.Point(22, 465);
            this.toSave.Name = "toSave";
            this.toSave.Size = new System.Drawing.Size(199, 33);
            this.toSave.TabIndex = 7;
            this.toSave.Text = "Зберегти результат";
            this.toSave.UseVisualStyleBackColor = true;
            this.toSave.CheckedChanged += new System.EventHandler(this.toSave_CheckedChanged);
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(886, 523);
            this.Controls.Add(this.toSave);
            this.Controls.Add(this.MatrixControlGroup);
            this.Controls.Add(this.MethodTStrip);
            this.Controls.Add(this.MethodLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.SizeTStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Gui";
            this.Text = "Курсова Робота";
            this.Load += new System.EventHandler(this.sizeCBox_Click);
            this.SizeTStrip.ResumeLayout(false);
            this.SizeTStrip.PerformLayout();
            this.MethodTStrip.ResumeLayout(false);
            this.MethodTStrip.PerformLayout();
            this.MatrixControlGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox toSave;

        private System.Windows.Forms.GroupBox MatrixControlGroup;

        private System.Windows.Forms.Button ClearButton;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button GenerateButton;

        private System.Windows.Forms.ToolStripComboBox MethodCBox;

        private System.Windows.Forms.ToolStrip MethodTStrip;

        private System.Windows.Forms.Label MethodLabel;

        private System.Windows.Forms.Label SizeLabel;

        private System.Windows.Forms.ToolStripComboBox SizeCBox;

        private System.Windows.Forms.ToolStrip SizeTStrip;

        #endregion
    }
}