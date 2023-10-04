using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.Domain.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepo _atividadeRepo;
        public AtividadeService(IAtividadeRepo atividadeRepo)
        {
            _atividadeRepo = atividadeRepo;
        }

        public async Task<Atividade> AdicionarAtividadeAsync(Atividade model)
        {
            if(await _atividadeRepo.ObterPorTituloAsync(model.Titulo) != null)
                throw new Exception("Já existe uma atividade com este título!");

            if(await _atividadeRepo.ObterPorIdAsync(model.Id) == null)
            {
                _atividadeRepo.Adicionar(model);
                if (await _atividadeRepo.SalvarMudancasAsync())
                return model;
            }

            return null;
        }

        public async Task<Atividade> AtualizarAtividadeAsync(Atividade model)
        {
            if(model.DataConclusao != null)
            throw new Exception("Não se pode alterar atividade já concluída!");

            if(await _atividadeRepo.ObterPorIdAsync(model.Id) != null)
            {
                _atividadeRepo.Atualizar(model);
                if (await _atividadeRepo.SalvarMudancasAsync())
                return model;
            }

            return null;
        }

        public async Task<bool> ConcluirAtividadeAsync(Atividade model)
        {
            if(model != null)
            {
                model.Concluir();
                _atividadeRepo.Atualizar<Atividade>(model);
                return await _atividadeRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<Atividade> ObterAtividadeAsync(int id)
        {
            try
            {
                var atividade = await _atividadeRepo.ObterPorIdAsync(id);
                if (atividade == null) 
                    return null;

                return atividade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Atividade>> ObterTodasAtividadesAsync()
        {
            try
            {
                var atividades = await _atividadeRepo.ObterTodasAsync();
                if (atividades == null) 
                    return null;

                return atividades;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoverAtividadeAsync(int atividadeId)
        {
            var atividade = await _atividadeRepo.ObterPorIdAsync(atividadeId);            
            if (atividade == null)
                throw new Exception("A atividade que tentou deletar, não existe!");

            _atividadeRepo.Remover(atividade);
            return await _atividadeRepo.SalvarMudancasAsync();
        } 
    }
}