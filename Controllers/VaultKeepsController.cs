using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//Talks to Repositories
namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkr;

    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody]VaultKeep newVK)
    {
      string UserId = HttpContext.User.Identity.Name;
      VaultKeep vk = _vkr.CreateVK(newVK, UserId);
      if (vk == null) { return BadRequest(); }
      else { return vk; }

    }

    //Get public vault keeps
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _vkr.GetKeepsByVaultId(vaultId, userId);
      if (results == null) { return BadRequest(); }
      else { return Ok(results); }
    }
  }
}