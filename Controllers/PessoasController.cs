using CrudAPI_Sqlite.Data;
using CrudAPI_Sqlite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI_Sqlite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly Context _context;

        public PessoasController(Context context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet]
        public IActionResult Get()
        {
            var pessoas = _context.Pessoas.ToList();
            return Ok(pessoas);
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}", Name = "GetPessoa")]
        public IActionResult Get(int id)
        {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        // POST: api/Pessoas
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                return BadRequest("O nome da pessoa é obrigatório.");
            }

            pessoa.Ativo = true;

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return CreatedAtRoute("GetPessoa", new { id = pessoa.Id }, pessoa);
        }

        // PUT: api/Pessoas/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null || pessoa.Id != id)
            {
                return BadRequest("Dados inválidos.");
            }

            var pessoaExistente = _context.Pessoas.Find(id);
            if (pessoaExistente == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                return BadRequest("O nome da pessoa é obrigatório.");
            }

            pessoaExistente.Nome = pessoa.Nome;
            pessoaExistente.DataCadastro = pessoa.DataCadastro;
            pessoaExistente.Ativo = pessoa.Ativo;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}