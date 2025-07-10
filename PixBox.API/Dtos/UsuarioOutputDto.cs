namespace PixBox.API.Dtos
{
    public class UsuarioOutputDto
    {
        public string Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
