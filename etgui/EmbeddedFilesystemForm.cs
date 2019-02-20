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
    public partial class EmbeddedFilesystemForm : Form
    {
        et.EmbeddedFilesystem fs;
        public et.EmbeddedFilesystem FileSystem { get { return fs; } private set { fs = value; } }

        public EmbeddedFilesystemForm(et.EmbeddedFilesystem fs)
        {
            this.fs = fs;
            InitializeComponent();
            
        }
        void reload()
        {
            TreeNode root = createTreeNode(fs.Root, null);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(root);

            if(fs.Root.Children!=null)
                foreach (var r in fs.Root.Children)
                {
                    parseNode(r, (root.Tag as EFSNodeTranslation), root);
                }
            reloadImages();
        }
        void parseNode(et.EFSNode node, EFSNodeTranslation n_parent, TreeNode parent)
        {
            var tn = createTreeNode(node, n_parent);
            parent.Nodes.Add(tn);
            if (node.Children != null)
                foreach (var r in node.Children)
                {
                    parseNode(r, (tn.Tag as EFSNodeTranslation), tn);
                }
        }
        TreeNode createTreeNode(et.EFSNode n, EFSNodeTranslation parent)
        {
            TreeNode nt = new TreeNode(n.Name + (n.Type == et.EFSNodeType.Folder ? "/" : ""));
            nt.Tag = new EFSNodeTranslation(n, parent);
            
            return nt;
        }
        private void EmbeddedFilesystemForm_Load(object sender, EventArgs e)
        {
            treeView1.ImageList = imageList1;
            reload();
        }

        //call this one
        void reloadImages()
        {
            for (int i = 1; i < imageList1.Images.Count; i++)
                imageList1.Images[i].Dispose();
            imageList1.Images.Clear();
            imageList1.Images.Add(global::etgui.Properties.Resources.foldershit);
            readdImages();
            //foreach (var i in iconCache) imageList1.Images.Add(i);

        }

        void readdImages()
        {
            foreach (object n in treeView1.Nodes)
            {
                doImageNode((TreeNode)n);
            }
        }

        void doImageNode(TreeNode tn)
        {
            EFSNodeTranslation t = (EFSNodeTranslation)tn.Tag;
            if (t.Node.Type == et.EFSNodeType.Folder)
            {
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
            }
            else
            {
                int c = imageList1.Images.Count;
                Icon i = FileIconLoader.GetFileIcon(t.Node.Name, false);
                if (i != null)
                {
                    imageList1.Images.Add(i);
                    tn.ImageIndex = c;
                    tn.SelectedImageIndex = c;
                }
            }
            foreach (var n in tn.Nodes)
            {
                doImageNode((TreeNode)n);
            }
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fs = new et.EmbeddedFilesystem();
            reload();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!(e.Cancel = (treeView1.SelectedNode == null)))
            {
                newFolderToolStripMenuItem.Enabled = newFileToolStripMenuItem.Enabled = efsnt_of(null).Node.Type == et.EFSNodeType.Folder;
                deleteToolStripMenuItem.Enabled =  efsnt_of(null).Parent != null;
            }
        }

        EFSNodeTranslation efsnt_of(TreeNode n) { return (n??treeView1.SelectedNode).Tag as EFSNodeTranslation; }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                EFSNodeTranslation current = treeView1.SelectedNode.Tag as EFSNodeTranslation;
                string path = current.Node.Name;
                while (current.Parent != null)
                {
                    path = current.Parent.Node.Name + "/" + path;
                    current = current.Parent;
                }
                toolStripStatusLabel1.Text = path;
                
                select(e.Node);
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                select(null);
            }
        }

        void select(TreeNode n)
        {
            if (n == null || (efsnt_of(n).Parent==null))
            {
                groupBox1.Enabled = false;
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                sizelabel.Text = "bytes";
            }
            else
            {
                EFSNodeTranslation nt = n.Tag as EFSNodeTranslation;
                if (nt.Node != null)
                {
                    groupBox1.Enabled = true;
                    int order;
                    et.EFSNodeInformation ni = nt.Node.Metadata;
                    textBox1.Text = nt.Node.Name;
                    textBox2.Text = ni.TimeCreatedUTC.ToString();
                    textBox3.Text = ni.TimeModifiedUTC.ToString();
                    if (nt.Node.Data != null)
                    {
                        textBox4.Text = humanBytes(nt.Node.Data.Length, out order).ToString("0.##");
                        sizelabel.Text = hb_sizes[order];
                    }
                    else
                    {
                        textBox4.Text = "";
                        sizelabel.Text = "bytes";
                    }

                    button3.Enabled = button4.Enabled = nt.Node.Type == et.EFSNodeType.File;

                }
            }
        }

        static readonly string[] hb_sizes = { "bytes", "kb", "mb", "gb", "tb" };
        static double humanBytes(double len, out int order)
        {
            order = 0;
            while (len >= 1024 && order < hb_sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return len;
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var eni = new EFSNewItem(et.EFSNodeType.Folder))
            {
                if (eni.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var tn = treeView1.SelectedNode;
                    var t=  tn.Tag as EFSNodeTranslation;

                    var n = t.Node.AddChild(new et.EFSNode(et.EFSNodeType.Folder, eni.TName, null));
                    

                    tn.Nodes.Add(createTreeNode(n, t));
                    tn.Expand();
                    reloadImages();
                }
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var eni = new EFSNewItem(et.EFSNodeType.File))
            {
                if (eni.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var tn = treeView1.SelectedNode;
                    var t = tn.Tag as EFSNodeTranslation;

                    var n = t.Node.AddChild(new et.EFSNode(et.EFSNodeType.File, eni.TName, null));

                    tn.Nodes.Add(createTreeNode(n, t));
                    tn.Expand();
                    reloadImages();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = efsnt_of(null);
            c.Parent.Node.Children = (from x in c.Parent.Node.Children where x!=c.Node select x).ToArray();
            
            treeView1.SelectedNode.Parent.Nodes.Remove(treeView1.SelectedNode);
            reloadImages();
        }

        private void viewTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            sb.AppendLine("/");
            traverse(fs.Root, "", sb);
            MessageBox.Show(sb.ToString(),"Tree", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        void traverse(et.EFSNode node, string fqn, StringBuilder sb)
        {
            if (node.Children != null)
                foreach (var n in node.Children)
                {
                    sb.AppendLine(fqn + "/" + n.Name);
                    traverse(n, fqn + "/" + n.Name, sb);
                }
        }
    }
    public class EFSNodeTranslation
    {
        public et.EFSNode Node { get; set; }
        public EFSNodeTranslation Parent { get; set; }
        public EFSNodeTranslation(et.EFSNode node, EFSNodeTranslation parent)
        {
            Node = node;
            Parent = parent;
        }
    }
}
