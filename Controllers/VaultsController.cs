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

    //Get public keeps
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      IEnumerable<Keep> results = _vr.GetAllPublic();
      if (results == null) { return BadRequest(); }
      else { return Ok(results); }
    }

    //Get User Keeps
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetOne()
    {
      string id = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _kr.GetById(id);
      if (results == null) { return BadRequest(); }
      else { return Ok(_kr.GetById(id)); }
    }

    //Create a Keep
    [HttpPost]
    public ActionResult<Keep> Create([FromBody]Keep newKeep)
    {
      return _kr.CreateKeep(newKeep);
    }

    //Delete a Keep
    [HttpDelete("{keepId}")]

    public ActionResult<string> Delete(string keepId)
    {
      bool wasSuccessful = _kr.DeleteKeep(keepId);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}