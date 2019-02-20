using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace etgui
{
    public partial class PaddingFixedSequenceForm : Form
    {

        public PaddingFixedSequenceForm(byte[] sequence)
        {
            rng = new RNGCryptoServiceProvider();
            InitializeComponent();
            if (sequence != null)
            {
               
                radioButton2.Checked = true;
                richTextBox1.Text = hex(sequence);
            }
        }

        public byte[] Sequence { get; private set; }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !(richTextBox1.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = radioButton2.Checked);
            if (radioButton2.Checked)
            {
                richTextBox1.Text = textBox1.Text.Equals("") ? "" : hex(textBox1.Text.EncodeToByteArray());
            }
            else
            {
                if (richTextBox1.Text.Length > 0)
                {
                    var h = unhex(richTextBox1.Text);
                    if (h == null) textBox1.Text = "(invalid conversion)";
                    else textBox1.Text = h.DecodeToString();
                }
                else textBox1.Text = "";
            }
        }

        private string hex(byte[] b)
        {
            return Regex.Replace(b.Hex(), ".{2}", "$0 ");

        }
        private byte[] unhex(string s)
        {
            if (Regex.IsMatch(s, "([0-9a-fA-F]{1,2}[ ])?"))
            {
                try
                {
                    return StringToByteArray(s.Replace(" ", ""));
                }
                catch { return null; }

            }
            else
            {
                return null;
            }
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void PaddingFixedSequenceForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var gsf = new GenerateSequenceForm())
            {
                if (gsf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    byte[] seq = new byte[gsf.SeqSize];
                    rng.GetBytes(seq);
                    richTextBox1.Text = hex(seq);
                }
            }
        }

        RNGCryptoServiceProvider rng;
        private void PaddingFixedSequenceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rng.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Data Files|*.dat|All Files|*.*";
                ofd.Title = "Import Sequence";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    richTextBox1.Text = hex(System.IO.File.ReadAllBytes(ofd.FileName));
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] seq;
            if ((seq = unhex(richTextBox1.Text)) != null)
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Data Files|*.dat|All Files|*.*";
                    sfd.Title = "Export Sequence";
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.WriteAllBytes(sfd.FileName, seq);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Conversion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Sequence = textBox1.Text.EncodeToByteArray();
            }
            else
            {
                Sequence = unhex(richTextBox1.Text);
                if (Sequence == null)
                {
                    MessageBox.Show("Invalid Conversion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
