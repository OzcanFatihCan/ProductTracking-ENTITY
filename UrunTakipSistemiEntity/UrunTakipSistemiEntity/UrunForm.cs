using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunTakipSistemiEntity
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }
        DbEntityUrunTakipEntities db=new DbEntityUrunTakipEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.TBLKATEGORI.AD,
                                            x.DURUM
                                        }).ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (Txtad.Text != "" && TxtMarka.Text!="" && TxtStok.Text!="" && CmbKategori.Text!="" && TxtFiyat.Text!="" )
            {
                try
                {
                    TBLURUN TUrun = new TBLURUN();
                    TUrun.URUNAD = Txtad.Text;
                    TUrun.MARKA = TxtMarka.Text;
                    TUrun.STOK = short.Parse(TxtStok.Text);
                    TUrun.KATEGORI = int.Parse(CmbKategori.SelectedValue.ToString());
                    TUrun.FIYAT = decimal.Parse(TxtFiyat.Text);
                    TUrun.DURUM = true;
                    db.TBLURUN.Add(TUrun);
                    db.SaveChanges();
                    MessageBox.Show("Ekleme yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Stok ve Fiyat hücreleri sayısal olmalıdır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            else
            {
                MessageBox.Show("Boş hücre bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Txtad.Text = "";
            TxtFiyat.Text = "";
            Txtid.Text = "";
            TxtMarka.Text = "";
            TxtStok.Text = "";
            TxtDurum.Text = "";
            CmbKategori.Text = "";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Txtid.Text != "")
            {
                int x = Convert.ToInt32(Txtid.Text);
                var UrunSil = db.TBLURUN.Find(x);
                db.TBLURUN.Remove(UrunSil);
                db.SaveChanges();
                MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ürünü silmek için seçim yapınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (Txtid.Text != "" && Txtad.Text != "" && TxtMarka.Text != "" && TxtStok.Text != "" && CmbKategori.Text != "" && TxtFiyat.Text != "")
            {
                try
                {
                    int x = Convert.ToInt32(Txtid.Text);
                    var UrunGuncelle = db.TBLURUN.Find(x);
                    UrunGuncelle.URUNAD = Txtad.Text;
                    UrunGuncelle.STOK = short.Parse(TxtStok.Text);
                    UrunGuncelle.MARKA = TxtMarka.Text;
                    UrunGuncelle.FIYAT = decimal.Parse(TxtFiyat.Text);
                    db.SaveChanges();
                    MessageBox.Show("Ürün güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Stok ve Fiyat hücreleri sayısal olmalıdır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ürünü güncellemek için seçim yapınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI 
                               select new 
                               {
                                   x.ID, 
                                   x.AD
                               }
                               ).ToList();
            CmbKategori.ValueMember = "ID";
            CmbKategori.DisplayMember = "AD";
            CmbKategori.DataSource= kategoriler;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            CmbKategori.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }
    }
}
