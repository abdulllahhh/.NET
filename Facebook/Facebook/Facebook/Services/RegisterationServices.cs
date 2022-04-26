using Facebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facebook.Services
{
    public interface IRegistrationServices
    {
        User create(User user);
    }
    public class RegistrationServices : IRegistrationServices
    {
        private readonly FacebookDbEntities facebookDbEntities;
        public RegistrationServices()
        {
            facebookDbEntities = new FacebookDbEntities();
        }

        public User create(User user)
        {
            facebookDbEntities.Users.Add(user);
            int savingResults =facebookDbEntities.SaveChanges();
            if(savingResults>0)
            {
                return user;
            }
            return null;
            
        }

       
    }
}