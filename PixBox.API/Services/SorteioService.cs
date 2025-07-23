using PixBox.Dados.Entidades;
using PixBox.Dados.Repositories.Interfaces;

namespace PixBox.API.Services
{
    public class SorteioService
    {
        private readonly ISorteioRepository _repository;

        public SorteioService(ISorteioRepository repository)
        {
            _repository = repository;
        }

        public async Task<BoxPremiacao> CriarSorteioAsync(string titulo, string descricao, DateTime dataSorteio)
        {
            var sorteio = new BoxPremiacao
            (
               titulo,
               descricao,
               dataSorteio,
               true
            );

            await _repository.AdicionarAsync(sorteio);
            return sorteio;
        }

        public async Task<IEnumerable<BoxPremiacao>> ListarSorteiosAtivosAsync()
        {
            return await _repository.ObterTodosAtivosAsync();
        }

        public async Task<BoxPremiacao> ObterPorIdAsync(string id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task AtualizarSorteioAsync(BoxPremiacao sorteio)
        {
            await _repository.AtualizarAsync(sorteio);
        }
    }
}
