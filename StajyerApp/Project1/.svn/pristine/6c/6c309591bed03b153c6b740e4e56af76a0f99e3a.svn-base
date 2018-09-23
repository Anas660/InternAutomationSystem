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
    public partial class frmStajyer : Form
    {
        private int departmanId, index1, index2, stajyerId;
        frmBirimListele frmBirim;
        private List<Int32> BolumId,OkulId;
        public frmStajyer()
        {
            InitializeComponent();
        }

        private void StajyerListele()
        {

            StajyerManager stajyer = new StajyerManager();
            List<Stajyer> StajyerListesi = stajyer.StajyerListe();
            gcStajyer.DataSource = StajyerListesi;
        }

        private void frmStajyer_Load(object sender, EventArgs e)
        {
            StajyerListele();

            BolumId = new List<Int32>();
            OkulId = new List<Int32>();

            gvStajyer.Columns[0].Visible = false;
            gvStajyer.Columns[15].Visible = false;
            gvStajyer.Columns[16].Visible = false;
            gvStajyer.Columns[17].Visible = false;

            OkulManager okul = new OkulManager();
            List<Okul> OkulListe = okul.OkulListe();
            foreach (Okul okul1 in OkulListe)
            {
                cmbOkul.Properties.Items.Add(okul1.OkulAdi);
                OkulId.Add(okul1.OkulId);
            }

            BolumManager bolum = new BolumManager();
            List<Bolum> BolumListe = bolum.BolumListe();
            foreach (Bolum bolum1 in BolumListe)
            {
                cmbBolum.Properties.Items.Add(bolum1.BolumAdi);
                BolumId.Add(bolum1.BolumId);
            }



            gvStajyer.BestFitColumns();

        }
         bool formOpen = false;
        
        private void btnBirim_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmBirimListele")
                {
                    formOpen = true;
                    break;
                }
                else {
                frmBirim = new frmBirimListele();
                frmBirim.AddressUpdated += new frmBirimListele.AddressUpdateHandler(AddressForm_ButtonClicked);
                frmBirim.Show();
                formOpen = false;
                break; }
            }
            if (formOpen)
            {
                MessageBox.Show("Birim Listesi Açık");
            }
            else
            {
                formOpen = true;
            }
            
        }
        private void AddressForm_ButtonClicked(object sender,
                            AddressUpdateEventArgs e)
        {
            // update the forms values from the event args
            btnBirim.Text = e.DepartmanAdi;
            departmanId = e.DepartmanId;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            editAdi.ResetText();
            editSoyadi.ResetText();
            editTel.ResetText();
            editTC.ResetText();
            editSicil.ResetText();
            editEmail.ResetText();
            editDogumYeri.ResetText();
            editAdress.ResetText();
            cmbBaslangic.ResetText();
            cmbBitis.ResetText();
            cmbBolum.ResetText();
            cmbDT.ResetText();
            cmbOkul.ResetText();
            btnBirim.ResetText();
        }

        private void cmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            index2 = cmbBolum.SelectedIndex;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Stajyer stajyer1 = new Stajyer();
                stajyer1.Adi = editAdi.Text;
                stajyer1.Soyadi = editSoyadi.Text;
                stajyer1.TcNo = (editTC.Text);
                stajyer1.DogumYeri = editDogumYeri.Text;
                stajyer1.DogumTarihi = Convert.ToDateTime(cmbDT.Text);
                stajyer1.Adres = editAdress.Text;
                stajyer1.OkulAdi = cmbOkul.Text;
                stajyer1.BolumAdi = cmbBolum.Text;
                stajyer1.Telefon = (editTel.Text);
                stajyer1.Email = editEmail.Text;
                stajyer1.BaslamaTarihi = Convert.ToDateTime(cmbBaslangic.Text);
                stajyer1.BitisTarihi = Convert.ToDateTime(cmbBitis.Text);
                stajyer1.SicilNo = editSicil.Text;
                stajyer1.DepartmanAdi = btnBirim.Text;
                stajyer1.BolumId = BolumId.ElementAt(index2);
                stajyer1.OkulId = OkulId.ElementAt(index1);
                stajyer1.DepartmanId = departmanId;


                StajyerManager stajyer = new StajyerManager();

                if (stajyer.StajyerInsert(stajyer1) != 0)
                {
                    //anlık sayısı artır.
                    int res = stajyer.AnlikSayiArtir(stajyer1.DepartmanId);
                    StajyerListele();

                    MessageBox.Show("Stajyer ekleme işlemi başarılı!!");
                }
                else
                {
                    MessageBox.Show("Stajyer eklerken bir hata meydana geldi lütfen destek talep ediniz.");
                }
            }
            catch
            {
                    MessageBox.Show("Ekleme sırasında bir Hata oluştu!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Stajyer stjr = new Stajyer();
                stjr.StajyerId = stajyerId;
                stjr.DepartmanId = departmanId;
                StajyerManager stjrMngr = new StajyerManager();
                if (stjrMngr.StajyerDelete(stjr) != 0)
                {
                    int res = stjrMngr.AnlikSayiAzalt(stjr.DepartmanId);
                    StajyerListele();
                    MessageBox.Show("Stajyer silindi !!!");
                }
                else
                {
                    MessageBox.Show("Stajyer silinirken bir hata meydana geldi lütfen destek talep ediniz.Hata kodu : #98565");
                }
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Stajyer stajyer1 = new Stajyer();
                stajyer1.StajyerId = stajyerId;
                stajyer1.Adi = editAdi.Text;
                stajyer1.Soyadi = editSoyadi.Text;
                stajyer1.TcNo = (editTC.Text);
                stajyer1.DogumYeri = editDogumYeri.Text;
                stajyer1.DogumTarihi = Convert.ToDateTime(cmbDT.Text);
                stajyer1.Adres = editAdress.Text;
                stajyer1.Telefon = (editTel.Text);
                stajyer1.Email = editEmail.Text;
                stajyer1.BaslamaTarihi = Convert.ToDateTime(cmbBaslangic.Text);
                stajyer1.BitisTarihi = Convert.ToDateTime(cmbBitis.Text);
                stajyer1.SicilNo = editSicil.Text;
                stajyer1.BolumId = BolumId.ElementAt(index2);
                stajyer1.OkulId = OkulId.ElementAt(index1);
                stajyer1.DepartmanId = departmanId;


                StajyerManager stajyer = new StajyerManager();

                if (stajyer.StajyerUpdate(stajyer1) != 0)
                {
                    StajyerListele();

                    MessageBox.Show("Stajyer güncelleme işlemi başarılı!!");
                }
                else
                {
                    MessageBox.Show("Stajyer güncellerken bir hata meydana geldi lütfen destek talep ediniz.");
                }
            }
            catch
            {
                MessageBox.Show("Güncelleme sırasında bir Hata oluştu!");
            }
        }

        private void gvStajyer_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                stajyerId = Convert.ToInt32(gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "StajyerId"));
                editAdi.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "Adi").ToString();
                editSoyadi.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "Soyadi").ToString();
                editTel.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "Telefon").ToString();
                editEmail.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "Email").ToString();
                editAdress.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "Adres").ToString();
                editDogumYeri.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "DogumYeri").ToString();
                cmbDT.Text = Convert.ToDateTime(gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "DogumTarihi")).ToString("dd/MM/yyyy");
                editTC.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "TcNo").ToString();
                editSicil.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "SicilNo").ToString();
                cmbBaslangic.Text = Convert.ToDateTime(gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "BaslamaTarihi")).ToString("dd/MM/yyyy");
                cmbBitis.Text = Convert.ToDateTime(gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "BitisTarihi")).ToString("dd/MM/yyyy");
                cmbOkul.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "OkulAdi").ToString();
                cmbBolum.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "BolumAdi").ToString();
                btnBirim.Text = gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "DepartmanAdi").ToString();
                departmanId = Convert.ToInt32(gvStajyer.GetRowCellValue(gvStajyer.FocusedRowHandle, "DepartmanId"));
            }
            catch
            {

            }

        }

        private void frmStajyer_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                gvStajyer.BestFitColumns();
            }
            catch
            {

            }
        }

        private void cmbOkul_SelectedIndexChanged(object sender, EventArgs e)
        {
            index1 = cmbOkul.SelectedIndex;
            
        }


    }
}
