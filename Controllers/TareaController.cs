using EspacioInterfazTarea;
using EspacioTarea;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_JavvG.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase {

    private ITareaRepository tareaRepository;

    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger) {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    // Endpoints
  
    [HttpPost("api/Tarea")]
    public ActionResult<Tarea> Create(int idTablero, Tarea tarea) {
        tareaRepository.Create(idTablero, tarea);
        return Ok("La tarea se ha creado exitosamente.");
    }

    [HttpPut("api/Tarea/{idTarea}/CambiarNombre")]
    public ActionResult<Tarea> UpdateName(int idTarea, Tarea tarea) {

        tareaRepository.Update(idTarea, tarea);

        if(tarea != null) {
            return Ok(tarea);
        }
        else {
            return BadRequest("(!) No se ha podido actualizar la tarea.");
        }

    }

    [HttpPut("api/Tarea/{idTarea}/Estado/{tarea.Estado}/CambiarEstado")]
    public ActionResult<Tarea> UpdateStatus(int idTarea, Tarea tarea) {

        tareaRepository.Update(idTarea, tarea);

        if(tarea != null) {
            return Ok(tarea);
        }
        else {
            return BadRequest("(!) No se ha podido actualizar el estado de la tarea.");
        }

    }

    [HttpDelete("api/tarea/{idTarea}/Eliminar")]
    public ActionResult Delete(int idTarea) {
        tareaRepository.Delete(idTarea);
        return Ok("La tarea se ha eliminado exitosamente.");
    }

    [HttpGet("api/tarea/{tarea.Estado}")]
    public ActionResult<int> GetTaskByStatus(EstadoTarea estado) {

        List<Tarea> tareas = tareaRepository.GetAll();

        List<Tarea> tareasFiltradas = tareas.FindAll(T => T.Estado == estado);

        if(tareasFiltradas != null) {
            return Ok($"Se encontraron {tareasFiltradas.Count()} tareas con el estado {estado}.");
        }
        else {
            return BadRequest("(!) No se econtraron tareas.");
        }

    }

    [HttpGet("api/tarea/usuario/{idUsuario}/ObtenerTareasPorUsuario")]
    public ActionResult<IEnumerable<Tarea>> GetByUserId(int idUsuario) {

        List<Tarea> tareas = tareaRepository.GetByUsuarioId(idUsuario);

        if(tareas != null) {
            return tareas;
        }
        else {
            return BadRequest($"(!) No se encontraron tareas asignadas al usuario ID {idUsuario}.");
        }

    }

    [HttpGet("api/tarea/tablero/{idTablero}/ObtenerTareasPorTablero")]
    public ActionResult<IEnumerable<Tarea>> GetByTableroId(int idTablero) {

        List<Tarea> tareas = tareaRepository.GetByTableroId(idTablero);

        if(tareas != null) {
            return tareas;
        }
        else {
            return BadRequest($"(!) No se encontraron tareas asignadas al tablero ID {idTablero}");
        }

    }

}
