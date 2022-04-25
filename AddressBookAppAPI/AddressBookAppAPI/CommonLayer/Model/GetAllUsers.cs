using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.CommonLayer.Model
{
    public class GetAllUsersResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetAllUsersData> getAllUsersData { get; set; }
    }

    public class GetAllUsersData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
