using ganjoor;
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DbBrowser dbBrowser = new DbBrowser(txtFilePath.Text);
            if(!dbBrowser.Connected)
            {
                MessageBox.Show("خطا در اتصال به پایگاه داده‌ها");
                return;
            }
            var poets = dbBrowser.Poets;
            poets.Sort((a, b) => a._ID.CompareTo(b._ID)); 
            prgrss.Value = 0;
            prgrss.Maximum = poets.Count;
            foreach (var poet in poets)
            {
                prgrss.Value++;
                lblPoet.Text = poet._Name;
                Application.DoEvents();

                foreach(var catId in dbBrowser.GetAllSubCats(poet._CatID))
                {
                    var cat = dbBrowser.GetCategory(catId);
                    lblCat.Text = cat._Text;
                    Application.DoEvents();

                    foreach (var poem in dbBrowser.GetPoems(catId))
                    {
                        lblPoem.Text = poem._Title;
                        Application.DoEvents();

                        foreach (var verse in dbBrowser.GetVerses(poem._ID))
                        {
                            lblVerse.Text = verse._Text;
                            Application.DoEvents();
                        }
                    }
                }
            }

            dbBrowser.CloseDb();
            MessageBox.Show("انجام شد.");
        }
    }
}
