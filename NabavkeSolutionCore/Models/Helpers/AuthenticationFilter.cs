using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NabavkeSolutionCore.Controllers;
using NabavkeSolutionCore.Data.Models.Code_First_DB;
using NabavkeSolutionCore.Data.Persistence;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace NabavkeSolutionCore.Models.Helpers
{
    public class AuthenticationFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var actionContext = context.HttpContext;

            var authenticateKey = context.HttpContext.Request.Headers
                .Where(n=>n.Key== "Authorization").First().Value;

            ///If there is no Authorization Header
            if (String.IsNullOrEmpty(authenticateKey.ToString()))
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);

            string authenticationToken = actionContext.Request.Headers
                .SingleOrDefault(n => n.Key == "Authorization").Value.ToString().Replace("Basic ","");
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
            string userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
            string providedUserPassword = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

            ///If provided user dont exist in db
            if (!((NabavkeController)context.Controller).db.Users.Any(n => n.UserName == userName))
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);

            var userDb = ((NabavkeController)context.Controller).db.Users.First(n => n.UserName == userName);
            PasswordHasher<AppUser> passHasher = new PasswordHasher<AppUser>();
            var providedHasherdPass = passHasher.HashPassword(userDb, providedUserPassword);
            var result = passHasher.VerifyHashedPassword(userDb, userDb.PasswordHash, providedUserPassword);

            ///If provided password dont mach
            if (result == PasswordVerificationResult.Success ||
                result == PasswordVerificationResult.SuccessRehashNeeded) { }
            else context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);

            ///If passward need to be rehached
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                userDb.PasswordHash = providedHasherdPass;
                ((NabavkeController)context.Controller).db.SaveChangesAsync();
            }

            base.OnActionExecuting(context);
        }
    }
}