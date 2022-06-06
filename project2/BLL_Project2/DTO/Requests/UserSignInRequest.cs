using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.DTO.Requests
{
    public class UserSignInRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
