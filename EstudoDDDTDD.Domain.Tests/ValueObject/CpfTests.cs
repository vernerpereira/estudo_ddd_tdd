﻿using EstudoDDDTDD.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EstudoDDDTDD.Domain.Tests.ValueObject
{
    [TestClass]
    public class CpfTests
    {
        [TestMethod]
        public void Cpf_Valido_40914294830()
        {
            var cpf = new Cpf("409.142.948-30");
            Assert.AreEqual(40914294830, cpf.Codigo);
            Assert.AreEqual("40914294830", cpf.GetCpfCompleto());
            Assert.AreEqual("40914294830", cpf.GetSemZeros());
        }

        [TestMethod]
        public void Cpf_Valido_Com_Zero_No_Inicio_02766657401()
        {
            var cpf = new Cpf("027.666.574-01");
            Assert.AreEqual(2766657401, cpf.Codigo);
            Assert.AreEqual("02766657401", cpf.GetCpfCompleto());
            Assert.AreEqual("2766657401", cpf.GetSemZeros());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cpf_Invalido_0d89502b3454e()
        {
            var cpf = new Cpf("0d89502b3454e");
        }
    }
}
