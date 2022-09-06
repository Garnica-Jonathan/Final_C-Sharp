using Entrega_Final.Controllers.PTOS;
using Entrega_Final.Modelo;
using Entrega_Final.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Entrega_Final.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]

        public List<Producto> GetProducto()
        {
            return ProductoHandler.GetProducto();
        }

        [HttpPost]

        public bool CrearProducto([FromBody] PostProducto producto)
        {
            return ProductoHandler.CrearProducto(new Producto
            {
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario
            });
        }

        [HttpPut]

        public bool ModificarProducto([FromBody] PutProducto producto)
        {
            return ProductoHandler.ModificarProducto(new Producto
            {
                Id=producto.Id,
                Descripciones=producto.Descripciones,
                Costo=producto.Costo,
                PrecioVenta=producto.PrecioVenta,
                Stock=producto.Stock,
                IdUsuario=producto.IdUsuario
            });
        }

        [HttpDelete]

        public bool EliminarProducto([FromBody] DeleteProducto producto)
        {
            return ProductoHandler.EliminarProducto(new Producto
            {
                Id = producto.Id,
            });
        }
    }
}
