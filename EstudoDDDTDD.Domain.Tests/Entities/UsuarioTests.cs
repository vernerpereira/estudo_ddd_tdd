using EstudoDDDTDD.Domain.Entities;
using EstudoDDDTDD.Domain.Enuns;
using EstudoDDDTDD.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDDTDD.Domain.Tests.Entities
{
    [TestClass]
    public class UsuarioTests
    {
        private Cpf Cpf { get; set; }
        private Email Email { get; set; }
        private string Login { get; set; }

        private string Senha { get; set; }
        private string SenhaConfirmacao { get; set; }
        private Usuario Usuario { get; set; }

        private Endereco Endereco { get; set; }

        public UsuarioTests()
        {
            Cpf = new Cpf("36551110371");
            Email = new Email("email@gmail.com");
            Login = "meulogin";
            Senha = "123456";
            SenhaConfirmacao = "123456";
            Endereco = new Endereco("rua teste", "complemento teste", "numero teste", "bairro teste", "cidade teste",
                Uf.SP, new Cep("37500-000"));
            Usuario = new Usuario(Login, Cpf, Email, Senha, SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Cpf_Obrigatorio()
        {
            new Usuario(Login, null, Email, Senha, SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Login_Obrigatorio()
        {
            new Usuario("", Cpf, Email, Senha, SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Email_Obrigatorio()
        {
            new Usuario(Login, Cpf, null, Senha, SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Senha_Obrigatorio()
        {
            new Usuario(Login, Cpf, Email, "", SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_SenhaConfirmacao_Obrigatorio()
        {
            new Usuario(Login, Cpf, Email, Senha, "", Endereco);
        }

        [TestMethod]
        public void Usuario_New_Cpf()
        {
            Assert.AreEqual(Cpf, Usuario.Cpf);
        }

        [TestMethod]
        public void Usuario_New_Login()
        {
            Assert.AreEqual(Login, Usuario.Login);
        }

        [TestMethod]
        public void Usuario_New_Email()
        {
            Assert.AreEqual(Email, Usuario.Email);
        }

        [TestMethod]
        public void Usuario_New_Senha()
        {
            Assert.IsNotNull(Usuario.Senha);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetLogin_Min_Value()
        {
            Usuario.SetLogin("12345");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetLogin_Max_Value()
        {
            Usuario.SetLogin("1234567890123456789012345678901");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetSenha_Min_Value()
        {
            var senha = "12345";
            new Usuario(Login, Cpf, Email, senha, senha, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetSenha_Max_Value()
        {
            var senha = "1234567890123456789012345678901";
            new Usuario(Login, Cpf, Email, senha, senha, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetSenha_Senhas_Nao_Conferem()
        {
            new Usuario(Login, Cpf, Email, "testeteste", "blablablabla", Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_AlteraSenha_Senha_Atual_Incorreta()
        {
            Usuario.AlterarSenha("654852", "987654", "987654");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_AlteraSenha_Nova_Senha_Nao_Confere()
        {
            Usuario.AlterarSenha(Senha, "123456", "987654");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_AlteraSenha_Com_Token_Incorreto()
        {
            Guid token = Usuario.GerarNovoTokenAlterarSenha();
            token = Guid.NewGuid();
            Usuario.AlterarSenha(token, "987654", "987654");
        }

        [TestMethod]
        public void Usuario_AlteraSenha_Com_Token_Correto()
        {
            Guid token = Usuario.GerarNovoTokenAlterarSenha();
            Usuario.AlterarSenha(token, "987654", "987654");
        }
    }
}
