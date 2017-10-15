﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDDTDD.Helpers
{
    public class CriptografiaHelper
    {
        public static byte[] CriptografarSenha(string senha)
        {
            return Criptografar(senha, "loren-123-ipysum");
        }

        public static byte[] Criptografar(string texto, string salt)
        {
            while (salt.Length < 6)
            {
                salt += salt + "Z";
            }
            using (var sha = SHA512.Create())
            {
                salt = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(salt.Substring(salt.Length - 4))));
                return sha.ComputeHash(Encoding.UTF8.GetBytes(texto + salt));
            }
        }
    }
}
