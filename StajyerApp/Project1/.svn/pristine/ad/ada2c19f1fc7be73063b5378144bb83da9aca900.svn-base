using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StajyerApp.Bll;
using StajyerApp.Entities;
namespace StajyerApp.UnitTest
{
    [TestClass]
    public class BirimTest
    {

        public BirimManager _BirimBll { get; set; }
        [TestMethod]
        public void TestBirimSelectList()
        {
            _BirimBll = new BirimManager();
            Birim Birim = new Birim();
            Birim.DepartmanAdi = "EBIM";
            Birim.DepartmanId = 2;
            Birim.AnlikSayi = 1;
            Birim.KontenjanSayisi = 4;
            int id = _BirimBll.BirimListe().Count;
            Assert.AreNotEqual(id, 0);
        }
    }
}
