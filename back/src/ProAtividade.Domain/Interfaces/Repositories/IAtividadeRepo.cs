using System.Collections.Generic;
using System.Threading.Tasks;
using ProAtividade.Domain.Entities;

namespace ProAtividade.Domain.Interfaces.Repositories
{
    public interface IAtividadeRepo : IGeralRepo
    {
        Task<IEnumerable<Atividade>> ObterTodasAsync();
        Task<Atividade> ObterPorIdAsync(int id);
        Task<Atividade> ObterPorTituloAsync(string titulo);
    }
}