using AddressBookAppAPI.CommonLayer.Model;
using AddressBookAppAPI.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.ServiceLayer
{
    public class AddressBookAppAPISL : IAddressBookAppAPISL
    {
        public readonly IAddressBookAppAPIRL _addressBookAppAPIRL;

        public AddressBookAppAPISL(IAddressBookAppAPIRL addressBookAppAPIRL)
        {
            _addressBookAppAPIRL = addressBookAppAPIRL;
        }

        public async Task<AddUserResponse> AddUser(AddUserRequest request)
        {
            return await _addressBookAppAPIRL.AddUser(request);
        }

        public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request)
        {
            return await _addressBookAppAPIRL.DeleteUser(request);
        }

        public async  Task<GetAllUsersResponse> GetAllUsers()
        {
            return await _addressBookAppAPIRL.GetAllUsers();
        }

        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
        {
            return await _addressBookAppAPIRL.UpdateUser(request);
        }
    }
}
