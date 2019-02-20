using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.IO;
using et;

namespace etgui
{
    public partial class PaddingForm : Form
    {
        public PaddingForm(PadSettings? set)
        {
            InitializeComponent();
            load(set, true);
        }
        void load(PadSettings? set, bool inital)
        {
            if (!inital) loading = true;
            if (set != null)
            {
                var ps = set.Value;
                checkBox1.Checked = true;
                textBox1.Text = (ps.size.HasValue ? ps.size.Value.ToString() : "?");
                checkBox2.Checked = !ps.size.HasValue;

                comboBox1.SelectedIndex = (int)(ps.type ?? PadType.Zero);
                if (!(checkBox3.Checked = !ps.type.HasValue) && comboBox1.SelectedIndex == (int)PadType.FixedC)
                {
                    f_c = ps._t_fc_char;
                }
                if (!checkBox3.Checked && comboBox1.SelectedIndex == (int)PadType.FixedS)
                {
                    f_s = ps._t_fc_seq;
                }



                comboBox2.SelectedIndex = (int)(ps.location ?? PadLocation.Start);
                checkBox4.Checked = !ps.location.HasValue;
            }
            else
            {
                checkBox1.Checked = false;
                groupBox1.Enabled = false;

                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 0;
            }
            if (!inital) loading = false;
        }
        bool loading = true;
        private void Form2_Load(object sender, EventArgs e)
        {
            doNotLoadPaddingInformationFromFileToolStripMenuItem.Checked = DisableLoading;
            forceCurrentConfigurationToolStripMenuItem.Checked = ForceCurrentConfiguration;
            checkPresets();
            loading = false;
        }

        readonly string presetDir = Environment.GetEnvironmentVariable("appdata") + "\\etgui-presets";



        void checkPresets()
        {
            if (Directory.Exists(presetDir))
            {
                if (File.Exists(presetDir + "\\1"))
                {
                    toolStripMenuItem2.Text = "1 [*]";
                    toolStripMenuItem5.Text = "1 [*]";
                }
                if (File.Exists(presetDir + "\\2"))
                {
                    toolStripMenuItem3.Text = "2 [*]";
                    toolStripMenuItem6.Text = "2 [*]";
                }
                if (File.Exists(presetDir + "\\3"))
                {
                    toolStripMenuItem4.Text = "3 [*]";
                    toolStripMenuItem7.Text = "3 [*]";
                }
            }
        }

       

