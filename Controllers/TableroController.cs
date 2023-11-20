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
  
    

}
