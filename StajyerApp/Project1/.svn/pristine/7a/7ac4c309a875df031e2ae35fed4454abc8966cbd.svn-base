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
  public  class OkulManager : IOkul
    {
        public IOkul _IOkul { get; set; }
        public OkulManager()
        {
            _IOkul = Infrastructure.InversionOfControl.Resolve<IOkul>();
        }
        public  List<Okul> OkulListe()
        {
            return _IOkul.OkulListe();
        }

        public int OkulInsert ( Okul okulUp)
        {

            OkulDal okuldal = new OkulDal();
            if (okulUp.OkulAdi != null && okulUp.OkulAdi.Trim().Length > 0 )
            {
                return okuldal.OkulInsert(okulUp);
            }

            return -1;

        
    }

        public int OkulUpdate(Okul okul)
        {
            OkulDal okuldal = new OkulDal();
            if (okul.OkulId != 0 && okul.OkulAdi != null && okul.OkulAdi.Trim().Length > 0 )
            {
                return okuldal.OkulUpdate(okul);
            }

            return -1;

        }

        public int OkulDelete(Okul okul)
        {
            OkulDal okuldal = new OkulDal();
            if (okul.OkulId != 0)
            {
                return okuldal.OkulDelete(okul);
            }
            return -1;
        }
    }
}
