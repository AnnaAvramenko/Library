using Library.Entity;
using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Library.Services
{

    public interface IUserService
    {

        UserViewModel GetUserById(int id);
        List<UserViewModel> GetAllUsers();
    }

    public class UserService: IUserService
    {

            private IRepo<User> repoUser;
            private IMapper<User, UserViewModel> userMapper;


            public UserService(IRepo<User> repoUser,  IMapper<User, UserViewModel> userMapper)
            {
                this.repoUser = repoUser;
                this.userMapper = userMapper;
            }

            public UserViewModel GetUserById(int id)
            {
                var user = repoUser.Get(id);
                return userMapper.Map(user);
            }

            public List<UserViewModel> GetAllUsers()
            {
                var users = repoUser.GetAll();
                return userMapper.Map(users);
            }


    }
}