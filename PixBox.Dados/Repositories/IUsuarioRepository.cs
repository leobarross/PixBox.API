using PixBox.Dados.Entidades;

namespace PixBox.Dados.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        bool CpfExiste(string cpf);
        bool TelefoneExiste(string telefone);
        Usuario ObterPorId(string id);
    }

}
