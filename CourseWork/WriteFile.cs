using System;
using System.IO;

namespace CourseWork
{
    public static class WriteFile
    {
        public static void WriteFileResults()
        {
            var time = DateTime.Now;

            var filename = "output(" + time.Hour + "." + time.Minute + "." + time.Second +").txt";

            var dir = "E:\\OOP\\CourseWork\\Results\\";

            var path = Path.Combine(dir, filename);
            
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine($"Введена матриця розмірності {Gui.Current.Length}:");
                for (var i = 0; i < Gui.Current.Length; i++)
                {
                    for (var j = 0; j < Gui.Current.Length; j++)
                    {
                        writer.Write($"{Gui.Current.MatrixData[i][j]} ");
                    }
                    writer.WriteLine();
                }
                writer.WriteLine($"Обраний метод:{Gui.Method}");
                writer.WriteLine("Власні числа:");
                for (var i = 0; i < Gui.OwnValuesLabels.Length; i++)
                {
                    if (Gui.OwnValuesLabels[i].Text == "---" || Gui.OwnValuesLabels[i] is null || Gui.OwnValuesLabels[i].Text == "")
                    {
                        break;
                    }
                    writer.WriteLine($"L{i + 1}:{Gui.OwnValuesLabels[i].Text}");
                }
                writer.WriteLine("Власні вектори:");
                for (var i = 0; i < Gui.OwnVectorsLabels.Length; i++)
                {
                    if (Gui.OwnValuesLabels[i].Text == "---" || Gui.OwnValuesLabels[i].Text is null || Gui.OwnValuesLabels[i].Text == "")
                    {
                        break;
                    }
                    writer.Write($"--x{i + 1}->: (");
                    for (var j = 0; j < Gui.OwnVectorsLabels[0].Length - 1; j++)
                    {
                        writer.Write($"{Gui.OwnVectorsLabels[i][j].Text} ");
                    }
                    writer.Write($"{Gui.OwnVectorsLabels[i][Gui.OwnVectorsLabels[0].Length - 1].Text}");
                    writer.WriteLine(")");
                }
                writer.WriteLine($"Практична складність: {Gui.Difficulty}");
            }
        }
    }
}