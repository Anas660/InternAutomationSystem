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
    public class OkulDal : IOkul
    {
        
        public List<Okul> OkulListe()
        {

            string spAdi = "OKUL_SELECTLIST";
            List<Okul> okulList = new List<Okul>();

            SQLManager komut = new SQLManager(spAdi);

            SqlDataReader sdr = komut.ExecuteReader();

            while (sdr.Read())
            {
                Okul okul = new Okul();
                okul.OkulId = Convert.ToInt32(sdr[0]);
                okul.OkulAdi = sdr[1].ToString();
                okulList.Add(okul);
            }

            sdr.Close();
            komut.Clear();

            return okulList;
        }//End-OkulListe

        private Okul OkulBilgileriYukle(SqlDataReader sdr)
        {
            Okul okul = new Okul();
            okul.OkulId = SQLManager.GetValueInt32(sdr, "OkulId");
            okul.OkulAdi = SQLManager.GetValueString(sdr, "OkulAdi");
            return okul;
        }//End-OkulBilgileriYukle

        public int OkulInsert(Okul okulUp)
        {
            try
            {
            string spAdi = "OKUL_INSERT";   
            SQLManager komut = new SQLManager(spAdi);

            komut.ParameterAdd("@OKULADI", SqlDbType.VarChar, okulUp.OkulAdi);

            int EtkilenenKayitSayisi = komut.Execute();
            komut.Clear();
            return EtkilenenKayitSayisi;
            }
            catch (Exception ex)
            { return -1; }

        }//End-OkulInsert

        public int OkulUpdate (Okul okul)
        {
            try
            {
                string spAdi = "OKUL_UPDATE";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@OKULADI", SqlDbType.VarChar, okul.OkulAdi);
                komut.ParameterAdd("@ID", SqlDbType.Int, okul.OkulId);

                int EtkilenenKayitSayisi = komut.Execute();

                komut.Clear();
                if (EtkilenenKayitSayisi != 0)
                {
                     return EtkilenenKayitSayisi;
                }
                else return -1;
            }
            catch (Exception ex)
            { return -1; }
        }//End-OkulUpdate
        
        public int OkulDelete(Okul okul)
        {
            try
            {
                string spAdi = "OKUL_DELETE";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@ID", SqlDbType.Int, okul.OkulId);

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
        }//End-OkulDelete
    }//End-OkulDal
}//End-Class
