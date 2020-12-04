using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    class UserService
    {
        private readonly ParcialContext _context;

        public UserService(ParcialContext context) => _context = context;

        public User Validate(string userName, string password)
        {
            return _context.Users.FirstOrDefault(t => t.UserName == userName && t.Password == password && t.Estado == "AC");
        }

    }
}
