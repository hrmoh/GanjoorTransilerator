using ganjoor;
using System;
using System.Windows.Forms;
using System.IO;

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

        private void btnSelectOutputDbFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "*.s3db|*.s3db";
                sfd.FileName = "output.s3db";
                sfd.OverwritePrompt = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFilePath.Text = sfd.FileName;
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DbBrowser dbOutput;
            if (File.Exists(txtOutputFilePath.Text))
            {
                dbOutput = new DbBrowser(txtOutputFilePath.Text);
            }
            else
            {
                dbOutput = DbBrowser.CreateNewPoemDatabase(txtOutputFilePath.Text, true);
            }
            if (dbOutput == null || !dbOutput.Connected)
            {
                MessageBox.Show("خطا در اتصال به پایگاه داده‌های خروجی");
                return;
            }

            DbBrowser dbInput = new DbBrowser(txtFilePath.Text);
            if(!dbInput.Connected)
            {
                MessageBox.Show("خطا در اتصال به پایگاه داده‌های ورودی");
                return;
            }
            var poets = dbInput.Poets;
            poets.Sort((a, b) => a._ID.CompareTo(b._ID)); 
            prgrss.Value = 0;
            prgrss.Maximum = poets.Count;
            foreach (var poet in poets)
            {
                prgrss.Value++;
                lblPoet.Text = poet._Name;
                Application.DoEvents();

                if (dbOutput.GetPoet(poet._ID) == null)
                {
                    dbOutput.NewPoet(poet._Name, poet._ID, poet._CatID);
                }

                foreach(var catId in dbInput.GetAllSubCats(poet._CatID))
                {
                    var cat = dbInput.GetCategory(catId);
                    lblCat.Text = cat._Text;
                    Application.DoEvents();

                    foreach (var poem in dbInput.GetPoems(catId))
                    {
                        lblPoem.Text = poem._Title;
                        Application.DoEvents();

                        foreach (var verse in dbInput.GetVerses(poem._ID))
                        {
                            lblVerse.Text = verse._Text;
                            Application.DoEvents();
                        }
                    }
                }
            }

            dbInput.CloseDb();
            MessageBox.Show("انجام شد.");
        }

        
    }
}
