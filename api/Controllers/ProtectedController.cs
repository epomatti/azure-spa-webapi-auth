using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class ProtectedController : ControllerBase
{
  private readonly ILogger<ProtectedController> _logger;

  public ProtectedController(ILogger<ProtectedController> logger)
  {
    _logger = logger;
  }

  [HttpGet(Name = "GetProtected")]
  public ProtectedResponse Get()
  {
    return new ProtectedResponse
    {
      ProtectedValue = "This information is protected."
    };
  }
}
