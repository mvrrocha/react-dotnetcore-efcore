using System.Collections.Generic;
using System.Threading.Tasks;
using ProAtividade.Domain.Entities;

namespace ProAtividade.Domain.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task<Atividade> AdicionarAtividadeAsync(Atividade model);
        Task<Atividade> AtualizarAtividadeAsync(Atividade model);
        Task<bool> RemoverAtividadeAsync(int atividadeId);
        Task<bool> ConcluirAtividadeAsync(Atividade model);
        Task<IEnumerable<Atividade>> ObterTodasAtividadesAsync();        
        Task<Atividade> ObterAtividadeAsync(int id);
    }
}