using EspacioTarea;

namespace EspacioInterfazTarea;

public interface ITareaRepository {

    public Tarea Create(int idTablero);
    public void Update(int id, Tarea tarea);
    public Tarea GetById(int id);
    public List<Tarea> GetByUsuarioId(int idUsuario);
    public List<Tarea> GetAll(int idTablero);
    public void Delete(int idTarea);
    public void Assign(int idUsuario, int idTarea);

}