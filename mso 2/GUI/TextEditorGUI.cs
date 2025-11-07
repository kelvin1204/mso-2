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
        ClientGUI client;
        public event EventHandler? UpdateGrid;
        public TextEditorGUI(ClientGUI Client)
        {
            InitializeComponent();
            client = Client;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            string output = "";

            if (TextBox.Text == "")
            {
                Output.Text = "Add commands to the editor to run a program!";
                return;
            }

            switch (TextBox.Lines[0])
            {
                case "Load: Beginner program": output = client.ExecuteCommand("example", ["beginner"]); break;
                case "Load: Intermediate program": output = client.ExecuteCommand("example", ["intermediate"]); break;
                case "Load: Advanced program": output = client.ExecuteCommand("example", ["advanced"]); break;
                default: output = client.ExecuteCommand("string", TextBox.Lines); break;
            }

            Output.Text = output;

            UpdateGrid?.Invoke(this, new EventArgs());
        }

        private void Metrics_Click(object sender, EventArgs e)
        {
            Output.Text = client.GetMetrics("string", TextBox.Lines);
        }

        public void SetEditorText(string text) 
        {
            TextBox.Text = text;
        }
    }
}
