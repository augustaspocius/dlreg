using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLRegIdentity.Controllers
{
    public class RegisterController : IAuthorizationRequirement
    {

        public RegisterController()
        {
           
        }
    }
}
