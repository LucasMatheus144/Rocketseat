using Livraria.API.Entites;
using Livraria.API.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestaoLivrariaController : ControllerBase
    {
        private static readonly Dictionary<int, Livro> Book = new Dictionary<int, Livro>();

        [HttpGet]
        public IActionResult GetLivros(int? id)
        {
            if (Book.Count == 0)
            {
                return NotFound("Não existe cadastro");
            }

            IEnumerable<object> formatado;

            if (id == null)
            {
                formatado = Book.Select(item => new
                {
                    Id = item.Value.Id,
                    Titulo = item.Value.Titulo,
                    Autor = item.Value.Autor,
                    Tipo = Enum.GetName(typeof(TipoGenero), item.Value.Tipo),
                    Preco = item.Value.preco,
                    Qntd_Estoque = item.Value.Qntd_Estoque
                }).ToList();
            }
            else
            {
                formatado = Book
                    .Where(item => item.Value.Id == id)
                    .Select(item => new
                    {
                        Id = item.Value.Id,
                        Titulo = item.Value.Titulo,
                        Autor = item.Value.Autor,
                        Tipo = Enum.GetName(typeof(TipoGenero), item.Value.Tipo),
                        Preco = item.Value.preco,
                        Qntd_Estoque = item.Value.Qntd_Estoque
                    }).ToList();
            }

            return Ok(formatado);
        }
        
        [HttpPost]
        public IActionResult PostLivros([FromBody] Livro conteudo)
        {
            if (conteudo.Id == 0)
            {
                return BadRequest("Id Invalido");
            }

            if (Book.ContainsKey(conteudo.Id))
            {
                return BadRequest("O campo Id ja existe");
            }


            var cadastro = new Livro
            {
                Id = conteudo.Id,
                Titulo = conteudo.Titulo,
                Autor = conteudo.Autor,
                Tipo = (TipoGenero)conteudo.Tipo,
                preco = conteudo.preco,
                Qntd_Estoque = conteudo.Qntd_Estoque

            };

            Book.Add(conteudo.Id, cadastro);

            return Ok(Book);
        }

        [HttpPut]
        [Route("Id={id}")]
        public IActionResult PutLivros([FromBody] Livro conteudo, int id)
        {
            if (conteudo.Id == 0)
            {
                return BadRequest("Id Invalido");
            }

            if (!Book.ContainsKey(conteudo.Id))
            {
                return BadRequest("Id Não existe");
            }

            try
            {
                Book[conteudo.Id].Titulo = conteudo.Titulo;
                Book[conteudo.Id].Autor = conteudo.Autor;
                Book[conteudo.Id].Tipo = (TipoGenero)conteudo.Tipo;
                Book[conteudo.Id].preco = conteudo.preco;
                Book[conteudo.Id].Qntd_Estoque = conteudo.Qntd_Estoque;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
            return Ok(GetLivros(conteudo.Id));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteLivros([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Id Invalido");
            }

            if (!Book.ContainsKey(id))
            {
                return BadRequest("Id nao encontrado");
            }

            Book.Remove(id);

            return Ok($"Livro com Id {id} removido com sucesso.");
        }
    }
}
