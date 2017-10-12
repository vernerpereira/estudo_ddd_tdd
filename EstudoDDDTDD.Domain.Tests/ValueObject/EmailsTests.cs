using EstudoDDDTDD.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EstudoDDDTDD.Domain.Tests.ValueObject
{
    [TestClass]
    public class EmailsTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Em_Branco() {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Null()
        {
            var email = new Email(null);
        }

        [TestMethod]
        public void Email_Valido()
        {
            var endereco = "vernerpereira@gmail.com";
            var email = new Email(endereco);
            Assert.AreEqual(endereco, email.Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Invalido()
        {
            var email = new Email("vasdfaegdsfgi3444");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_MaxLength()
        {
            var endereco = "vernerpereira@gmail.com";
            while(endereco.Length < Email.EnderecoMaxLength + 1)
            {
                endereco = endereco + "123";
            }
            new Email(endereco);
        }
    }
}
