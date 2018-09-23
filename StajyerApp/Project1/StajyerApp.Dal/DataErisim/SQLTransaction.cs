
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StajyerApp.Dal.DataErisim
{
    public class SQLTransaction //:ISQLTransaction
    {
        public void TransactionStart()
        {
            SQLManager.TransactionStart();
        }

        public void TransactionCommit()
        {
            SQLManager.TransactionCommit();
        }

        public void TransactionRollback()
        {
            SQLManager.TransactionRollback();
        }

        public void TransactionClear()
        {
            SQLManager.ClearX();
        }
    }
}
