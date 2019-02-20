using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

//TODO: Add import and shred option for "import"

namespace etgui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            richTextBox1.Font = fontDialog1.Font;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allowOverwrite())
            {
                richTextBox1.Text = "";
                reset();
                if (!settings.forceCurrentPadding)
                    padding = null;
            }
        }
        bool allowOverwrite()
        {
            byte[] by;
            if (prevHash == null && currentET == null && richTextBox1.Text.Equals("")) return true;
            if (currentET == null || prevHash == null || !(by = richTextBox1.Text.EncodeToByteArray().SHA1Hash()).ElementsEqual(prevHash, 20)) //not saved
            {
                //if (currentET == null) MessageBox.Show("eh");
                DialogResult di;
                if ((di = MessageBox.Show("Save changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                    return true;
                }
                else if (di == System.Windows.Forms.DialogResult.No) return true;
                else return false;
            }
            else return true;
        }
        string currentFile = "";
        byte[] prevHash = null;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile.Equals("") || !File.Exists(currentFile))
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                save();
            }
        }
        void save()
        {
            //todo: save efs
            if (!settings.disableReadPadding)
                currentET.PadSettings = padding;
            byte[] by = currentET.Encrypt(richTextBox1.Text);
            et.EncryptedTextContainer c = new et.EncryptedTextContainer() { Data = by, Salt = currentET.Salt };
            try
            {
                using (var fs = new FileStream(currentFile, FileMode.Create))
                {
                    c.Save(fs);
                    prevHash = richTextBox1.Text.EncodeToByteArray().SHA1Hash();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var ofd = new OpenFileDialog())
            {
                ofd.Title = "Import Text File";
                ofd.Filter = "Text Files|*.txt|All Files|*.*";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(ofd.FileName);
                    reset();
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Export Text File";
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, richTextBox1.Text);
                    reset();
                }
            }
        }
        et.EncryptedText currentET = null;
        void reset()
        {
            currentFile = "";
            prevHash = null;
            efs = null;
            if(currentET!=null) currentET.Dispose();
            currentET = null;

        }
        private void load(string fn)
        {
            reset();
            try
            {
                using (var s = new FileStream(fn, FileMode.Open, FileAccess.Read))
                {
                    et.EncryptedTextContainer t = new et.EncryptedTextContainer();
                    t.Load(s);
                    using (var f = new PasswordForm())
                    {
                        if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            currentET = new et.EncryptedText(f.Key.DecodeToString(), t.Salt);
                            if (settings.forceCurrentPadding)
                                currentET.PadSettings = padding;
                            else if (!settings.disableReadPadding)
                                padding = currentET.PadSettings;//does this even do anything?
                            richTextBox1.Text = currentET.Decrypt(t.Data);
                            currentFile = fn;
                            prevHash = richTextBox1.Text.EncodeToByteArray().SHA1Hash();
                            //TODO: Load efs
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                reset();
                MessageBox.Show("Could not open file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allowOverwrite())
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Open File";
                    ofd.Filter = "Encrypted Text Files|*.et|All Files|*.*";
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        load(ofd.FileName);
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Save File";
                sfd.Filter = "Encrypted Text Files|*.et|All Files|*.*";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var f = new PasswordForm())
                    {
                        if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            reset();
                            currentFile = sfd.FileName;
                            currentET = new et.EncryptedText(f.Key.DecodeToString());
                            save();
                            /*if(!settings.disableReadPadding)
                                 currentET.PadSettings = padding;    

                            byte[] by = currentET.Encrypt(richTextBox1.Text);
                            
                            et.EncryptedTextContainer c = new et.EncryptedTextContainer() { Data = by, Salt = currentET.Salt };
                            try
                            {
                                using (var fs = new FileStream(currentFile, FileMode.Create))
                                {
                                    c.Save(fs);
                                    prevHash = richTextBox1.Text.EncodeToByteArray().SHA1Hash();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error saving: " + ex.Message);
                            }*/
                        }
                    }
                   
                }
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
                else if (e.KeyCode == Keys.N)
                {
                    newToolStripMenuItem_Click(null, null);
                }
                else if (e.KeyCode == Keys.O)
                {
                    openToolStripMenuItem_Click(null, null);
                }
                else if (e.KeyCode == Keys.E)
                {
                    exportToolStripMenuItem_Click(null, null);

                }
                else if (e.KeyCode == Keys.I)
                {
                    importToolStripMenuItem_Click(null, null);
                }
            }
        }
        readonly string settingsLocation = Environment.GetEnvironmentVariable("appdata") + "\\etgui.dat";

        ApplicationSettings settings;

        void loadSettings()
        {
            if (File.Exists(settingsLocation))
            {
                try
                {
                    using (var fs = new FileStream(settingsLocation, FileMode.Open))
                    {
                        settings = fs.ReadValue<ApplicationSettings>();

                        if (settings.hasPaddingSaved)
                        {
                            et.PadSettings ps = new et.PadSettings();
                            ps.Load(fs);
                            padding = ps;
                            if (settings.forceCurrentPadding && currentET != null)
                                currentET.PadSettings = padding;
                        }

                    }
                }
                catch
                {
                    settings = default(ApplicationSettings);
                }
            }
            else settings = new ApplicationSettings();
        }
        void saveSettings()
        {
            try
            {
                using (var fs = new FileStream(settingsLocation, FileMode.Create))
                {
                    if (!settings.disableReadPadding && currentET != null &&!settings.forceCurrentPadding)
                        padding = currentET.PadSettings;
                    if (padding != null)
                    {
                        settings.hasPaddingSaved = true;
                        fs.WriteValue<ApplicationSettings>(settings);
                        padding.Value.Save(fs);
                    }
                    else
                    {
                        settings.hasPaddingSaved = false;
                        fs.WriteValue<ApplicationSettings>(settings);
                    }
                }
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                if (File.Exists(args[1]))
                {
                    load(args[1]);
                }
            }
            loadSettings();
            fontDialog1.Font = richTextBox1.Font;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel = !allowOverwrite())
            {
                saveSettings();
                reset();
            }
        }

        private void uhhSomethingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentET != null)
            {
                using(var f = new PasswordForm()) {
                    if(f.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                        var ne = currentET.Clone(f.Key.DecodeToString());
                        currentET.Dispose();
                        currentET = ne;
                    }
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uhhSomethingToolStripMenuItem.Enabled = currentET != null;
        }

        private et.PadSettings? padding = null;

        private void paddingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentET != null && !settings.disableReadPadding && !settings.forceCurrentPadding) padding = currentET.PadSettings;
            using (var pf = new PaddingForm(padding))
            {
                pf.DisableLoading = settings.disableReadPadding;
                pf.ForceCurrentConfiguration = settings.forceCurrentPadding;
                if (pf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    padding = pf.Settings;
                    if (currentET != null) currentET.PadSettings = padding;

                    settings.forceCurrentPadding = pf.ForceCurrentConfiguration;
                    settings.disableReadPadding = pf.DisableLoading;
                }
            }
        }
        et.EmbeddedFilesystem efs = null;
        private void embeddedFilesystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (efs == null)
            {
                efs = new et.EmbeddedFilesystem();
            }
            using (var f = new EmbeddedFilesystemForm(efs))
            {
                f.ShowDialog();
                efs = f.FileSystem;
            }
        }

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ApplicationSettings
    {
        public bool forceCurrentPadding;
        public bool hasPaddingSaved;
        public bool disableReadPadding;
    }
}
