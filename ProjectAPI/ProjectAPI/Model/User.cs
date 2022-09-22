using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
  public class User
  {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public int AccessLevelId { get; set; }
        public ICollection<Project> Projects { get; set; } //{ get; } = new List<Project>();

        /* public User()
    {
        Projects = new List<Project>();
    }*/
    }
}
