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
        private TimeSpan ConverToTimeSpan(string strTime)
        {
            string[] aryPart = strTime.Split(",");
            if(aryPart.Length != 2)
            {
                MessageBox.Show("Error in parsing time", "Error");
                return TimeSpan.Zero;
            }
            TimeSpan tmpTime = TimeSpan.Parse(aryPart[0]);
            int nMs = int.Parse(aryPart[1]);
            return tmpTime.Add(new TimeSpan(0, 0, 0, 0, nMs)); ;
        }
        private void SplitAndSave(string strAudioFile, TimeSpan from, TimeSpan to, string strSaveFile)
        {
            int samplerate = 22050;
            int bits = 16;
            IWaveSource source = CodecFactory.Instance.GetCodec(strAudioFile);
            source = source.ChangeSampleRate(samplerate).ToSampleSource().ToWaveSource(bits);
            source = source.ToMono();
            WaveWriter writer = new WaveWriter(strSaveFile, source.WaveFormat);
            TimeSpan FileTimeLength = TimeSpan.FromSeconds(0.0);
            FileTimeLength = source.GetLength();
            byte[] buffer = new byte[source.WaveFormat.BytesPerSecond / 10];
            source.SetPosition(from);
            bool bTo = false;
            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0 && !bTo)
            {
                int nCompare = TimeSpan.Compare(source.GetPosition(), to);
                if (nCompare == 0 || nCompare == 1)
                {
                    bTo = true;
                }
                writer.Write(buffer, 0, read);
            }
            source.Dispose();
            source = null;
            writer.Dispose();
            writer = null;
        }
        private void DoProcess(string strSrtFile)
        {
            int nLineFormat = 0;
            int nSentenceIndex = 0;
            string strAudioFile = Path.GetDirectoryName(strSrtFile) + "\\" + Path.GetFileNameWithoutExtension(strSrtFile) + ".m4a";
            foreach (string strLine in File.ReadLines(strSrtFile))
            {
                if(nLineFormat == 1)
                {
                    if (cmbSkip2Sentence.Checked && nSentenceIndex < 2)
                    {
                        nLineFormat++;
                        nSentenceIndex++;
                        continue;
                    }
                    string[] aryParts = strLine.Split(" --> ");
                    if(aryParts.Length != 2)
                    {
                        MessageBox.Show("Error in parsing SRT file", "Error");
                        return;
                    }
                    string strFrom = aryParts[0];
                    string strTo = aryParts[1];
                    TimeSpan from = ConverToTimeSpan(strFrom);
                    //from = from.Subtract(new TimeSpan(0, 0, 0, 0, 100));
                    if(from.TotalSeconds < 0) from = TimeSpan.Zero;
                    TimeSpan to = ConverToTimeSpan(strTo);
                    to = to.Add(new TimeSpan(0, 0, 0, 0, 150));
                    string strSaveFile = strDstPath + "\\" + nStartNumber.ToString() + ".wav";
                    SplitAndSave(strAudioFile, from, to, strSaveFile);
                    nSentenceIndex++;
                    nStartNumber++;
                }
                nLineFormat++;
                nLineFormat = nLineFormat % 4;
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
            string[] files = Directory.GetFiles(strSrcPath, "*.srt", SearchOption.AllDirectories);
            for(int i = 0; i < files.Length; i++)
            {
                string strFile = files[i];
                DoProcess(strFile);
            }
        }
    }
}