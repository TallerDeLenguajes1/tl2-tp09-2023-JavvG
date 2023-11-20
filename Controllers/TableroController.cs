using EspacioInterfazTablero;
using EspacioTablero;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_JavvG.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase {

    private ITableroRepository tableroRepository;

    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger) {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    // Endpoints

    [HttpPost("api/Tablero")]
    public ActionResult Create(Tablero tablero) {
        tableroRepository.Create(tablero);
        return Ok("El tablero se ha creado exitosamente");
    }

    [HttpPost("api/tableros")]
    public ActionResult<IEnumerable<Tablero>> GetAll() {
        var tablerosList = tableroRepository.GetAll();

        if(tablerosList != null) {
            return Ok(tablerosList);
        }
        else {
            return BadRequest("(!) No se pudieron obtener todos los tableros.");
        }
    }

}
