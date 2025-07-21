using AlbumsOfOliverDragojevic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlbumsOfOliverDragojevic.Enums.UserRole;

namespace AlbumsOfOliverDragojevic.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public UserRoles UserRole { get; set; }

        public User() { }

        public User(string username, string password, UserRoles userRole)
        {
            Username = username;
            Password = password;
            UserRole = userRole;
        }
    }
}
