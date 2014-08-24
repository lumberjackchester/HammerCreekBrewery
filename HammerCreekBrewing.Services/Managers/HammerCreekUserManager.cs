using HammerCreekBrewing.Data.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Services.Managers
{
    public class HammerCreekUserManager : UserManager<ApplicationUser>
    {
        public HammerCreekUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}
