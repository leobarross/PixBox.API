using Microsoft.EntityFrameworkCore;
using PixBox.Dados.Data;
using PixBox.Dados.Entidades;
using PixBox.Dados.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixBox.Dados.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PixBoxDbContext _context;

        public UsuarioRepository(PixBoxDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            return await _context.Usuarios.AnyAsync(u => u.Cpf == cpf);
        }

        public async Task<bool> ExisteTelefoneAsync(string telefone)
        {
            return await _context.Usuarios.AnyAsync(u => u.Telefone == telefone);
        }

        public async Task<Usuario> ObterPorTelefoneAsync(string telefone)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Telefone == telefone);
        }


        public async Task<Usuario> ObterPorIdAsync(string id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
