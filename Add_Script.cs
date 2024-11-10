using System.Reflection.Emit;
using System.Windows.Forms;

namespace ARM
{
    /// <summary>
    /// Класс для добавления скрипта в программу
    /// </summary>
    static class Adder_Script
    {
        /// <summary>
        /// Диалоговое окно дабавления файла
        /// </summary>
        /// <returns>Возвращает один путь к файлу</returns>
        public static string  Add_Script()
        {
            var fileContent = string.Empty; // Содержание файла
            var filePath = string.Empty;    // Путь к файлу+имя+расширение

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; //устанавливает каталог, который отображается при первом вызове окна
                //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Filter = "python files (*.py)|*.py"; //Фильтр расширения искомого файла (индексация с 1)
                openFileDialog.FilterIndex = 2; //Индекс фильтра, можно в одном фильтре задать несколько расширений и по индексу(по умолчанию 1) 
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) //Открытие диалогового окна
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                    
                }
                return filePath;
            }
        }
    }
     
}