using Microsoft.EntityFrameworkCore;
using PixBox.Dados.Data;
using PixBox.Dados.Entidades;
using PixBox.Dados.Repositories.Interfaces;

namespace PixBox.Dados.Repositories
{
    public class SorteioRepository : ISorteioRepository
    {
        private readonly PixBoxDbContext _context;

        public SorteioRepository(PixBoxDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(BoxPremiacao sorteio)
        {
            await _context.BoxPremiacoes.AddAsync(sorteio);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(BoxPremiacao sorteio)
        {
            _context.BoxPremiacoes.Update(sorteio);
            await _context.SaveChangesAsync();
        }

        public async Task<BoxPremiacao> ObterPorIdAsync(string id)
        {
            return await _context.BoxPremiacoes.FindAsync(id);
        }

        public async Task<IEnumerable<BoxPremiacao>> ObterTodosAtivosAsync()
        {
            return await _context.BoxPremiacoes.Where(b => b.Ativo).ToListAsync();
        }
    }
}
