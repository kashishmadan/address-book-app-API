using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.CommonLayer.Model
{
    public class DeleteUserRequest
    {
        public int Id { get; set; }
    }
    public class DeleteUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
