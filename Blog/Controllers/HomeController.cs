using Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("v1/health")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")] 
        [ApiKey]
        public IActionResult Get()
        {
            return Ok();
        }
        //a estrutura acima é apenas um controller de vereficação do status da API
    }
}
