using EspacioUsuario;

namespace EspacioInterfazUsuario;

public interface IUsuarioRepository {
    public void Create(Usuario usuario);
    public void Modify(int id, Usuario usuaerio);
    public List<Usuario> ListUsuarios();
    public Usuario GetUsuario(int id);
    public void DeleteUsuario(int id);
}
