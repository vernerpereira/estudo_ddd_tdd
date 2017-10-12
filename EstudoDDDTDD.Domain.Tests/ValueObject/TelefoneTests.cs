using EstudoDDDTDD.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDDTDD.Domain.Tests.ValueObject
{
    [TestClass]
    public class TelefoneTests
    {
        [TestMethod]
        public void Telefone_Ddd_Valido()
        {
            var telefone = new Telefone("35", "3623-3623");
            Assert.AreEqual("35", telefone.DDD);
        }

        [TestMethod]
        public void Telefone_Ddd_Null()
        {
            var telefone = new Telefone(null, "3623-3623");
            Assert.AreEqual("", telefone.DDD);
        }

        [TestMethod]
        public void Telefone_Ddd_Vazio()
        {
            var telefone = new Telefone("", "3623-3623");
            Assert.AreEqual("", telefone.DDD);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Telefone_Ddd_MaxLength()
        {
            var telefone = new Telefone("3535", "3623-3623");
        }

        [TestMethod]
        public void Telefone_Numero_Valido()
        {
            var telefone = new Telefone("35", "3623-3623");
            Assert.AreEqual("36233623", telefone.Numero);
        }

        [TestMethod]
        public void Telefone_Numero_Completo_Valido()
        {
            var telefone = new Telefone("35", "3623-3623");
            Assert.AreEqual("3536233623", telefone.GetTelefoneCompleto());
        }

        [TestMethod]
        public void Telefone_Numero_Null()
        {
            var telefone = new Telefone("35", null);
            Assert.AreEqual("", telefone.Numero);
        }

        [TestMethod]
        public void Telefone_Numero_Vazio()
        {
            var telefone = new Telefone("35", "");
            Assert.AreEqual("", telefone.Numero);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Telefone_Numero_MaxLength()
        {
            var telefone = new Telefone("35", "362336233623362336233623");
        }        
    }
}
