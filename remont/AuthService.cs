using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remont
{
    public class AuthService
    {
        private readonly remontEntities _context;

        public AuthService(remontEntities context)
        {
            _context = context;
        }

        public User Authenticate(string login, string password)
        {
            return _context.User.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }

    public class AuthorizationService
    {
        public bool Authorize(User user, string requiredRole)
        {
            return user.Role != null && user.Role.NameRole == requiredRole;
        }
    }
}