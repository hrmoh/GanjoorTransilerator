using System;
using System.Windows.Forms;

namespace GanjoorTransilerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelectDbFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.s3db|*.s3db";
                ofd.FileName = "ganjoor.s3db";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                }
            }

        }
    }
}
