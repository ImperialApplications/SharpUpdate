using SharpUpdate2_0;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace TesApp
{
    public partial class Form1 : Form
    {
        private SharpUpdater updater;

        public Form1()
        {
            InitializeComponent();

            label1.Text = ProductName + "\n" + ProductVersion;

            updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri("https://raw.githubusercontent.com/ImperialApplications/SharpUpdate/main/update.xml?token=GHSAT0AAAAAAB57EYLLYV2OIVUSXFWGA5ICY6ZJZMA"));
            //updater = new SharpUpdater(Aseembly.GetExecutingAssembly(), this, new Uri (new System.IO.FileInfo(@"..\..\..\project.xml").FullName)); //for local testing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }
    }
}
