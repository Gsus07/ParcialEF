/*using Datos;

namespace Logica
{
    public class ApoyoService
    {
         private readonly ConnectionManager conexion;
        private readonly ApoyoRepository repositorio;
        public ApoyoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ApoyoRepository(conexion);
        }
        public bool Guardar(Apoyo apoyo)
        {
            try
            {          
                conexion.Open();
                repositorio.Guardar(apoyo);
                conexion.Close();
                return true;
            }
            catch (Exception e)
            { return false; }
            finally { conexion.Close(); }
        }
    }
}*/