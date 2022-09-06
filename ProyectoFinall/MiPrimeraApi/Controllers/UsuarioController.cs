using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Controllers.DTOS;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name ="ConseguirUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
            
            
        }
        [HttpDelete]
        public bool EliminarUsuarios([FromBody] int id)
        {

            return UsuarioHandler.EliminarUsuarios(id);

        }
        [HttpPost]
        public void ModificarUsuario([FromBody] PutUsuario usuario)
        {

        }
        [HttpPost]
        public void CrearProducto([FromBody] PostProducto producto)
        {

        }

    }
}
