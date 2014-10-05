using HammerCreekBrewing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerCreekBrewing.Data.ViewModels;


namespace HammerCreekBrewing.Services
{
    public interface IAuthenticationService
    {

        int Authenticate(string userName, string passWord, string defaultDomain, string[] allowedDomains);
        Dictionary<string, string> GetProperties(string userName, string[] properties);
    }
}
