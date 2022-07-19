using OtelYeniProje.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYeniProje.Formlar.Urun
{
    public partial class FrmUrunCikisHareketleri : Form
    {
        public FrmUrunCikisHareketleri()
        {
            InitializeComponent();
        }

        DbOtelEntities2 db = new DbOtelEntities2();
        private void FrmUrunCikisHareketleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from field in db.TblUrunHarekets
                                       select new
                                       {
                                           field.HareketID,
                                           field.TblUrun.UrunAd,
                                           field.Miktar,
                                           field.Tarih,
                                           field.HareketTuru
                                       }).Where(x => x.HareketTuru == "Çıkış").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunHareketTanimi fr = new FrmUrunHareketTanimi();
            fr.BtnGunncelleVisibled(true);
            fr.BtnKaydetVisibled(false);
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("HareketID").ToString());
            fr.Show();
            this.Close();
        }
    }
}
