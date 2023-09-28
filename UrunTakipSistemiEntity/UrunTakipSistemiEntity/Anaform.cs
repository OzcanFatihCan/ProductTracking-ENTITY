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
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }

        private void BtnKategori_Click(object sender, EventArgs e)
        {
            KategorilerForm fr = new KategorilerForm();
            fr.Show();
        }

        private void BtnUrun_Click(object sender, EventArgs e)
        {
            UrunForm fr = new UrunForm();
            fr.Show();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnStat_Click(object sender, EventArgs e)
        {
            istatistikForm fr = new istatistikForm();
            fr.Show();

        }

        private void BtnSatis_Click(object sender, EventArgs e)
        {
            SatisForm fr = new SatisForm();
            fr.Show();
        }
    }
}
