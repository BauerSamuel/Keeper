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

  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;

    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }

    //Get user vaults
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      string id = HttpContext.User.Identity.Name;
      IEnumerable<Vault> results = _vr.GetUserVaults(id);
      if (results == null) { return BadRequest(); }
      else { return Ok(results); }
    }

    public ActionResult<Vault> Get()
    {
      //Finsih after lunch.
    }


    //Create a vault
    [HttpPost]
    public ActionResult<Vault> Create([FromBody]Vault newVault)
    {
      return _vr.CreateVault(newVault);
    }

    //Delete a Vault
    [HttpDelete("{vaultId}")]

    public ActionResult<string> Delete(string vaultId)
    {
      bool wasSuccessful = _vr.DeleteVault(vaultId);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}