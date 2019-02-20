using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace etgui
{
    public partial class GenerateSequenceForm : Form
    {
        public GenerateSequenceForm()
        {
            InitializeComponent();
        }

        private void GenerateSequenceForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        public int SeqSize { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            SeqSize = ((int)numericUpDown1.Value) * ((comboBox1.SelectedIndex == 0) ? 1 : 1024);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
