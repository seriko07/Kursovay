using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovay
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Patronomyc { get; set; }
        public int GenderID { get; set; }
        public int Role { get; set; }
    }

}
