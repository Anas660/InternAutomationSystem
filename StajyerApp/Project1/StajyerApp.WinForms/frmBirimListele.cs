using DevExpress.XtraGrid.Columns;
using StajyerApp.Bll;
using StajyerApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajyerApp.WinForms
{
    public partial class frmBirimListele : Form
    {
        public frmBirimListele()
        {
            InitializeComponent();
        }

        public int DepartmanId;
        public string DepartmanAdi;

        private void frmBirimListele_Load(object sender, EventArgs e)
        {
            BirimListele();
        }
        private void BirimListele()
        {
            BirimManager Birim = new BirimManager();
            List<Birim> BirimListesi = Birim.BirimListe();
            gcBirimList.DataSource = BirimListesi;
            gvBirimList.BestFitColumns();
        }

        public delegate void AddressUpdateHandler(object sender, AddressUpdateEventArgs e);

        // add an event of the delegate type
        public event AddressUpdateHandler AddressUpdated;
        private void gvBirimList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DepartmanId = Convert.ToInt32(gvBirimList.GetRowCellValue(gvBirimList.FocusedRowHandle, "DepartmanId"));
            DepartmanAdi = gvBirimList.GetRowCellValue(gvBirimList.FocusedRowHandle, "DepartmanAdi").ToString();

            AddressUpdateEventArgs args =
                new AddressUpdateEventArgs(DepartmanId,DepartmanAdi);

            AddressUpdated(this, args);

            this.Dispose();
            
        }

        private void gvBirimList_ShowingEditor(object sender, CancelEventArgs e)
        {
 
        }

        private void gvBirimList_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            
        }

        private void gcBirimList_Click(object sender, EventArgs e)
        {

        }
    }
}
