using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Models;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        public IEnumerable<Atividade> Atividades = new List<Atividade>() {
            new Atividade(3),
            new Atividade(4),
            new Atividade(5)
        };

        [HttpGet]
        public IEnumerable<Atividade> Get() {
            return Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id) {
            return Atividades.FirstOrDefault(a => a.Id == id);
        }

        [HttpPost]
        public IEnumerable<Atividade> Post(Atividade atividade) {
            return Atividades.Append<Atividade>(atividade);
        }

        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade) {
            atividade.Id = id + 1;
            return atividade;
        }

        [HttpDelete("{id}")]
        public string Delete(int id) {
            return $"Meu primeiro método Delete com parâmetro {id}";
        }
    }
}