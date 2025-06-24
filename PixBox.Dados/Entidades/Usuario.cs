using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixBox.Dados.Entidades
{
    public class Usuario
    {
        public Usuario( string nome, string cpf, DateTime dataNascimento, string telefone, string endereco, string senhaHash)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Endereco = endereco;
            SenhaHash = senhaHash;
            CriadoEm = DateTime.UtcNow;
        }

        public Usuario() { }
        public string Id { get;  set; }
        public string Nome { get;  set; }
        public string Cpf { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Telefone { get;  set; }
        public string Endereco { get;  set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string SenhaHash { get;  set; }
        public DateTime CriadoEm { get;  set; }
    }
}
