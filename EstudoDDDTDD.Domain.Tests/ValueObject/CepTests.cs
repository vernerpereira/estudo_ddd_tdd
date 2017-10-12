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
    public class CepTests
    {
        [TestMethod]
        public void Cep_Valido()
        {
            var cep = "06414-000";
            var obj = new Cep(cep);
            Assert.AreEqual(6414000, obj.CepCod);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cep_InValido()
        {
            var cep = "asfsaf";
            var obj = new Cep(cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cep_Embranco()
        {
            new Cep("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cep_Null()
        {
            new Cep(null);
        }

        [TestMethod]
        public void Cep_GetCepFormatado06414000()
        {
            var cep = "06414-000";
            var obj = new Cep(cep);
            Assert.AreEqual(cep, obj.GetCepFormatado());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cep_MaxLength()
        {
            var cep = "00345-1234";
            new Cep(cep);            
        }
    }
}
