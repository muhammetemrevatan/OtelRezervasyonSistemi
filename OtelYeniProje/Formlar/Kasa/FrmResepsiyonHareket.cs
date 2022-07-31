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

namespace OtelYeniProje.Formlar.Kasa
{
    public partial class FrmResepsiyonHareket : Form
    {
        public FrmResepsiyonHareket()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();

        private void FrmResepsiyonHareket_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblKasaHareketis
                                       select new
                                       {
                                           x.ID,
                                           x.IslemAdı,
                                           x.Tarih,
                                           x.Tutar,
                                           x.Aciklama
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmResepsiyonGiris fr = new FrmResepsiyonGiris();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.BtnGuncelleChanged(true);
            fr.BtnKaydetChanged(false);
            this.Close();
            fr.Show();
        }
    }
}
