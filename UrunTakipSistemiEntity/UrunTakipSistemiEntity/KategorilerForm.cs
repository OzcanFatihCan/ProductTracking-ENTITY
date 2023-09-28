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
    public partial class KategorilerForm : Form
    {
        public KategorilerForm()
        {
            InitializeComponent();
        }
        DbEntityUrunTakipEntities db = new DbEntityUrunTakipEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }).ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (Txtad.Text != "")
            {
                TBLKATEGORI TKategori = new TBLKATEGORI();
                TKategori.AD = Txtad.Text;
                db.TBLKATEGORI.Add(TKategori);
                db.SaveChanges();
                MessageBox.Show("Ekleme yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Boş hücre bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Txtid.Text != "")
            {
                int x = Convert.ToInt32(Txtid.Text);
                var KategoriSil = db.TBLKATEGORI.Find(x);
                db.TBLKATEGORI.Remove(KategoriSil);
                db.SaveChanges();
                MessageBox.Show("Kategori silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategoriyi silmek için seçim yapınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (Txtid.Text != "" && Txtad.Text!="")
            {
                int x = Convert.ToInt32(Txtid.Text);
                var KategoriGuncelle = db.TBLKATEGORI.Find(x);
                KategoriGuncelle.AD = Txtad.Text;
                db.SaveChanges();
                MessageBox.Show("Kategori güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategoriyi güncellemek için seçim yapınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Txtad.Text = "";
            Txtid.Text = "";
        }
    }
}
