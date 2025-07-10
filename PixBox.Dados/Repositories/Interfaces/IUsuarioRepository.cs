using PixBox.Dados.Entidades;

namespace PixBox.Dados.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorIdAsync(string id);
        Task AdicionarAsync(Usuario usuario);
        Task<bool> ExisteCpfAsync(string cpf);
        Task<bool> ExisteTelefoneAsync(string telefone);
        Task<Usuario> ObterPorTelefoneAsync(string telefone);
    }

}
