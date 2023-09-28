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
    public partial class SatisForm : Form
    {
        public SatisForm()
        {
            InitializeComponent();
        }
        DbEntityUrunTakipEntities db=new DbEntityUrunTakipEntities();
        private void SiparisForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLSATIS
                                           select new
                                           {
                                            x.SATISID,
                                            x.TBLURUN.URUNAD,
                                            MusteriAdSoyad = x.TBLMUSTERI.MUSTERIAD + " " + x.TBLMUSTERI.MUSTERISOYAD,
                                            x.FIYAT,
                                            x.TARIH
                                           }).ToList();
        }
    }
}
