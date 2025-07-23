using System.ComponentModel.DataAnnotations;

namespace PixBox.API.Dtos.Sorteio
{
    public class SorteioInputDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataSorteio { get; set; }
    }
}
