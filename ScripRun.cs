using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
//using System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.PortableExecutable;

namespace ARM
{
    public partial class ScriptRun : Form
    {
        private Form1 parentForm;
        private string outputFilePath = @"..\\Buffer.txt"; // Путь к файлу вывода
        private int buttonNumber = 0; // инлекс кнопки (т.е. самого скрипта)

        public ScriptRun(Form1 pForm)
        {
            parentForm = pForm;
        }

        internal void ScripRun(Button scriptButton, int index)
        {
            buttonNumber = index; // передаю индекс кнопки (скрипта)
            parentForm.textBox1.AppendText(Environment.NewLine + "///////" + buttonNumber); // просто отладка, можешь убрать
            scriptButton.Click += (sender, args) =>
            {
                try
                {
                    parentForm.textBox1.AppendText(Environment.NewLine + "///////" + buttonNumber); // посто отладка, можешь убрать
                    // Код для запуска скрипта Python
                    string pythonPath ="";
                    string pathVariable = Environment.GetEnvironmentVariable("PATH");
                    if (pathVariable != null)
                    {
                        // Разделяем PATH на отдельные пути
                        string[] paths = pathVariable.Split(';');

                        // Ищем путь, содержащий "Python"
                        pythonPath = paths.FirstOrDefault(p => Directory.Exists(p) && File.Exists(Path.Combine(p, "python.exe")));

                        if (!string.IsNullOrEmpty(pythonPath))
                        {
                            Console.WriteLine($"Путь к Python: {pythonPath}");
                        }
                        else
                        {
                            Console.WriteLine("Путь к Python не найден в переменной PATH.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Переменная PATH не найдена.");
                    }
                    pythonPath += "python.exe";
                    string scriptPath = parentForm.ScriptFiles[buttonNumber].filepath; // тут поменял Last на индекс
                    ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath);
                    //startInfo.Arguments = $"\"{scriptPath}\""; // Аргументы передаются в виде строки
                    startInfo.ArgumentList.Add(scriptPath);
                    foreach (var i in parentForm.ScriptFiles[buttonNumber].param) // тут поменял Last на индекс
                    {
                        startInfo.ArgumentList.Add(i.Value);
                    }

                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardError = true;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.StandardErrorEncoding = Encoding.UTF8;
                    startInfo.StandardOutputEncoding = Encoding.UTF8;


                    using (Process process = Process.Start(startInfo))
                    {
                        string standardOutput = process.StandardOutput.ReadToEnd();
                        string standardError = process.StandardError.ReadToEnd();

                        File.WriteAllText(outputFilePath, standardOutput + Environment.NewLine + standardError);

                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Исправлена ошибка с MessageBoxButton
                }
                OutConsole();
            };

        }

        void OutConsole()
        {
            string searchWord = "Traceback";
            bool found = false;
            try
            {
                using (StreamReader reader = new StreamReader(outputFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(searchWord))
                        {
                            found = true;
                        }
                        if(found)
                            parentForm.textBox2.AppendText(line + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Исправлена ошибка с MessageBoxButton
            }

            if (found)
            {

            }
            else
            {
                using (StreamReader reader = new StreamReader(outputFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        parentForm.textBox1.AppendText(line + Environment.NewLine);
                    }
                }
            }
            File.Create(outputFilePath).Close();
        }
    }
}