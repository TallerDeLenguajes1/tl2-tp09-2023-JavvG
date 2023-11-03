using EspacioTablero;
using EspacioUsuario;

namespace EspacioInterfazTablero;

public interface ITableroRepository {
    public Tablero Create();
    public void ModifyTablero(int id, Usuario usuario);
    public Tablero GetTablero(int id);
    public List<Tablero> ListTableros();
    public List<Tablero> ListTableroByUser(int idUsuario);
    public void DeleteTablero(int id);
}