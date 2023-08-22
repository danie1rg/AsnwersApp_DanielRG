using AsnwersApp_DanielRG.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsnwersApp_DanielRG.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }

        public UserDTO MyUserDTO { get; set; }

        public UserViewModel() 
        {
            MyUser = new User();
            MyUserDTO = new UserDTO();
        }

        public async Task<UserDTO> GetUserDataAsync()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();

                userDTO = await MyUserDTO.GetUser(3);

                if (userDTO == null) return null;

                return userDTO;

            }
            catch
            (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<User> GetUsuarioDataAsync()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                User user = new User();

                user = await MyUser.GetUsuario();

                if (user == null) return null;

                return user;

            }
            catch
            (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }


    }
}
