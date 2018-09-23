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
  public  class BolumManager : IBolum
    {
        public IBolum _IBolum { get; set; }
        public BolumManager()
        {
            _IBolum = Infrastructure.InversionOfControl.Resolve<IBolum>();
        }
        public List<Bolum> BolumListe()
        {
            return _IBolum.BolumListe();
        }

        public int BolumInsert(Bolum BolumUp)
        {

            BolumDal Bolumdal = new BolumDal();
            if (BolumUp.BolumAdi != null && BolumUp.BolumAdi.Trim().Length > 0)
            {
                return Bolumdal.BolumInsert(BolumUp);
            }
            return -1;


        }

        public int BolumUpdate(Bolum Bolum)
        {
            BolumDal Bolumdal = new BolumDal();
            if (Bolum.BolumId != 0 && Bolum.BolumAdi != null && Bolum.BolumAdi.Trim().Length > 0)
            {
                return Bolumdal.BolumUpdate(Bolum);
            }

            return -1;

        }
        public int BolumDelete(Bolum Bolum)
        {
            BolumDal Bolumdal = new BolumDal();
            if (Bolum.BolumId != 0)
            {
                return Bolumdal.BolumDelete(Bolum);
            }
            return -1;
        }
    }
}

