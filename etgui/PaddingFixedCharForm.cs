using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;

namespace etgui
{
    public partial class PaddingFixedCharForm : Form
    {
        public PaddingFixedCharForm(char? c)
        {
            InitializeComponent();
            if (c.HasValue) textBox1.Text = "" + c.Value;
        }

        private void PaddingFixedCharForm_Load(object sender, EventArgs e)
        {

        }

        public char Character { get { return checkBox1.Checked? (char)Convert.ToByte(textBox1.Text,16) : textBox1.Text[0]; } }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && !System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[0-9A-Fa-f]{1,2}"))
            {
                MessageBox.Show("Invalid Hex Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = checkBox1.Checked ? 2 : 1;
            if (checkBox1.Checked && textBox1.Text.Length>0) textBox1.Text = ((byte)textBox1.Text[0]).ToString("x2");
            else if(textBox1.Text.Length>0) textBox1.Text = ""+(char)Convert.ToByte(textBox1.Text, 16);
        }
    }
}
