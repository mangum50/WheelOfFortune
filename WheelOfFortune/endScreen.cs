using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheelOfFortune
{
    public partial class endScreen : Form
    {
        string result;
        string endPhrase;
        public endScreen(string r, string p)
        {
            result = r;
            endPhrase = p;
            InitializeComponent();
        }

        private void endScreen_Load(object sender, EventArgs e)
        {
            resultLabel.Text = result;
            phraseLabel.Text = "The phrase was: " + endPhrase;
        }

        private void endProgramButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
