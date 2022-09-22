using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace ProjectAPI.VievModels
{
    public class UsersModel
    {
        public UsersModel(User user)
        {
            userId = user.UserId;
            firstName = user.FirstName;
            lastName = user.LastName;
            login = user.Login;
            role = user.AccessLevel.Role;
        }

        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string role { get; set; }
    }
}
