using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLRegIdentity.Data
{
    /// <summary>
    /// User data and profile for our app
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string DataEventRecordsRole { get; set; }
        public string SecuredFilesRole { get; set; }
    }
}
