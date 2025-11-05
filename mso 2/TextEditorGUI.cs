using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mso_3;

namespace mso_2
{
    public partial class TextEditorGUI : UserControl
    {
        Grid grid;
        MoveEntity entity;
        public TextEditorGUI()
        {
            InitializeComponent();

            grid = new Grid(0, 0);
            entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);
        }

        private void Run_Click(object sender, EventArgs e)
        {
            var input = InputFactory.Create("string", TextBox.Lines);
            ICommand cmd = input.Read();
            Output.Text = cmd.Execute(entity);
        }

        private void Metrics_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
