using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixBox.Dados.Entidades
{
    public class Usuario
    {
        public Usuario( string nome, string cpf, DateTime dataNascimento, string telefone, string endereco, string bairro, string cidade, string uf,string senhaHash)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            SenhaHash = senhaHash;
            CriadoEm = DateTime.UtcNow;
        }

        public Usuario() { }

        [Key]
        [Required]
        [StringLength(37)]
        public string Id { get;  set; }

        [Required]
        [StringLength(100)]
        public string Nome { get;  set; }

        [Required]
        [StringLength(20)]
        public string Cpf { get;  set; }

        [Required]
        public DateTime DataNascimento { get;  set; }

        [Required]
        [StringLength(20)]
        public string Telefone { get;  set; }

        [Required]
        [StringLength(50)]
        public string Endereco { get;  set; }

        [Required]
        [StringLength(20)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(50)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(10)]
        public string UF { get; set; }

        [Required]
        public string SenhaHash { get;  set; }
        public DateTime CriadoEm { get;  set; }
    }
}
