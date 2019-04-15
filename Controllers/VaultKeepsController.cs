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

    //Get public keeps
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<VaultKeep>> Get(int vaultId)
    {
      IEnumerable<VaultKeep> results = _vkr.GetKeepsByVaultId(vaultId);
      if (results == null) { return BadRequest(); }
      else { return Ok(results); }
    }
  }
}