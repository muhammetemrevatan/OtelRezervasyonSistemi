using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelYeniProje.Entities;

namespace OtelYeniProje.Formlar.Admin
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            var kullanici = db.TblAdmins.Where(x => x.Kullanici == TxtKullanici.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
            if (kullanici != null)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide(); // Giriş formu gizlendi.
            }
            else
            {
                XtraMessageBox.Show("Kullanici Adı ve Sifre Yanlıs!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
        }
    }
}
