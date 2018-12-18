using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LibraryAssessment
{
    public class ApplictionsUser : IdentityUser
    {
        public virtual string Email { get; set; }
    }
}
