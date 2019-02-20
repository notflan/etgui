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
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }
        //public byte[] PasswordHash { get { return et.ET.HashPassword(textBox1.Text); } }
        public byte[] Key { get { return checkBox1.Checked ? adv_key : et.ET.HashPassword(textBox1.Text).Hex().EncodeToByteArray(); } }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && adv_key == null)
            {
                MessageBox.Show("No key is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(null, null);
        }

        private byte[] adv_key = null;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                textBox1.Enabled = !(textBox3.Enabled = button3.Enabled = button4.Enabled = true);
            }
            else
            {

                textBox1.Enabled = !(textBox3.Enabled = button3.Enabled = button4.Enabled = false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Key Files|*.k|Data Files|*.dat|All Files|*.*";
                ofd.Title = "Import Key";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    adv_key = System.IO.File.ReadAllBytes(ofd.FileName);
                    textBox3.Text = adv_key.SHA1Hash().Hex().ToLower();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var r = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                byte[] k = new byte[SEC_KEY_SIZE];
                r.GetBytes(k);
                adv_key = k;
                textBox3.Text = adv_key.SHA1Hash().Hex().ToLower();
                if (MessageBox.Show("Save key to file? It will be unusable if not saved", "Key Generation Successful", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Key Files|*.k|Data Files|*.dat|All Files|*.*";
                        sfd.Title = "Save Key";
                        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            System.IO.File.WriteAllBytes(sfd.FileName, k);
                        }
                    }
                }

            }
        }
        public const int SEC_KEY_SIZE = 32;
    }
}
