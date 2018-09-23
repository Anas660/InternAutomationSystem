using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StajyerApp.Bll;
using StajyerApp.Entities;

namespace StajyerApp.UnitTest
{
    [TestClass]
    public class OkulTest
    {
        public OkulManager _okulBll { get; set; }

        [TestMethod]
        public void TestOkulInsert()
        {
            _okulBll = new OkulManager();
            Okul okul = new Okul();
            okul.OkulAdi = "TestOkul";
            int kaydetId = _okulBll.OkulInsert(okul);
            Assert.AreEqual(kaydetId, 1);
        }
        [TestMethod]
        public void TestOkulListeleme()
        {
            _okulBll = new OkulManager();
            Okul okul = new Okul();
            okul.OkulAdi = "TestOkul";
            int id = _okulBll.OkulListe().Count;
            Assert.AreNotEqual(id, 0);
        }
        [TestMethod]
        public void TestOkulUpdate()
        {
            _okulBll = new OkulManager();
            Okul okul = new Okul();
            okul.OkulAdi = "TestOkul";
            int id = _okulBll.OkulUpdate(okul);
            Assert.AreNotEqual(id, 0);
        }
        [TestMethod]
        public void TestOkulDelete()
        {
            _okulBll = new OkulManager();
            Okul okul = new Okul();
            okul.OkulAdi = "TestOkul";
            int id = _okulBll.OkulDelete(okul);
            Assert.AreNotEqual(id, 0);
        }
    }
}
