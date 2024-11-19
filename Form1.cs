using System.Numerics;

namespace ARM
{
    public partial class Form1 : Form
    {
        int buh = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void Add_Script_Button_Click(object sender, EventArgs e)
        {
            List<string> path = new List<string>(); //лист с путем на каждый файл
            path.Add( Adder_Script.Add_Script());   //метод статич. класса для открытия окна добавления скрипта
            label1.Text= path.Last();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //Button helloButton = new Button();
            //helloButton.BackColor = Color.LightGray;
            //helloButton.ForeColor = Color.DarkGray;
            //helloButton.Location = new Point(10, 10);
            //helloButton.Text = "Привет";
            //this.Controls.Add(helloButton);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("this is a freakin' string you arsewipe" + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewScriptForm newScriptForm = new NewScriptForm(this);
            newScriptForm.Show();
        }
        public void AddNewScript(string name)
        {
            Button scriptButton = new Button();
            scriptButton.Text = $"{name}";
            scriptButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            scriptButton.AutoSize = true;
            tableLayoutPanel2.Controls.Add(scriptButton);
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].Height = 30;
        }
    }
}
