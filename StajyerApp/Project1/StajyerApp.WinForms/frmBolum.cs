﻿using StajyerApp.Bll;
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
    public partial class frmBolum : Form
    {
        public static int BolumID;
        public frmBolum()
        {
            InitializeComponent();
        }


        private void frmBolum_Load(object sender, EventArgs e)
        {
            BolumListele();
        }
        private void BolumListele()
        {
            BolumManager Bolum = new BolumManager();
            List<Bolum> BolumListesi = Bolum.BolumListe();
            gcBolum.DataSource = BolumListesi;
            gvBolum.BestFitColumns();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Bolum Bolum1 = new Bolum();
            Bolum1.BolumAdi = editBolum.Text;

            BolumManager Bolum = new BolumManager();

            if (Bolum.BolumInsert(Bolum1) != 0)
            {
                BolumListele();

                MessageBox.Show("Bolum ekleme işlemi başarılı!!");
            }
            else
            {
                MessageBox.Show("Bolum eklerken bir hata meydana geldi lütfen destek talep ediniz.");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            editBolum.ResetText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Bolum Bolum1 = new Bolum();
            Bolum1.BolumAdi = editBolum.Text;
            Bolum1.BolumId = BolumID;
            BolumManager BolumUpdate = new BolumManager();

            if (BolumUpdate.BolumUpdate(Bolum1) != 0)
            {
                BolumListele();

                MessageBox.Show("Bolum bilgileri guncellestirildi!!");
            }
            else
            {
                MessageBox.Show("Bolum guncellestirirken bir hata meydana geldi lütfen destek talep ediniz.Hata kodu : #98565");
            }
        }

        private void gvBolum_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            BolumID = Convert.ToInt32(gvBolum.GetRowCellValue(gvBolum.FocusedRowHandle, "BolumId"));
            editBolum.Text = gvBolum.GetRowCellValue(gvBolum.FocusedRowHandle, "BolumAdi").ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Bolum Bolum = new Bolum();
            Bolum.BolumId = BolumID;
            BolumManager BolumManager = new BolumManager();
            if (BolumManager.BolumDelete(Bolum) != 0)
            {
                BolumListele();
                MessageBox.Show("Bolum silindi !!");
            }
            else
            {
                MessageBox.Show("Bolum silinirken bir hata meydana geldi lütfen destek talep ediniz.Hata kodu : #98565");
            }
        }

 
    }
}
