using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  private readonly IAuthenticationService _authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    AuthenticationResult result = _authenticationService.Register(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password);

    AuthenticationResponse response = new AuthenticationResponse(
      result.User.Id,
      result.User.FirstName,
      result.User.LastName,
      result.User.Email,
      result.Token);

    return Ok(response);
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    AuthenticationResult result = _authenticationService.Login(
      request.Email,
      request.Password);

    AuthenticationResponse response = new AuthenticationResponse(
      result.User.Id,
      result.User.FirstName,
      result.User.LastName,
      result.User.Email,
      result.Token);

    return Ok(response);
  }
}