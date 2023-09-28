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
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }
        DbEntityUrunTakipEntities db = new DbEntityUrunTakipEntities();
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

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.TBLADMIN where x.KULLANICI == textBox1.Text && x.SIFRE == textBox2.Text select x;
            if (sorgu.Any())//sorgudaki şartlar sağlanırsa any true döndürür
            {
                Anaform fr = new Anaform();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
