using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstudoDDDTDD.Domain.ValueObject;
using EstudoDDDTDD.Domain.Enuns;
using System;
using EstudoDDDTDD.Helpers;

namespace EstudoDDDTDD.Domain.Tests.ValueObject
{
    [TestClass]
    public class EnderecoTests
    {
        private string _logradouro;
        private string _complemento;
        private string _numero;
        private string _bairro;
        private string _cidade;
        private Uf _uf;
        private Cep _cep;

        public EnderecoTests()
        {
            _logradouro = "Rua João José";
            _complemento = "Apto 203";
            _numero = "752";
            _bairro = "Centro";
            _cidade = "São Paulo";
            _uf = Uf.SP;
            _cep = new Cep("37500-000");
        }
        
        [TestMethod]
        public void Endereco_Logradouro_Valido()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual(_logradouro, endereco.Logradouro);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Logradouro_Null()
        {
            var endereco = new Endereco(null, _complemento, _numero, _bairro, _cidade, _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Logradouro_Vazio()
        {
            var endereco = new Endereco("", _complemento, _numero, _bairro, _cidade, _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Logradouro_MaxLength()
        {
            string logradouro = "Rua 1";
            while (logradouro.Length < Endereco.LogradouroMaxLength + 1)
            {
                logradouro = logradouro + "123";
            }

            new Endereco(logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Complemento_MaxLength()
        {
            string complemento = "Apto 204";
            while (complemento.Length < Endereco.ComplementoMaxLength + 1)
            {
                complemento = complemento + "123";
            }

            new Endereco(_logradouro, complemento, _numero, _bairro, _cidade, _uf, _cep);
        }

        [TestMethod]
        public void Endereco_Complemento_Valido()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual(_complemento, endereco.Complemento);
        }

        [TestMethod]
        public void Endereco_Complemento_Null()
        {
            var endereco = new Endereco(_logradouro, null, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual("", endereco.Complemento);
        }

        [TestMethod]
        public void Endereco_Complemento_Vazio()
        {
            var endereco = new Endereco(_logradouro, "", _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual("", endereco.Complemento);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Numero_MaxLength()
        {
            string numero = "701";
            while (numero.Length < Endereco.NumeroMaxLength + 1)
            {
                numero = numero + "123";
            }

            new Endereco(_logradouro, _complemento, numero, _bairro, _cidade, _uf, _cep);
        }

        [TestMethod]
        public void Endereco_Numero_Valido()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual(_numero, endereco.Numero);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Numero_Null()
        {
            var endereco = new Endereco(_logradouro, _complemento, null, _bairro, _cidade, _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Numero_Vazio()
        {
            var endereco = new Endereco(_logradouro, _complemento, "", _bairro, _cidade, _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Bairro_MaxLength()
        {
            string bairro = "Centro";
            while (bairro.Length < Endereco.BairroMaxLength + 1)
            {
                bairro = bairro + "123";
            }

            new Endereco(_logradouro, _complemento, _numero, bairro, _cidade, _uf, _cep);
        }

        [TestMethod]
        public void Endereco_Bairro_Valido()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual(_bairro, endereco.Bairro);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Bairro_Null()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, null, _cidade, _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Bairro_Vazio()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, "", _cidade, _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Cidade_MaxLength()
        {
            string cidade = "São Paulo";
            while (cidade.Length < Endereco.BairroMaxLength + 1)
            {
                cidade = cidade + "123";
            }

            new Endereco(_logradouro, _complemento, _numero, _bairro, cidade, _uf, _cep);
        }

        [TestMethod]
        public void Endereco_Cidade_Valido()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual(_cidade, endereco.Cidade);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Cidade_Null()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, null, _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Cidade_Vazio()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, "", _uf, _cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_Uf_Null()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, null, _cep);
        }

        [TestMethod]
        public void Endereco_Uf_Valido()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual(_uf, endereco.Uf);
        }
        
        [TestMethod]
        public void Endereco_Cep_Valido()
        {
            var endereco = new Endereco(_logradouro, _complemento, _numero, _bairro, _cidade, _uf, _cep);
            Assert.AreEqual(_cep, endereco.Cep);
        }
    }
}
