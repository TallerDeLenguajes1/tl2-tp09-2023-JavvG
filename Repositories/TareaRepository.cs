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
        throw new NotImplementedException();
    }

    public Tarea GetById(int id) {
        throw new NotImplementedException();
    }

    public List<Tarea> GetByUsuarioId(int idUsuario) {
        throw new NotImplementedException();
    }

    public void Remove(int idTarea) {
        throw new NotImplementedException();
    }

    public void Update(int id, Tarea tarea) {
        throw new NotImplementedException();
    }
}
