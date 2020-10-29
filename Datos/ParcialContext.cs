using System.ComponentModel;
using System.IO.Pipes;
using System;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Entidad;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class ParcialContext: DbContext
    {
        //private readonly MySqlConnection _connection;
        
        public ParcialContext(DbContextOptions options): base(options){}
        public  DbSet<Persona> Personas { get; set; }
    }
}