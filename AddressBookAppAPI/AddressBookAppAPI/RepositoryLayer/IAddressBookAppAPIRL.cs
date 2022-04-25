using AddressBookAppAPI.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.RepositoryLayer
{
    public interface IAddressBookAppAPIRL
    {
        public Task<AddUserResponse> AddUser(AddUserRequest request);
        Task<GetAllUsersResponse> GetAllUsers();
        public Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request);
        public Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request);
    }
}
