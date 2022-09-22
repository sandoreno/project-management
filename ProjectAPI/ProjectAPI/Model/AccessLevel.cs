using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace ProjectAPI.Model
{
    public class AccessLevel
    {
        public int AccessLevelId { get; set; }
        public string Role { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
