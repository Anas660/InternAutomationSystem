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
    public class BirimManager : IBirim

    {
        public IBirim _IBirim { get; set; }
        public BirimManager()
        {
            _IBirim = Infrastructure.InversionOfControl.Resolve<IBirim>();
        }
        public List<Birim> BirimListe()
        {
            return _IBirim.BirimListe();
        }

    }

}
