using EspacioInterfazUsuario;
using EspacioUsuario;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_JavvG.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase {

    private IUsuarioRepository usuarioRepository;

    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger) {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    // Endpoints
    
    [HttpPost("api/usuario/Agregar")]
    public ActionResult Create(Usuario user) {

        usuarioRepository.Create(user);
        return Ok("EL usuario se ha creado exitosamente.");

    }

    [HttpPut("api/usuario/{idUser}/Nombre")] 
    public ActionResult Update(int idUser, Usuario user) {

        usuarioRepository.Update(idUser, user);

        if(user != null) {
            return Ok(user);
        }
        else {
            return BadRequest("(!) No se ha podido actualizar el usuario.");
        }

    }

    [HttpGet("api/usuario/Mostrar")]
    public ActionResult<IEnumerable<Usuario>> GetAll() {

        var usersList = usuarioRepository.GetAll();

        if(usersList != null) {
            return Ok(usersList);
        }
        else {
            return BadRequest("(!) No se pudo obtener la lista de usuarios.");
        }

    }

    [HttpGet("api/usuario/{idUser}")]
    public ActionResult<Usuario> GetById(int idUser) {

        Usuario user = usuarioRepository.GetById(idUser);

        if(user != null) {
            return Ok(user);
        }
        else {
            return BadRequest("(!) No se ha podido obtener el usuario.");
        }

    }

    /* [HttpDelete("api/usuario/{idUser}/Eliminar")]
    public ActionResult Delete(int idUser) {

        usuarioRepository.Delete(idUser);
        return Ok(" Eliminado exitosamente.");
        
    } */

}
