using BilgeShop.Business.Dtos;
using BilgeShop.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Services
{
    public interface IUserService
    {

        ServiceMessage AddUser(UserDto userDto);
        UserDto Login(LoginDto loginDto);

        void UpdateUser(UserProfileEditDto userProfileDto);
    }
}
