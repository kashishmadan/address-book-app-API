using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.CommonLayer.Model
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
    }

    public class UpdateUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
