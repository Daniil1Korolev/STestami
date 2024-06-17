using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remont
{
    public class Functional
    {
        public remontEntities db = new remontEntities();

        public int CountApplication()
        {
            return db.Applications.Where(a => a.Status.NameStatus == "Выполнено").ToList().Count;
        }
        public int CountRoles()
        {
            return db.Role.ToList().Count;

        }
            public int CountUser()
            {
                return db.User.ToList().Count;
            }

        }
}