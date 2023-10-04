using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeService _atividadeService;
        public AtividadeController(IAtividadeService atividadeService)
        {        
            _atividadeService = atividadeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
             var atividades = await _atividadeService.ObterTodasAtividadesAsync();
            if (atividades == null)
                return NoContent();

            return Ok(atividades);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Atividades. Erro: {ex.Message}");
            }            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            try
            {
                var atividade = await _atividadeService.ObterAtividadeAsync(id);
                if (atividade == null)
                    return NoContent();

                return Ok(atividade);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Atividade com id: ${id}. Erro: {ex.Message}");
            } 
        }

        [HttpPost]
        public async Task<IActionResult> Post(Atividade atividade) {
            try
            {
                var atividadeDB = await _atividadeService.AdicionarAtividadeAsync(atividade);
                if (atividadeDB == null)
                    return NoContent();

                return Ok(atividadeDB);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar a Atividade. Erro: {ex.Message}");
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Atividade atividade) {
           try
            {
                if (atividade.Id != id)
                    return this.StatusCode(StatusCodes.Status409Conflict, $"Você está tentando atualizar a atividade errada!");

                var atividadeDB = await _atividadeService.ObterAtividadeAsync(id) ?? throw new Exception($"Atividade não encontrada com o id: {id}");

                atividadeDB = await _atividadeService.AtualizarAtividadeAsync(atividade);
                if (atividadeDB == null)
                    return NoContent();

                return Ok(atividadeDB);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar a Atividade. Erro: {ex.Message}");
            } 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
          try
            {                
                var atividadeDB = await _atividadeService.ObterAtividadeAsync(id);
                if (atividadeDB == null) 
                    return this.StatusCode(StatusCodes.Status409Conflict, $"Você está tentando remover uma atividade que não existe!");

                if (!await _atividadeService.RemoverAtividadeAsync(id))
                    return BadRequest("Ocorreu um problema ao tentar deletar a atividade!");

                return Ok(new { message = "Deletado" });
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar remover a Atividade. Erro: {ex.Message}");
            } 
        }
    }
}