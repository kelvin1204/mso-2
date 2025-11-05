using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mso_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var LoadProgramsGUI = new LoadProgramsGUI();
            LoadProgramsGUI.Location = new Point(10, 10);
            this.Controls.Add(LoadProgramsGUI);

            var TextEditorGUI = new TextEditorGUI();
            TextEditorGUI.Location = new Point(200, 10);
            this.Controls.Add(TextEditorGUI);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
