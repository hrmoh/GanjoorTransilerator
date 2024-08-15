using ganjoor;
using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;

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

                // 1 - poet
                if (dbOutput.GetPoet(poet._ID) == null)
                {
                    string poetName = Transilerator.Trasilerate(poet._Name);
                    dbOutput.NewPoet(poetName, poet._ID, poet._CatID);
                    string poetBio = Transilerator.Trasilerate(poet._Bio);
                    dbOutput.ModifyPoetBio(poet._ID, poetBio);
                }

                foreach(var catId in dbInput.GetAllSubCats(poet._CatID))
                {
                    var cat = dbInput.GetCategory(catId);
                    lblCat.Text = cat._Text;
                    Application.DoEvents();

                    // 2- cat
                    if(dbOutput.GetCategory(catId) == null)
                    {
                        string catText = Transilerator.Trasilerate(cat._Text);
                        dbOutput.CreateNewCategory(catText, cat._ParentID, cat._PoetID, catId);
                    }
                    

                    foreach (var poem in dbInput.GetPoems(catId))
                    {
                        lblPoem.Text = poem._Title;
                        Application.DoEvents();

                        //3- poem
                        if(dbOutput.GetPoem(poem._ID) == null)
                        {
                            string poemTitle = Transilerator.Trasilerate(poem._Title);
                            dbOutput.CreateNewPoem(poemTitle, catId, poem._ID);
                        }

                        var existingVerses = dbOutput.GetVerses(poem._ID);
                        if(existingVerses.Count > 0)
                        {
                            dbOutput.DeleteVerses(poem._ID, existingVerses.Select(v => v._Order).ToList());
                        }

                        foreach (var verse in dbInput.GetVerses(poem._ID))
                        {
                            lblVerse.Text = verse._Text;
                            Application.DoEvents();

                            //4-verse
                            dbOutput.CreateNewVerse(poem._ID, verse._Order - 1, verse._Position);
                            string verseText = Transilerator.Trasilerate(verse._Text);
                            dbOutput.SetVerseText(poem._ID, verse._Order, verseText);
                        }

                    }
                }
            }

            dbInput.CloseDb();
            MessageBox.Show("انجام شد.");
        }

        
    }
}
