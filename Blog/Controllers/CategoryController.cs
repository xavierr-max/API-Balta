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
            [FromServices]BlogDataContext context)
        {
            var categories = await context.Categories.ToListAsync(); //await vai fazer o método ser concluído, ou seja, ele aguarda o fim da execução
            return Ok(categories);
        }

        
    }
}
