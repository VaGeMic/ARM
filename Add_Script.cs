using System.Reflection.Emit;
using System.Windows.Forms;

namespace ARM
{
    /// <summary>
    /// ����� ��� ���������� ������� � ���������
    /// </summary>
    static class Adder_Script
    {
        /// <summary>
        /// ���������� ���� ���������� �����
        /// </summary>
        /// <returns>���������� ���� ���� � �����</returns>
        public static string  Add_Script()
        {
            var fileContent = string.Empty; // ���������� �����
            var filePath = string.Empty;    // ���� � �����+���+����������

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; //������������� �������, ������� ������������ ��� ������ ������ ����
                //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Filter = "python files (*.py)|*.py"; //������ ���������� �������� ����� (���������� � 1)
                openFileDialog.FilterIndex = 2; //������ �������, ����� � ����� ������� ������ ��������� ���������� � �� �������(�� ��������� 1) 
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) //�������� ����������� ����
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