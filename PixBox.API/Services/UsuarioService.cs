using PixBox.API.Dtos;
using PixBox.Dados.Entidades;
using PixBox.Dados.Repositories;

namespace PixBox.API.Services
{
    public class UsuarioService : IUsuarioRepository
    {
        //private readonly IUsuarioRepository _usuario;

        private readonly List<Usuario> _usuarios = new();

        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public bool CpfExiste(string cpf)
        {
            return _usuarios.Any(u => u.Cpf == cpf);
        }

        public bool TelefoneExiste(string telefone)
        {
            return _usuarios.Any(u => u.Telefone == telefone);
        }

        public UsuarioDto RegistrarUsuario(UsuarioInputDto dto)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Endereco = dto.Endereco,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                UF = dto.UF,
                Telefone = dto.Telefone,
                DataNascimento = dto.DataNascimento,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                CriadoEm = DateTime.UtcNow
            };

            Adicionar(usuario);

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                Endereco = usuario.Endereco,
                Bairro = usuario.Bairro,
                Cidade = usuario.Cidade,
                UF = usuario.UF,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                CriadoEm = usuario.CriadoEm
            };
        }

        public Usuario ObterPorId(string id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}
