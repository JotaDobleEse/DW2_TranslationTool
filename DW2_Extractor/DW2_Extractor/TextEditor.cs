using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DW2_Extractor
{
    public partial class TextEditor : Form
    {
        private Dictionary<string, string[]> Dialogs;
        public TextEditor()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Plain text file|*.txt|Todos los ficheros|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                GenerateTree(Controller.Instance.ReadFile(openFileDialog.FileName));
            }
        }

        private void GenerateTree(string text)
        {
            Dialogs = new Dictionary<string, string[]>();
            dialogTree.Nodes.Clear();
            var dialogs = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var dialog in dialogs)
            {
                var name = dialog.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[0];
                var messages = dialog.Replace(name,"").Split(new string[] { "<Window>" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray();
                Dialogs.Add(name, messages);
                int i = 0;
                dialogTree.Nodes.Add(name).Nodes.AddRange(messages.Select(s => new TreeNode(string.Format("Window {0}", ++i)) { Tag = i }).ToArray());
            }
        }

        private void dialogTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node == null)
                return;
            if (node.Parent == null)
                return;
            string text = Dialogs[node.Parent.Text][(int)node.Tag - 1];
            originalText.Text = text.Replace("\n", "\r\n");
        }
    }
}
