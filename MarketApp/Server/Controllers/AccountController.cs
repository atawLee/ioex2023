using MarketApp.Server.Service;
using MarketApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MarketApp.Server.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class AccountController: ControllerBase
{
    private readonly AccountService _service;

    public AccountController(AccountService service)
    {
        _service = service;
    }

    [HttpPost]
    public void SignUp([FromBody] SignUpRequest param)
    {
        _service.SignUp(param.email,param.userName,param.userRole,param.password);
    }

    [HttpGet]
    public UserDto SignIn([FromBody] SignInRequest param)
    {
        return _service.SignIn(param.email, param.password);
    }
}