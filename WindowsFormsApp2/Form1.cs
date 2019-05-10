using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string currentFile;
        public Form1()
        {
            InitializeComponent();
            txtBox.Enabled = false;
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtBox.Text = File.ReadAllText(dialog.FileName, Encoding.Default);
                currentFile = dialog.FileName;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Form2 editForm = new Form2(txtBox.Text);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                txtBox.Text = editForm.TText;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            File.WriteAllText(currentFile, txtBox.Text, Encoding.Default);
        }
    }
}
