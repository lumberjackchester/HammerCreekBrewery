using HammerCreekBrewing.Data;
using HammerCreekBrewing.Data.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerCreekBrewing.Data.Entities;
using HammerCreekBrewing.Services.Managers;

namespace HammerCreekBrewing.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private AuthContext _db;
        private HammerCreekUserManager  _userManager;


        public AuthenticationService(AuthContext auth, HammerCreekUserManager  userManager)
        {
            _db =auth;
           // _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_db));
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(UserViewModel userModel)
        {
            var user = new  ApplicationUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);

            return user;
        }
        public async Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo)
        {
            ApplicationUser user = await _userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);

            return result;
        }


        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }
       public Client FindClient(string clientId)
        {
            var client = _db.Clients.Find(clientId);

            return client;
        }
       public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
       {
           var refreshToken = await _db.RefreshTokens.FindAsync(refreshTokenId);

           return refreshToken;
       }
       public async Task<bool> AddRefreshToken(RefreshToken token)
       {

           var existingToken = _db.RefreshTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();

           if (existingToken != null)
           {
               var result = await RemoveRefreshToken(existingToken);
           }

           _db.RefreshTokens.Add(token);

           return await _db.SaveChangesAsync() > 0;
       }
       public async Task<bool> RemoveRefreshToken(string refreshTokenId)
       {
           var refreshToken = await _db.RefreshTokens.FindAsync(refreshTokenId);

           if (refreshToken != null)
           {
               _db.RefreshTokens.Remove(refreshToken);
               return await _db.SaveChangesAsync() > 0;
           }

           return false;
       }

       public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
       {
           _db.RefreshTokens.Remove(refreshToken);
           return await _db.SaveChangesAsync() > 0;
       }
        void IDisposable.Dispose()
        {
            _db.Dispose();
            _userManager.Dispose();
        }
         
    }
}
