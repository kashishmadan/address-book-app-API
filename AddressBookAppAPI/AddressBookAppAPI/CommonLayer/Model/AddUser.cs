using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.CommonLayer.Model
{
    public class AddUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class AddUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
