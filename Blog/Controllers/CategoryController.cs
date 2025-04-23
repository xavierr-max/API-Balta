using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")] /* localhost:PORT/v1/categories 
        SEMPRE USE NO MINÚSCULO E PLURAL É PADRÃO
        o v1 é o versiomaneto do código */
        public async Task<IActionResult> GetAsync( //o async tem função de exercutar várias requisições ao mesmo tempo
            [FromServices] BlogDataContext context)
        {
            var categories = await context.Categories.ToListAsync(); //await vai fazer o método ser concluído, ou seja, ele aguarda o fim da execução
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id, //o FromRoute é para pegar o id da URL
            [FromServices] BlogDataContext context)
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound();

            return Ok(category);
            //faz um filtro pelo id na url, se encontrar retorna os dados dessa categoria
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
            [FromBody] Category model,
            [FromServices] BlogDataContext context)
        {
            try
            {
                await context.Categories.AddAsync(model);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{model.Id}", model);
                //cria uma nova categoria no banco com os dados em JSON e cria uma url com seu id
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Não foi possível incluir a categoria");
                //caso não consiga encontrar a categoria, retorna um erro
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] Category model,
            [FromServices] BlogDataContext context)
        {
            var categories = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categories == null)
                return NotFound();

            categories.Name = model.Name;
            categories.Slug = model.Slug;

            context.Categories.Update(categories);
            await context.SaveChangesAsync();

            return Created($"v1/categories/{model.Id}", model);
            //da um update em uma categoria pelo seu id, caso não encontre, retorna com notfound
        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound();

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return Ok(category);
        }



    }
}
