using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class Tasks
    {
        public int TasksId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Progress { get; set; }
        public string Dependecies { get; set; }
        public bool Deleted { get; set; }
    }
}
