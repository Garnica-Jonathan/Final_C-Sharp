using Entrega_Final.Controllers.PTOS;
using Entrega_Final.Modelo;
using Entrega_Final.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Entrega_Final.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{id}")]

        public Usuario GetTraerNombre(int id)
        {
            return UsuarioHandler.GetTraerNombre(id);
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public bool InicioSesion(string nombreUsuario, string contraseña)
        {
            Usuario usuario = UsuarioHandler.InicioSesion(nombreUsuario, contraseña);
            if(usuario.NombreUsuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        [HttpPost]

        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            return UsuarioHandler.CrearUsuario( new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail
            });
        }

        [HttpPut]

        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario =usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail
            });
            
        }

        [HttpDelete]

        public bool EliminarUsuario([FromBody] DeleteUsuario usuario)
        {
            return UsuarioHandler.EliminarUsuario(new Usuario { 
            
            Id = usuario.Id,
            
            });;
        }

        

    }
}
