using Microsoft.AspNetCore.Mvc;

namespace Entrega_Final.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TraerNombreController : ControllerBase
    {
        [HttpGet]

        public string TraerNombre()
        {
            return "Electro Mundo";
        }
    }
}
