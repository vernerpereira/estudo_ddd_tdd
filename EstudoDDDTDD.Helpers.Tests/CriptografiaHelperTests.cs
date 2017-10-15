using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDDTDD.Helpers.Tests
{
    [TestClass]
    public class CriptografiaHelperTests
    {
        [TestMethod]
        public void CriptografiaHelper_Criptografar()
        {
            byte[] senha1 = CriptografiaHelper.Criptografar("123456", "123");
            byte[] senha2 = CriptografiaHelper.Criptografar("123456", "123");
            senha1.SequenceEqual(senha2);
        }

        [TestMethod]
        public void CriptografiaHelper_CriptografarSenha()
        {
            byte[] senha1 = CriptografiaHelper.CriptografarSenha("123456");
            byte[] senha2 = CriptografiaHelper.CriptografarSenha("123456");
            senha1.SequenceEqual(senha2);
        }
    }
}
