using StajyerApp.Dal.DataErisim;
using StajyerApp.Entities;
using StajyerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajyerApp.Dal
{
 public   class BirimDal : IBirim
    {
        public List<Birim> BirimListe()
        {

            string spAdi = "BIRIM_SELECTLIST";
            List<Birim> birimlist = new List<Birim>();

            SQLManager komut = new SQLManager(spAdi);

            SqlDataReader sdr = komut.ExecuteReader();

            while (sdr.Read())
            {
                Birim birim = new Birim();
                birim.DepartmanId = Convert.ToInt32(sdr[0]);
                birim.DepartmanAdi = sdr[1].ToString();
                birim.AnlikSayi = Convert.ToInt32(sdr[2]);
                birim.KontenjanSayisi = Convert.ToInt32(sdr[3]);
                birimlist.Add(birim);
            }

            sdr.Close();
            komut.Clear();

            return birimlist;
        }

    }
}