        public PadSettings? Settings { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                int sz;
                if (int.TryParse(textBox1.Text, out sz) || checkBox2.Checked)
                {
                    PadSettings o = new PadSettings();
                    o.size = (checkBox2.Checked ? (int?)null : sz);
                    o.type = (checkBox3.Checked ? (PadType?)null : (PadType)comboBox1.SelectedIndex);
                    o.location = (checkBox4.Checked ? (PadLocation?)null : (PadLocation)comboBox2.SelectedIndex);

                    if (!checkBox3.Checked && comboBox1.SelectedIndex == (int)PadType.FixedC && f_c.HasValue)
                    {
                        o._t_fc_char = f_c.Value;
                    }
                    if (!checkBox3.Checked && comboBox1.SelectedIndex == (int)PadType.FixedS && (f_s != null))
                    {
                        o._t_fc_seq = f_s;
                    }

                    Settings = o;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Size Specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Settings = null;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private char? f_c = null;
        private byte[] f_s = null;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (comboBox1.SelectedIndex == (int)PadType.FixedC)
                {
                    using (var pfc = new PaddingFixedCharForm(f_c))
                    {
                        if (pfc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            f_c = pfc.Character;
                        }
                    }
                }
                else if (comboBox1.SelectedIndex == (int)PadType.FixedS)
                {
                    using (var pfs = new PaddingFixedSequenceForm(f_s))
                    {
                        if (pfs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            f_s = pfs.Sequence;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = !checkBox3.Checked;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = !checkBox4.Checked;
        }

        public bool ForceCurrentConfiguration { get; set; }
        public bool DisableLoading { get; set; }

        private void forceCurrentConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForceCurrentConfiguration = forceCurrentConfigurationToolStripMenuItem.Checked;
        }

        private void doNotLoadPaddingInformationFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableLoading = doNotLoadPaddingInformationFromFileToolStripMenuItem.Checked;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableLoading = false;
            ForceCurrentConfiguration = false;

            checkBox1.Checked = false;
            textBox1.Text = "?";
            checkBox2.Checked = true;
            checkBox3.Checked = false;
            checkBox4.Checked = true;
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;

            Form2_Load(null, null);
        }

        void loadPreset(int i)
        {
            if (!File.Exists(presetDir + "\\" + i))
            {
                load(null, false);
            }
            else
            {
                try
                {
                    using (var fs = new FileStream(presetDir + "\\" + i, FileMode.Open))
                    {
                        PadSettings ps = new PadSettings();
                        ps.Load(fs);
                        load(ps, false);
                    }
                }
                catch
                {
                    load(null, false);
                }
            }
        }

        bool? savePreset(int i)
        {
            
            if (!Directory.Exists(presetDir))
            {
                Directory.CreateDirectory(presetDir);
            }
            if (checkBox1.Checked)
            {
                int sz;
                if (int.TryParse(textBox1.Text, out sz) || checkBox2.Checked)
                {
                    PadSettings o = new PadSettings();
                    o.size = (checkBox2.Checked ? (int?)null : sz);
                    o.type = (checkBox3.Checked ? (PadType?)null : (PadType)comboBox1.SelectedIndex);
                    o.location = (checkBox4.Checked ? (PadLocation?)null : (PadLocation)comboBox2.SelectedIndex);

                    if (!checkBox3.Checked && comboBox1.SelectedIndex == (int)PadType.FixedC && f_c.HasValue)
                    {
                        o._t_fc_char = f_c.Value;
                    }
                    if (!checkBox3.Checked && comboBox1.SelectedIndex == (int)PadType.FixedS && (f_s != null))
                    {
                        o._t_fc_seq = f_s;
                    }

                    Settings = o;
                }
                else
                {
                    MessageBox.Show("Invalid Size Specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                Settings = null;
            }
            if (Settings == null)
            {
                if (File.Exists(presetDir + "\\" + i)) File.Delete(presetDir + "\\" + i);
                return false;
            }
            else
            {
                using (var fs = new FileStream(presetDir + "\\" + i, FileMode.Create))
                {
                    Settings.Value.Save(fs);
                    return true;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var b = savePreset(1);
            if (b != null)
            {
                if (b.Value) toolStripMenuItem2.Text= toolStripMenuItem5.Text = "1 [*]";
                else toolStripMenuItem2.Text = toolStripMenuItem5.Text = "1";
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var b = savePreset(2);
            if (b != null)
            {
                if (b.Value) toolStripMenuItem3.Text = toolStripMenuItem6.Text = "2 [*]";
                else toolStripMenuItem3.Text = toolStripMenuItem6.Text = "2";
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var b = savePreset(3);
            if (b != null)
            {
                if (b.Value) toolStripMenuItem4.Text = toolStripMenuItem7.Text = "3 [*]";
                else toolStripMenuItem4.Text = toolStripMenuItem7.Text = "3";
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            loadPreset(1);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            loadPreset(2);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            loadPreset(3);
        }

        private void loadPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                int sz;
                if (int.TryParse(textBox1.Text, out sz) || checkBox2.Checked)
                {
                    PadSettings o = new PadSettings();
                    o.size = (checkBox2.Checked ? (int?)null : sz);
                    o.type = (checkBox3.Checked ? (PadType?)null : (PadType)comboBox1.SelectedIndex);
                    o.location = (checkBox4.Checked ? (PadLocation?)null : (PadLocation)comboBox2.SelectedIndex);

                    if (!checkBox3.Checked && comboBox1.SelectedIndex == (int)PadType.FixedC && f_c.HasValue)
                    {
                        o._t_fc_char = f_c.Value;
                    }
                    if (!checkBox3.Checked && comboBox1.SelectedIndex == (int)PadType.FixedS && (f_s != null))
                    {
                        o._t_fc_seq = f_s;
                    }

                    Settings = o;
                }
                else
                {
                    MessageBox.Show("Invalid Size Specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Settings = null;
                return;
            }
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Export Preset";
                sfd.Filter = "ETGUI Pad Settings Preset File|*.etguipp|Data Files|*.dat|All Files|*.*";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Settings.Value.Save(fs);
                    }
                    MessageBox.Show("Saved Preset", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Import Preset";
                ofd.Filter = "ETGUI Pad Settings Preset File|*.etguipp|Data Files|*.dat|All Files|*.*";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var fs = new FileStream(ofd.FileName, FileMode.Open,FileAccess.Read))
                    {
                        try
                        {
                            PadSettings ps = new PadSettings();
                            ps.Load(fs);
                            load(ps, false);
                            MessageBox.Show("Loaded Preset", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Could not load preset: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
    }
    
}
