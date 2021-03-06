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
  [Authorize]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkr;

    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    //Create Keep
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody]VaultKeep newVK)
    {
      newVK.UserId = HttpContext.User.Identity.Name;
      VaultKeep vk = _vkr.CreateVK(newVK);
      if (vk == null) { return BadRequest(); }
      else { return Ok(vk); }

    }

    //Get Keeps by Vault Id
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      IEnumerable<Keep> results = _vkr.GetKeepsByVaultId(vaultId);
      if (results == null) { return BadRequest(); }
      else { return Ok(results); }
    }

    [HttpDelete("{vaultId}/keep/{keepId}")]
    public ActionResult<string> Delete(int vaultId, int keepId)
    {
      bool wasSuccessful = _vkr.DeleteVK(vaultId, keepId);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }
  }




  //PUT body vaultId, KeepId

  //DELETE  vaultkeeps/:vaultId/keep/:keepId


}