using System.Numerics;

namespace ARM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = "Hello World";
        }
        private void Add_Script_Button_Click(object sender, EventArgs e)
        {
            List<string> path = new List<string>(); //лист с путем на каждый файл
            path.Add( Adder_Script.Add_Script());   //метод статич. класса для открытия окна добавления скрипта
            label1.Text= path.Last();
        }

    }
}
