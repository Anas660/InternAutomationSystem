using StajyerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StajyerApp.Entities;
using System.Data.SqlClient;
using System.Data;
using StajyerApp.Dal.DataErisim;

namespace StajyerApp.Dal
{
    public class BolumDal : IBolum
    {

        public List<Bolum> BolumListe()
        {

            string spAdi = "BOLUM_SELECTLIST";
            List<Bolum> BolumList = new List<Bolum>();

            SQLManager komut = new SQLManager(spAdi);

            SqlDataReader sdr = komut.ExecuteReader();

            while (sdr.Read())
            {
                Bolum Bolum = new Bolum();
                Bolum.BolumId = Convert.ToInt32(sdr[0]);
                Bolum.BolumAdi = sdr[1].ToString();
                BolumList.Add(Bolum);
            }

            sdr.Close();
            komut.Clear();

            return BolumList;
        }//End-BolumListe

        private Bolum BolumBilgileriYukle(SqlDataReader sdr)
        {
            Bolum Bolum = new Bolum();
            Bolum.BolumId = SQLManager.GetValueInt32(sdr, "BolumId");
            Bolum.BolumAdi = SQLManager.GetValueString(sdr, "BolumAdi");
            return Bolum;
        }//End-BolumBilgileriYukle

        public int BolumInsert(Bolum BolumUp)
        {
            try
            {
                string spAdi = "BOLUM_INSERT";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@BOLUMADI", SqlDbType.VarChar, BolumUp.BolumAdi);

                int EtkilenenKayitSayisi = komut.Execute();
                komut.Clear();
                return EtkilenenKayitSayisi;
            }
            catch (Exception ex)
            { return -1; }

        }//End-BolumInsert

        public int BolumUpdate(Bolum Bolum)
        {
            try
            {
                string spAdi = "BOLUM_UPDATE";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@BOLUMADI", SqlDbType.VarChar, Bolum.BolumAdi);
                komut.ParameterAdd("@ID", SqlDbType.Int, Bolum.BolumId);

                int EtkilenenKayitSayisi = komut.Execute();

                komut.Clear();
                if (EtkilenenKayitSayisi != 0)
                {
                    return EtkilenenKayitSayisi;
                }
                else return -1;
            }
            catch (Exception es)
            { return -1; }
        }//End-BolumUpdate

        public int BolumDelete(Bolum Bolum)
        {
            try
            {
                string spAdi = "BOLUM_DELETE";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@ID", SqlDbType.Int, Bolum.BolumId);

                int EtkilenenKayitSayisi = komut.Execute();

                komut.Clear();
                if (EtkilenenKayitSayisi != 0)
                {
                    return EtkilenenKayitSayisi;
                }
                else return 0;
            }
            catch (Exception ex)
            { return 0; }
        }//End-BolumDelete
    }//End-BolumDal
}//End-Class
