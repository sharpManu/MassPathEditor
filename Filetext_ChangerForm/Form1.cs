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

namespace Filetext_ChangerForm
{
    public partial class MassFileChanger : Form
    {
        public MassFileChanger()
        {
            InitializeComponent();
        }

        FolderBrowserDialog fbd = new FolderBrowserDialog();
        FolderBrowserDialog fbd2 = new FolderBrowserDialog();
        DialogResult result, result2;
        string[] files;
        string sePath = "";
        string saPath = "";



        private void getPath()
        {
            result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                sePath = fbd.SelectedPath;
                files = Directory.GetFiles(sePath);
                tb_selectPath.Text = sePath;
                lb_AmountFiles.Text = files.Length.ToString() + " ausgewählte Dateien";
            }
            else
            {
                MessageBox.Show("Sie haben keine Datei ausgewählt!");
            }
        }

        private void setPath()
        {
            result2 = fbd2.ShowDialog();
            if (result2 == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                saPath = fbd2.SelectedPath;
                tb_savePath.Text = saPath;
            }
            else
            {
                MessageBox.Show("Sie haben keine Datei ausgewählt!");
            }
        }


        public void btn_ofd_Click(object sender, EventArgs e)
        {
            getPath();
        }

        private void btn_sfd_Click(object sender, EventArgs e)
        {
            setPath();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string file in files)
                {

                    MessageBox.Show(Path.GetFileName(file));
                    File.Copy(Path.GetFullPath(file), saPath + "//" + Path.GetFileName(file));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tb_selectPath.ReadOnly = true;
            }
            else
            {
                tb_selectPath.ReadOnly = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                tb_savePath.ReadOnly = true;
            }
            else
            {
                tb_savePath.ReadOnly = false;
            }
        }
    }
}

















