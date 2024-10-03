using MeuBolso.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
