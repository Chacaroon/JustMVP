using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustMVP.BLL.Interfaces;
using JustMVP.DAL;
using JustMVP.Domain;
using JustMVP.Web.Models;
using JustMVP.Web.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JustMVP.Web.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResultModel>> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
                return Failure(ErrorTypeEnum.NotAuthorized);

            var result = new LoginResultModel
            {
                AccessToken = _tokenService.GenerateJwt(user.Id, user.UserName)
            };

            return Success(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResultModel>> Register([FromBody] RegisterModel model)
        {
            var user = new User(model.UserName);
            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
                return Failure(ErrorTypeEnum.Custom, "REGISTRATION_FAILED");

            var result = new LoginResultModel
            {
                AccessToken = _tokenService.GenerateJwt(user.Id, user.UserName)
            };

            return Success(result);
        }
    }
}
