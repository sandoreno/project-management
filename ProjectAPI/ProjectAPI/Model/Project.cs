using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace ProjectAPI.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public User User  { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Deleted { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
