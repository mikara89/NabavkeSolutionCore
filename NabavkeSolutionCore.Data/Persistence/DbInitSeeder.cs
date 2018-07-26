using Microsoft.AspNetCore.Identity;
using NabavkeSolutionCore.Data.Models.Code_First_DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using NabavkeSolutionCore.Data.Models.Code_First_DB.HelperModel;

namespace NabavkeSolutionCore.Data.Persistence
{
    public class DbInitSeeder
    {
        private readonly UserManager<AppUser> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;
        private readonly IOptions<AdminInit> _adminInit;

        public DbInitSeeder(
            UserManager<AppUser> userMgr,
            RoleManager<IdentityRole> roleMgr,
            IOptions<AdminInit> adminInit)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
            _adminInit = adminInit;
        }
        public async Task Seed()
        {
            var user = await _userMgr
                .FindByNameAsync(_adminInit.Value.UserName);

            if (user != null) return;
            if (!(await _roleMgr.RoleExistsAsync(_adminInit.Value.Role)))
            {
                var role = new IdentityRole(_adminInit.Value.Role);
                //role.Claims.Add(new IdentityRoleClaim<string>()
                //{ ClaimType = "IsAdmin", ClaimValue = "True" });
                await _roleMgr.CreateAsync(role);
            }
            user = new AppUser()
            {
                UserName = _adminInit.Value.UserName,
                FirstName = _adminInit.Value.FirstName,
                LastName = _adminInit.Value.LastName,
                Email = _adminInit.Value.Email
            };

            var userResult = await _userMgr
                .CreateAsync(user, _adminInit.Value.Password);
            var roleResult = await _userMgr
                .AddToRoleAsync(user, _adminInit.Value.Role);
            var claimResult = await _userMgr
                .AddClaimAsync(user, new Claim(_adminInit.Value.Claim, "True"));

            if (!userResult.Succeeded ||
                !roleResult.Succeeded ||
                !claimResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to build user and roles");
            }
        }
    }
}
