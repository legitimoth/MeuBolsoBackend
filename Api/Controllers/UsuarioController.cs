using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeuBolso.Api.Dtos;

namespace MeuBolso.Api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<UsuarioDto> Get()
        {
            return new UsuarioDto
            {
                Id = 1,
                Nome = "",
                Sobrenome = "",
                Email = "",
            };
        }
    }
}
