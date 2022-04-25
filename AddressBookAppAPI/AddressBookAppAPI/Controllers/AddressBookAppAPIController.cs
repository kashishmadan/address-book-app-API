using AddressBookAppAPI.CommonLayer.Model;
using AddressBookAppAPI.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookAppAPIController : ControllerBase
    {
        public readonly IAddressBookAppAPISL _addressBookAppAPISL;
        public AddressBookAppAPIController(IAddressBookAppAPISL addressBookAppAPISL)
        {
            _addressBookAppAPISL=addressBookAppAPISL;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(AddUserRequest request)
        {
            AddUserResponse response = null;
            try
            {
                response = await _addressBookAppAPISL.AddUser(request);

            } catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            GetAllUsersResponse response = null;
            try
            {
                response = await _addressBookAppAPISL.GetAllUsers();
            } catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
        {
            UpdateUserResponse response = null;
            try
            {
                response = await _addressBookAppAPISL.UpdateUser(request);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest request)
        {
            DeleteUserResponse response = null;
            try
            {
                response = await _addressBookAppAPISL.DeleteUser(request);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            return Ok(response);
        }
    }
}
