using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EstudoDDDTDD.Helpers.Tests
{
    [TestClass]
    public class GuardTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_Guid_Em_Branco()
        {
            Guard.ForValidId(Guid.Empty, "Id inválido");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_Guid_Em_Branco2()
        {
            Guard.ForValidId("Id", Guid.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_Id_Negativo()
        {
            Guard.ForValidId(-2, "Id inválido");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_Id_Negativo2()
        {
            Guard.ForValidId("Id", -3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNegative()
        {
            Guard.ForValidId(-2, "Inteiro");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Em_Branco()
        {
            Guard.ForNullOrEmpty("", "valor não pode ser vazio");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Null()
        {
            Guard.ForNullOrEmpty(null, "valor não pode ser vazio");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmptyDefaultMessage_Em_Branco()
        {
            Guard.ForNullOrEmptyDefaultMessage("", "Campo");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmptyDefaultMessage_Null()
        {
            Guard.ForNullOrEmptyDefaultMessage(null, "Campo");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Max_1()
        {
            Guard.StringLength("12345", 2, "Não é permitido mais de 2 caracteres");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Max_2()
        {
            Guard.StringLength("Campo", "12345", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Min_Max_Testando_Min_1()
        {
            Guard.StringLength("12345", 7, 10, "A quantidade de caracteres deve ficar entre 7 e 10 caracteres");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Min_Max_Testando_Max_1()
        {
            Guard.StringLength("12345123456", 7, 10, "A quantidade de caracteres deve ficar entre 7 e 10 caracteres");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Min_Max_Testando_Min_2()
        {
            Guard.StringLength("Campo", "12345", 7, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Min_Max_Testando_Max_2()
        {
            Guard.StringLength("Campo", "12345123456", 7, 10);
        }
    }
}
