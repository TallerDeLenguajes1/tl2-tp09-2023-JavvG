using System.Runtime.CompilerServices;

namespace EspacioTarea;

public enum EstadoTarea {
    Ideas,
    ToDo,
    Doing,
    Review,
    Done
}

public class Tarea {

    private int id;
    private int idUsuarioPropietario;
    private string nombre;
    private string descripcion;
    private string color;
    private EstadoTarea estado;
    private int? idUsuarioAsignado;

    public int Id { get => id; set => id = value; }
    public int IdUsuarioPropietario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Color { get => color; set => color = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
    public int? IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }

}