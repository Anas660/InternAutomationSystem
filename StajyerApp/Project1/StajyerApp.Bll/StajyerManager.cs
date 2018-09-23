using StajyerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StajyerApp.Entities;
using StajyerApp.Dal;

namespace StajyerApp.Bll
{
    public class StajyerManager : IStajyer
    {
        public IStajyer _IStajer { get; set; }
        public StajyerManager()
        {
            _IStajer=  Infrastructure.InversionOfControl.Resolve<IStajyer>();
        }
        public List<Stajyer> StajyerListe()
        {
            return _IStajer.StajyerListe();
        }

        public int StajyerInsert(Stajyer stajyer)
        {
            StajyerDal stajyerdal = new StajyerDal();
            if (stajyer.Adi != null && stajyer.Adi.Trim().Length > 0 && stajyer.Soyadi != null && stajyer.Soyadi.Trim().Length > 0 && stajyer.Telefon != null && stajyer.Telefon.Trim().Length > 0 &&
                stajyer.Email != null && stajyer.Email.Trim().Length > 0 && stajyer.Adres != null && stajyer.Adres.Trim().Length > 0 && stajyer.DogumYeri != null && stajyer.DogumYeri.Trim().Length > 0 
                && stajyer.SicilNo != null && stajyer.SicilNo.Trim().Length > 0
                && stajyer.TcNo != null && stajyer.TcNo.Trim().Length > 0 &&  stajyer.BaslamaTarihi != null && stajyer.BitisTarihi != null && stajyer.DogumTarihi != null)
               
            {
                return stajyerdal.StajyerInsert(stajyer);
            }

            return -1;


        }

        public int StajyerUpdate(Stajyer stajyer)
        {
            StajyerDal stajyerdal = new StajyerDal();
            if (stajyer.Adi != null && stajyer.Adi.Trim().Length > 0 && stajyer.Soyadi != null && stajyer.Soyadi.Trim().Length > 0 && stajyer.Telefon != null && stajyer.Telefon.Trim().Length > 0 &&
                stajyer.Email != null && stajyer.Email.Trim().Length > 0 && stajyer.Adres != null && stajyer.Adres.Trim().Length > 0 && stajyer.DogumYeri != null && stajyer.DogumYeri.Trim().Length > 0
                && stajyer.SicilNo != null && stajyer.SicilNo.Trim().Length > 0
                && stajyer.TcNo != null && stajyer.TcNo.Trim().Length > 0 && stajyer.BaslamaTarihi != null && stajyer.BitisTarihi != null && stajyer.DogumTarihi != null)

            {
                return stajyerdal.StajyerUpdate(stajyer);
            }

            return -1;

        }

        public int StajyerDelete(Stajyer stajyer)
        {
            StajyerDal stajyerdal = new StajyerDal();
            if (stajyer.StajyerId != 0)
            {
                return stajyerdal.StajyerDelete(stajyer);
            }
            return -1;
        }

        public int AnlikSayiArtir(int DepartmanId)
        {
            return _IStajer.AnlikSayiArtir(DepartmanId);
        }

        public int AnlikSayiAzalt(int DepartmanId)
        {
            return _IStajer.AnlikSayiAzalt(DepartmanId);
        }
    }
}
