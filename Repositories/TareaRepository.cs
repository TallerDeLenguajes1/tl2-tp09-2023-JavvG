using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EspacioInterfazTarea;
using EspacioTarea;

public class TareaRepository : ITareaRepository {

    private readonly string connectionString = "Data Source=DB/kanban.db;Cache=Shared";

    public void Assign(int idUsuario, int idTarea) {
        
        var query = @"UPDATE Tarea SET id_usuario_asignado = @id_usuario WHERE id = @id_tarea;";

        using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {

            connection.Open();

            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@id_usuario", idUsuario));
            command.Parameters.Add(new SQLiteParameter("@id_tarea", idTarea));

            command.ExecuteNonQuery();
            
            connection.Close();

        }

    }

    public Tarea Create(int idTablero) {
        throw new NotImplementedException();
    }

    public List<Tarea> GetAll(int idTablero) {
        
        List<Tarea> tareas = new();

        var query = @"SELECT * FROM Tarea;";

        using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {

            connection.Open();

            var command = new SQLiteCommand(query, connection);

            using (var reader = command.ExecuteReader()) {

                while (reader.Read()) {

                    var tarea = new();

                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.idTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Estado = reader["estado"];        // Revisar (!)
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);

                    tareas.Add(tarea);

                }

            }

            connection.Close();

        }

        return tareas;

    }

    public Tarea GetById(int id) {
        
        List<Tarea> tareas = new();

        tareas = GetAll();

        var tareaBuscada = tareas.FirstOrDefault(T => T.Id == id);

        return tareaBuscada;

    }

    public List<Tarea> GetByUsuarioId(int idUsuario) {
        
        List<Tarea> tareas = new();

        tareas = GetAll();

        var tareaBuscada = tareas.FirstOrDefault(T.IdUsuarioAsignado == id);

        return tareaBuscada;

    }

    public void Delete(int idTarea) {
        
        var query = @"DELETE FROM Tarea WHERE Tarea.id = (@id_buscado);";

        using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {

            connection.Open();

            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@id_buscado", idTarea));

            command.ExecuteNonQuery();

            connection.Close();

        }

    }

    public void Update(int id, Tarea tarea) {
        
        var query = @"UPDATE Tarea SET id_tablero = @nuevo_id_talero, nombre = @nuevo_nombre, estado = @nuevo_estado, descripcion = @nueva_descripcion, color = @nuevo_color, id_usuario_asignado = @nuevo_id_usuario;";

        using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {

            connection.Open();

            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@nuevo_id_talero", tarea.IdTablero));
            command.Parameters.Add(new SQLiteParameter("@nuevo_nombre", tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@nuevo_estado", tarea.Estado));     // Revisar (!)
            command.Parameters.Add(new SQLiteParameter("@nueva_descripcion", tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@nuevo_color", tarea.Color));
            command.Parameters.Add(new SQLiteParameter("@nuevo_id_usuario", tarea.IdUsuarioAsignado));

            command.ExecuteNonQuery();

            connection.Close();

        }

    }
}
