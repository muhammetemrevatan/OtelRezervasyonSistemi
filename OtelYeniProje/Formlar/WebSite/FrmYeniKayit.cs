using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelYeniProje.Entities;

namespace OtelYeniProje.Formlar.WebSite
{
    public partial class FrmYeniKayit : Form
    {
        public FrmYeniKayit()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        private void FrmYeniKayit_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblYeniKayits select new {
                x.AdSoyad,
                x.Mail,
                x.Telefon
            }).ToList();
        }
    }
}
