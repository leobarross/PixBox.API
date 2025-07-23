using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixBox.Dados.Entidades
{
    public class BoxPremiacao
    {
        public BoxPremiacao(string titulo, string descricao, DateTime dataSorteio, bool ativo)
        {
            Id = Guid.NewGuid().ToString();
            Titulo = titulo;
            Descricao = descricao;
            DataSorteio = dataSorteio;
            Ativo = ativo;
            CriadoEm = DateTime.UtcNow;
        }

        public BoxPremiacao() { }

        [Key]
        [Required]
        [StringLength(37)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(150)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataSorteio { get; set; }

        [Required]
        public bool Ativo {  get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
