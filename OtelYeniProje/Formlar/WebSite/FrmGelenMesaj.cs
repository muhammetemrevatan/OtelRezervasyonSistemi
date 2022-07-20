using OtelYeniProje.Entities;
using OtelYeniProje.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYeniProje.Formlar.WebSite
{
    public partial class FrmGelenMesaj : Form
    {

        DbOtelEntities2 dbEntities1 = new DbOtelEntities2();
        Repository<TblMesaj2> repo = new Repository<TblMesaj2>();
        public int id;

        public FrmGelenMesaj()
        {
            InitializeComponent();
        }

        private void FrmGelenMesaj_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in dbEntities1.TblMesaj2
                                       select new
                                       {
                                           x.MesajID,
                                           x.Gonderen,
                                           x.Konu,
                                           x.Tarih,
                                           x.Alici
                                       }).Where(y => y.Alici == "Admin").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMesajKarti fr = new FrmMesajKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("MesajID").ToString());
            fr.Show();
        }
    }
}
