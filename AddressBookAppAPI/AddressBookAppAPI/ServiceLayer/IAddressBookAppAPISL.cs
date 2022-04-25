using AddressBookAppAPI.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.ServiceLayer
{
    public interface IAddressBookAppAPISL
    {
        public Task<AddUserResponse> AddUser(AddUserRequest request);

        public Task<GetAllUsersResponse> GetAllUsers();

        public Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request);

        public Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request);
    }
}
