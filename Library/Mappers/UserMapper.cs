using Library.Entity;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Mappers
{
    public class UserMapper : IMapper<User, UserViewModel>
    {
        public UserMapper()
        {
        }

        public UserViewModel Map(User user)
        {
            UserViewModel model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber

            };

            return model;
        }

        public User Map(UserViewModel model)
        {
          
            User user = new User()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
        
            return user;
        }

        public User Map(UserViewModel model, User user)
        {
            return new User();
        }

        public List<UserViewModel> Map(List<User> entity)
        {
            List<UserViewModel> models = new List<UserViewModel>();
            foreach (var item in entity)
            {
                models.Add(Map(item));
            }

            return models;
        }

        public List<User> Map(List<UserViewModel> model)
        {
            List<User> users = new List<User>();
            foreach (var item in model)
            {
                users.Add(Map(item));
            }

            return users;
        }
    }
}