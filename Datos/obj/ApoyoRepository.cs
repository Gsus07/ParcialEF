namespace Datos.obj
{
    public class Apoyo
    {
        private readonly MySqlConnection _connection;
        private readonly List<Apoyo> _apoyos = new List<Apoyo>();
        public ApoyoRepository(ConnectionManager connection)
        {
            _connection = connection._connection;
        }
        public void Guardar(Apoyo apoyo)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona (identificacion,nombre,edad,sexo,departamento,ciudad,valorApoyo,modalidadApoyo,fecha) 
                                        values (@Identificacion,@Nombre,@Edad,@Sexo,@Departamento,@Ciudad,@ValorApoyo,@ModalidadApoyo,@Fecha)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Departamento", persona.Departamento);
                command.Parameters.AddWithValue("@Ciudad",persona.Ciudad);
                command.Parameters.AddWithValue("@ValorApoyo",persona.ValorApoyo);
                command.Parameters.AddWithValue("@ModalidadApoyo",persona.ModalidadApoyo);
                command.Parameters.AddWithValue("@Fecha",persona.Fecha);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}