using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JustMVP.Domain
{
    public class User : IdentityUser<int>
    {
        public User(string userName) : base(userName)
        {
        }
    }
}
