using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDDTDD.Helpers.Tests
{
    [TestClass]
    public class TextoHelperTests
    {
        [TestMethod]
        public void TextoHelper_RemoverAcentos()
        {
            var texto = TextoHelper.RemoverAcentos("ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç");
            Assert.AreEqual("AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc", texto, false);
        }

        [TestMethod]
        public void TextoHelper_RemoverAcentos_Nulo()
        {
            var texto = TextoHelper.RemoverAcentos(null);
            Assert.AreEqual("", texto);
        }

        [TestMethod]
        public void TextoHelper_FormatarTextoParaUrl_Nulo()
        {
            var texto = TextoHelper.FormatarTextoParaUrl(null);
            Assert.AreEqual("", texto);
        }

        [TestMethod]
        public void TextoHelper_FormatarTextoParaUrl()
        {
            var texto = TextoHelper.FormatarTextoParaUrl("áa@ $Bb");
            Assert.AreEqual("aaBb", texto, false);
        }

        [TestMethod]
        public void TextoHelper_GetNumeros_Nulo()
        {
            var texto = TextoHelper.GetNumeros(null);
            Assert.AreEqual("", texto);
        }

        [TestMethod]
        public void TextoHelper_GetNumeros()
        {
            var texto = TextoHelper.GetNumeros("aet871 83jj");
            Assert.AreEqual("87183", texto);
        }

        [TestMethod]
        public void TextoHelper_AjustarTexto_Nulo()
        {
            var texto = TextoHelper.AjustarTexto(null, 5);
            Assert.AreEqual("", texto);
        }

        [TestMethod]
        public void TextoHelper_AjustarTexto()
        {
            var texto = TextoHelper.AjustarTexto("aet871 83jj", 5);
            Assert.AreEqual("aet87", texto);
        }

        [TestMethod]
        public void TextoHelper_ToTitleCase_Nulo()
        {
            var texto = TextoHelper.ToTitleCase(null);
            Assert.AreEqual("", texto);
        }

        [TestMethod]
        public void TextoHelper_ToTitleCase()
        {
            var texto = TextoHelper.ToTitleCase("verner estevam pereira");
            Assert.AreEqual("Verner Estevam Pereira", texto, false);
        }

        [TestMethod]
        public void TextoHelper_ToTitleCase_MantendoMaiuscula_Nulo()
        {
            var texto = TextoHelper.ToTitleCase(null, true);
            Assert.AreEqual("", texto);
        }

        [TestMethod]
        public void TextoHelper_ToTitleCase_MantendoMaiuscula()
        {
            var texto = TextoHelper.ToTitleCase("verner ESTEVAM pereira", true);
            Assert.AreEqual("Verner ESTEVAM Pereira", texto, false);
        }
    }
}
