using Facebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facebook.Services
{
    public interface IUserServices
    {
        bool Login(string email, string password);
        bool logout();
    }
    public class UserService : IUserServices
    {
        public FacebookDbEntities context { get; set; }
        public UserService()
        {
            context = new FacebookDbEntities();
        }
        public bool Login(string email, string password)
        {
            return context.Users.
                Where(a => a.Email == email && a.Password == password).
                Any();
        }

        public bool logout()
        {
            throw new NotImplementedException();
        }
       

    }
}