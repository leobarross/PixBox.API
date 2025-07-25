using PixBox.API.Dtos.Login;
using PixBox.API.Dtos.Usuario;
using PixBox.Dados.Entidades;
using PixBox.Dados.Repositories.Interfaces;

namespace PixBox.API.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuario;
        private readonly TokenService _tokenService;


        public UsuarioService(IUsuarioRepository usuario, TokenService tokenService)
        {
            _usuario = usuario;
            _tokenService = tokenService;
        }

        public async Task<UsuarioOutputDto> RegistrarUsuarioAsync(UsuarioInputDto dto)
        {
            if (await _usuario.ExisteCpfAsync(dto.Cpf))
                throw new ArgumentException("CPF já cadastrado.");

            if (await _usuario.ExisteTelefoneAsync(dto.Telefone))
                throw new ArgumentException("Telefone já cadastrado.");

            var hoje = DateOnly.FromDateTime(DateTime.Today);       
            var limite = hoje.AddYears(-18);                         

            if (dto.DataNascimento > limite)                        
                throw new ArgumentException("Usuário deve ter no mínimo 18 anos.");


            var usuario = new Usuario(
                dto.Nome, 
                dto.Cpf, 
                dto.DataNascimento, 
                dto.Telefone,
                dto.Endereco,
                dto.Bairro,
                dto.Cidade,
                dto.UF,
                BCrypt.Net.BCrypt.HashPassword(dto.Senha)
            );

            await _usuario.AdicionarAsync(usuario);

            return new UsuarioOutputDto
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
        public async Task<UsuarioOutputDto> ObterPorIdAsync(string id)
        {
            var usuario = await _usuario.ObterPorIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioOutputDto
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

        public async Task<LoginOutPutDto> LoginAsync(string telefone, string senha)
        {
            var usuario = await _usuario.ObterPorTelefoneAsync(telefone);

            if (usuario == null)
                throw new ArgumentException("Telefone não cadastrado.");

            bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);
            if (!senhaValida)
                throw new ArgumentException("Senha inválida.");

            var role = usuario.IsAdmin ? "Admin" : "User";

            var token = _tokenService.GerarToken(usuario.Id, role);

            return new LoginOutPutDto
            {
                Status = "success",
                Token = token,
                User = new
                {
                    Id = usuario.Id,
                    Login = usuario.Telefone
                },
                SessionExpiration = DateTime.UtcNow.AddHours(1)
            };
        }
    }
}
