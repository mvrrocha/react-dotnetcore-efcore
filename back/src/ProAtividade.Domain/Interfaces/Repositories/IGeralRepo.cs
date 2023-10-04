using System.Threading.Tasks;

namespace ProAtividade.Domain.Interfaces.Repositories
{
    public interface IGeralRepo
    {
        void Adicionar<T>(T entidade) where T : class;
        void Atualizar<T>(T entidade) where T : class;
        void Remover<T>(T entidade) where T : class;
        void RemoverVarias<T>(T[] entidades) where T : class;

        Task<bool> SalvarMudancasAsync();
    }
}