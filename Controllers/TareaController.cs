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
  
    

}
