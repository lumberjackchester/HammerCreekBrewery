using HammerCreekBrewing.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using HammerCreekBrewing.Data.Entities;


namespace HammerCreekBrewing.Services
{
    public interface IAuthenticationService : IDisposable
    {
       Task<IdentityResult> RegisterUser(UserViewModel userModel);

       Task<ApplicationUser> FindUser(string userName, string password);

       Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo);
       Client FindClient(string clientId);

       Task<IdentityResult> CreateAsync(ApplicationUser user);

       Task<IdentityResult> AddLoginAsync(string p, UserLoginInfo userLoginInfo);
       Task<RefreshToken> FindRefreshToken(string refreshTokenId);
       Task<bool> AddRefreshToken(RefreshToken token);
       Task<bool> RemoveRefreshToken(string refreshTokenId);
    }
}
