using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Controllers.DTOS;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();


        }
        [HttpPost]
        public void CrearProductos([FromBody] PostProducto producto)
        {

        }
        [HttpPut]
        public void ModificarProducto([FromBody] PutProducto producto)
        {
            
        }
        [HttpDelete]
        public void EliminarProducto([FromBody] DeleteProducto producto)
        {

        }
    }
}
