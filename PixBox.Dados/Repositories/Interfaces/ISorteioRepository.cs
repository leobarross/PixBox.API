using PixBox.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixBox.Dados.Repositories.Interfaces
{
    public interface ISorteioRepository
    {
        Task AdicionarAsync(BoxPremiacao sorteio);
        Task<BoxPremiacao> ObterPorIdAsync(string id);
        Task<IEnumerable<BoxPremiacao>> ObterTodosAtivosAsync();
        Task AtualizarAsync(BoxPremiacao sorteio);
    }
}
