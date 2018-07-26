using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NabavkeSolutionCore.Data.Models.Code_First_DB;
using NabavkeSolutionCore.Data.Persistence;
using NabavkeSolutionCore.Models.Helpers;

namespace NabavkeSolutionCore.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        public readonly NabavkeSolutionCoreDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IOptions<ConfigIssuer> _configIssuer;
        private readonly ILogger<AuthController> _logger;


        public AuthController(NabavkeSolutionCoreDbContext db,
            UserManager<AppUser> userManager,
            IMapper mapper,
            IPasswordHasher<AppUser> passwordHasher,
            IOptions<ConfigIssuer> configIssuer,
            ILogger<AuthController> logger)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _configIssuer = configIssuer;
            _logger = logger;
        }
        // POST api/auth/create
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AccountRegisterLogin model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            var user = new AppUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                _logger.LogWarning($"Error in Creating Account: {result.Errors.Select(x => x.Description).ToList()}");
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }

            return Created("", new { user = model.Email });
        }
        // POST api/auth/token
        [HttpPost("token")]
        public async Task<IActionResult> CreateToken([FromBody] AccountRegisterLogin model)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Invalid body content");
                }

                //var user = await _userManager.FindByEmailAsync(model.Email);
                var user = _userManager.Users.ToList().First(n=>n.Email==model.Email);
                if (user == null ||
                    _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) 
                    != PasswordVerificationResult.Success)
                {
                    if (user != null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password)
                        == PasswordVerificationResult.SuccessRehashNeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                        await _db.SaveChangesAsync();
                    }
                    else return BadRequest();
                }

                var token = await GetJwtSecurityToken(user);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to generate token: +{ex}");
            }
            return BadRequest("Faild to generate token");
        }
        private async Task<JwtSecurityToken> GetJwtSecurityToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            return new JwtSecurityToken(
                issuer: _configIssuer.Value.Issuer,
                audience: _configIssuer.Value.Audience,
                claims: GetTokenClaims(user).Union(userClaims),
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configIssuer.Value.Key)), SecurityAlgorithms.HmacSha256)
            );
        }
        private static IEnumerable<Claim> GetTokenClaims(AppUser user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };
        }
    }
}