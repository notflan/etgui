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
    public partial class EFSNewItem : Form
    {
        et.EFSNodeType type;
        public EFSNewItem(et.EFSNodeType type)
        {
            this.type = type;
            TName = "";
            InitializeComponent();
        }

        private void EFSNewItem_Load(object sender, EventArgs e)
        {
            //TODO: Implement file creation
            textBox1.Text = TName;
        }

        public string TName { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            TName = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }
    }
}
