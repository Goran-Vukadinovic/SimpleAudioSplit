using CSCore;
using CSCore.Codecs;
using CSCore.Codecs.WAV;
using System.Buffers;
using System.Diagnostics;
using System.Threading.Channels;
using System.Windows.Forms;

namespace AudioCorpusTools
{
    public partial class Form1 : Form
    {
        string strSrcPath = "";
        string strDstPath = "";
        int nStartNumber = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSrcFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                tbSrc.Text = folderName;
                
            }
        }

        private void btnDstFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                tbDst.Text = folderName;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            strSrcPath = tbSrc.Text;
            strDstPath = tbDst.Text;
            nStartNumber = int.Parse(tbStartNumber.Text);
            if (strSrcPath == "" || strDstPath == "")
            {
                MessageBox.Show("Input source folder and destination folder", "Error");
                return;
            }
            string[] files = Directory.GetFiles(strSrcPath, "*.wav", SearchOption.AllDirectories);
            for(int i = 0; i < files.Length; i++)
            {
                string strSrcFile = files[i];
                string strDstFile = strDstPath + "\\" + nStartNumber.ToString() + Path.GetExtension(strSrcFile);
                File.Copy(strSrcFile, strDstFile, true);
                nStartNumber++;
            }
        }
    }
}