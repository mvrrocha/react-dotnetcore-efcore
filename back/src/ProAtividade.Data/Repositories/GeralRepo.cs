using System.Threading.Tasks;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Data.Repositories
{
    public class GeralRepo : IGeralRepo
    {
        private readonly DataContext _context;
        public GeralRepo(DataContext context)
        {
            _context = context;
            
        }
        public void Adicionar<T>(T entidade) where T : class
        {
            _context.Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T : class
        {
            _context.Update(entidade);
        }

        public void Remover<T>(T entidade) where T : class
        {
            _context.Remove(entidade);
        }

        public void RemoverVarias<T>(T[] entidades) where T : class
        {
            _context.RemoveRange(entidades);
        }

        public async Task<bool> SalvarMudancasAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}