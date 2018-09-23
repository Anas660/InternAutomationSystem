using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StajyerApp.Bll;
using StajyerApp.Entities;

namespace StajyerApp.UnitTest
{
    [TestClass]
    public class BolumTest
    {
        public BolumManager _BolumBll { get; set; }

        [TestMethod]
        public void TestBolumInsert()
        {
            _BolumBll = new BolumManager();
            Bolum Bolum = new Bolum();
            Bolum.BolumAdi = "TestBolum";
            int kaydetId = _BolumBll.BolumInsert(Bolum);
            Assert.AreEqual(kaydetId, 1);
        }
        [TestMethod]
        public void TestBolumListeleme()
        {
            _BolumBll = new BolumManager();
            Bolum Bolum = new Bolum();
            Bolum.BolumAdi = "TestBolum";
            int id = _BolumBll.BolumListe().Count;
            Assert.AreNotEqual(id, 0);
        }
        [TestMethod]
        public void TestBolumUpdate()
        {
            _BolumBll = new BolumManager();
            Bolum Bolum = new Bolum();
            Bolum.BolumAdi = "TestBolum";
            int id = _BolumBll.BolumUpdate(Bolum);
            Assert.AreNotEqual(id, 0);
        }
        [TestMethod]
        public void TestBolumDelete()
        {
            _BolumBll = new BolumManager();
            Bolum Bolum = new Bolum();
            Bolum.BolumAdi = "TestBolum";
            int id = _BolumBll.BolumDelete(Bolum);
            Assert.AreNotEqual(id, 0);
        }
    }
}

