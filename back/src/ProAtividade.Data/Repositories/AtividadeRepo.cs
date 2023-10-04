using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Data.Repositories
{
    public class AtividadeRepo : GeralRepo, IAtividadeRepo
    {  
        private readonly DataContext _context;
        public AtividadeRepo(DataContext context) : base(context)
        {
            _context = context;            
        }      
        public async Task<Atividade> ObterPorIdAsync(int id)
        {
            IQueryable<Atividade> query = _context.Atividades.AsNoTracking()
                                                             .Where(ativ => ativ.Id == id)
                                                             .OrderBy(ativ => ativ.Id)
                                                             .AsQueryable();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Atividade> ObterPorTituloAsync(string titulo)
        {
            IQueryable<Atividade> query = _context.Atividades.AsNoTracking()
                                                             .OrderBy(ativ => ativ.Id)
                                                             .AsQueryable();
            return await query.FirstOrDefaultAsync(ativ => ativ.Titulo == titulo);
        }

        public async Task<IEnumerable<Atividade>> ObterTodasAsync()
        {
            IQueryable<Atividade> query = _context.Atividades.AsNoTracking().OrderBy(ativ => ativ.Id);
            return await query.ToArrayAsync();
        }     
    }
}