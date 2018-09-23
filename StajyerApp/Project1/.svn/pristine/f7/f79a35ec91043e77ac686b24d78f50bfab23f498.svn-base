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
    public class StajyerDal : IStajyer
    {
        public List<Stajyer> StajyerListe()
        {
            string spAdi = "STAJYER_SELECTLIST";
            List<Stajyer> stajyerList = new List<Stajyer>();

            SQLManager komut = new SQLManager(spAdi);

            SqlDataReader sdr = komut.ExecuteReader();

            while (sdr.Read())
            {
                Stajyer staj = new Stajyer();
                staj.StajyerId = Convert.ToInt32(sdr[0]);
                staj.OkulId = Convert.ToInt32(sdr[1]);
                staj.OkulAdi = sdr[2].ToString();
                staj.BolumId = Convert.ToInt32(sdr[3]);
                staj.BolumAdi = sdr[4].ToString();
                staj.Adi = sdr[5].ToString();
                staj.Soyadi = sdr[6].ToString();
                staj.Telefon = sdr[7].ToString();
                staj.Email = sdr[8].ToString();
                staj.Adres = sdr[9].ToString();
                staj.DogumYeri = sdr[10].ToString();
                staj.DogumTarihi = Convert.ToDateTime(sdr[11]);
                staj.TcNo = sdr[12].ToString();
                staj.SicilNo = sdr[13].ToString();
                staj.BaslamaTarihi = Convert.ToDateTime(sdr[14]);
                staj.BitisTarihi = Convert.ToDateTime(sdr[15]);
                staj.DepartmanId = Convert.ToInt32(sdr[16]);
                staj.DepartmanAdi = sdr[17].ToString();


                stajyerList.Add(staj);
            }

            sdr.Close();
            komut.Clear();

            return stajyerList;
        }


        public Stajyer StajyerBilgileriYukle(SqlDataReader sdr)
        {
            Stajyer stajyer = new Stajyer();
            stajyer.StajyerId = SQLManager.GetValueInt32(sdr, "StajyerId");
            stajyer.OkulId = SQLManager.GetValueInt32(sdr, "OkulId");
            stajyer.OkulAdi = SQLManager.GetValueString(sdr, "OkulAdi");
            stajyer.BolumId = SQLManager.GetValueInt32(sdr, "BolumId");
            stajyer.BolumAdi = SQLManager.GetValueString(sdr, "BolumAdi");
            stajyer.Adi = SQLManager.GetValueString(sdr, "Adi");
            stajyer.Soyadi = SQLManager.GetValueString(sdr, "Soyadi");
            stajyer.Telefon = SQLManager.GetValueString(sdr, "Telefon");
            stajyer.Email = SQLManager.GetValueString(sdr, "Email");
            stajyer.Adres = SQLManager.GetValueString(sdr, "Adres");
            stajyer.DogumYeri = SQLManager.GetValueString(sdr, "DogumYeri");
            stajyer.DogumTarihi = SQLManager.GetValueDateTime(sdr, "DogumTarihi");
            stajyer.TcNo = SQLManager.GetValueString(sdr, "TcNo");
            stajyer.SicilNo = SQLManager.GetValueString(sdr, "SicilNo");
            stajyer.BaslamaTarihi = SQLManager.GetValueDateTime(sdr, "BaslamaTarihi");
            stajyer.BitisTarihi = SQLManager.GetValueDateTime(sdr, "BitisTarihi");
            stajyer.DepartmanId = SQLManager.GetValueInt32(sdr, "DepartmanId");
            stajyer.DepartmanAdi = SQLManager.GetValueString(sdr, "DepartmanAdi");



            return stajyer;
        }//End-StajyerBilgileriYukle

        public int StajyerInsert(Stajyer stajyerUp)
        {
            try
            {
                string spAdi = "STAJYER_INSERT";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@STAJYERADI", SqlDbType.VarChar, stajyerUp.Adi);
                komut.ParameterAdd("@STAJYERSOYADI", SqlDbType.VarChar, stajyerUp.Soyadi);
                komut.ParameterAdd("@TELEFON", SqlDbType.VarChar, stajyerUp.Telefon);
                komut.ParameterAdd("@EMAIL", SqlDbType.VarChar, stajyerUp.Email);
                komut.ParameterAdd("@ADRES", SqlDbType.VarChar, stajyerUp.Adres);
                komut.ParameterAdd("@DOGUMYERI", SqlDbType.VarChar, stajyerUp.DogumYeri);
                komut.ParameterAdd("@DOGUMTARIHI", SqlDbType.VarChar, stajyerUp.DogumTarihi);
                komut.ParameterAdd("@TCNO", SqlDbType.VarChar, stajyerUp.TcNo);
                komut.ParameterAdd("@SICILNO", SqlDbType.VarChar, stajyerUp.SicilNo);
                komut.ParameterAdd("@BASLAMATARIHI", SqlDbType.VarChar, stajyerUp.BaslamaTarihi);
                komut.ParameterAdd("@BITISTARIHI", SqlDbType.VarChar, stajyerUp.BitisTarihi);
                komut.ParameterAdd("@DEPARTMANID", SqlDbType.Int, stajyerUp.DepartmanId);
                komut.ParameterAdd("@OKULID", SqlDbType.Int, stajyerUp.OkulId);
                komut.ParameterAdd("@BOLUMID", SqlDbType.Int, stajyerUp.BolumId);

                int EtkilenenKayitSayisi = komut.Execute();
                komut.Clear();
                return EtkilenenKayitSayisi;
            }
            catch (Exception es)
            { return -1; }

        }//End-StajyerInsert

        public int StajyerUpdate(Stajyer stajyer)
        {
            try
            {
                string spAdi = "STAJYER_UPDATE";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@STAJYERID", SqlDbType.Int,stajyer.StajyerId);
                komut.ParameterAdd("@STAJYERADI", SqlDbType.VarChar, stajyer.Adi);
                komut.ParameterAdd("@STAJYERSOYADI", SqlDbType.VarChar, stajyer.Soyadi);
                komut.ParameterAdd("@TELEFON", SqlDbType.VarChar, stajyer.Telefon);
                komut.ParameterAdd("@EMAIL", SqlDbType.VarChar, stajyer.Email);
                komut.ParameterAdd("@ADRES", SqlDbType.VarChar, stajyer.Adres);
                komut.ParameterAdd("@DOGUMYERI", SqlDbType.VarChar, stajyer.DogumYeri);
                komut.ParameterAdd("@DOGUMTARIHI", SqlDbType.VarChar, stajyer.DogumTarihi);
                komut.ParameterAdd("@TCNO", SqlDbType.VarChar, stajyer.TcNo);
                komut.ParameterAdd("@SICILNO", SqlDbType.VarChar, stajyer.SicilNo);
                komut.ParameterAdd("@BASLAMATARIHI", SqlDbType.VarChar, stajyer.BaslamaTarihi);
                komut.ParameterAdd("@BITISTARIHI", SqlDbType.VarChar, stajyer.BitisTarihi);
                komut.ParameterAdd("@DEPARTMANID", SqlDbType.Int, stajyer.DepartmanId);
                komut.ParameterAdd("@OKULID", SqlDbType.Int, stajyer.OkulId);
                komut.ParameterAdd("@BOLUMID", SqlDbType.Int, stajyer.BolumId);

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
        }//End-StajyerUpdate

        public int StajyerDelete(Stajyer stajyer)
        {
            try
            {
                string spAdi = "STAJYER_DELETE";
                SQLManager komut = new SQLManager(spAdi);

                komut.ParameterAdd("@STAJYERID", SqlDbType.Int, stajyer.StajyerId);

                int EtkilenenKayitSayisi = komut.Execute();

                komut.Clear();
                if (EtkilenenKayitSayisi != 0)
                {
                    return EtkilenenKayitSayisi;
                }
                else return 0;
            }
            catch (Exception es)
            { return 0; }
        }//End-StajyerDelete

        public int AnlikSayiArtir(int departmanId)
        {
            string spAdi = "spAnlikSayiArtir";
            SQLManager komut = new SQLManager(spAdi);

            komut.ParameterAdd("@DepartmanId", SqlDbType.Int, departmanId);
            int EtkilenenKayitSayisi = komut.Execute();

            komut.Clear();
            return EtkilenenKayitSayisi;
        }

        public int AnlikSayiAzalt(int departmanId)
        {
            string spAdi = "spAnlikSayiAzalt";
            SQLManager komut = new SQLManager(spAdi);

            komut.ParameterAdd("@DepartmanId", SqlDbType.Int, departmanId);
            int EtkilenenKayitSayisi = komut.Execute();

            komut.Clear();
            return EtkilenenKayitSayisi;
        }
    }
}

