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
    public partial class istatistikForm : Form
    {
        public istatistikForm()
        {
            InitializeComponent();
        }
        DbEntityUrunTakipEntities db=new DbEntityUrunTakipEntities();
        private void istatistikForm_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString();
            label3.Text = db.TBLURUN.Count().ToString();
            label5.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            label15.Text= db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label11.Text = db.TBLURUN.Sum(k=>k.STOK).ToString();
            label7.Text = db.TBLSATIS.Sum(c => c.FIYAT).ToString() + " TL";
            label23.Text=(from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label21.Text = (from k in db.TBLURUN orderby k.FIYAT ascending select k.URUNAD).FirstOrDefault();
            label13.Text = db.TBLURUN.Count(x => x.KATEGORI == 2).ToString();
            //label17.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();//toplam buzdolabı sayısı
            label17.Text=db.STOKMARKAMAX().FirstOrDefault();
            label19.Text=(from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label9.Text = db.MARKAGETIR().FirstOrDefault();
        }
    }
}
