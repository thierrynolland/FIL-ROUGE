using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ValidEmail.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void verifEmailTest1()
        {
            string attendu = "";
            string resultat;
            ///Form1 f = new Form1();
            resultat = Form1.verifEmail("monmail@free.fr");

            Assert.AreEqual(attendu,resultat);
        }
        [TestMethod()]
        public void verifEmailTest2()
        {
            string attendu = "- Il manque le point \n";
            string resultat;
            ///Form1 f = new Form1();
            resultat = Form1.verifEmail("monmail@freefr");

            Assert.AreEqual(attendu, resultat);
        }
        [TestMethod()]
        public void verifEmailTest3()
        {
            string attendu = "- Il manque  @ \n";
            string resultat;
            resultat = Form1.verifEmail("monmailfree.fr");
            Assert.AreEqual(attendu, resultat);
        }

        [TestMethod()]
        public void verifEmailTest4()
        {
            string attendu = "pas assez de caractères avant le @ \n";
            string resultat;
            resultat = Form1.verifEmail("m@free.fr");
            Assert.AreEqual(attendu, resultat);
        }
        [TestMethod()]
        public void verifEmailTest5()
        {
            string attendu = "pas assez de caractères entre @ et le point \n";
            string resultat;
            resultat = Form1.verifEmail("monmail@e.fr");
            Assert.AreEqual(attendu, resultat);
        }
        [TestMethod()]
        public void verifEmailTest6()
        {
            string attendu = " pas assez de caractères après le point \n";
            string resultat;
            resultat = Form1.verifEmail("monmail@free.r");
            Assert.AreEqual(attendu, resultat);
        }



    }
}