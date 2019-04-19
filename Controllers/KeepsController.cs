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

  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _kr;

    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }

    //Get public keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetAllPublic();
      if (results == null) { return BadRequest(); }
      else { return Ok(results); }
    }

    //Get User Keeps
    //look at all users keeps
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetMyKeeps()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _kr.GetById(userId);
      if (results == null) { return BadRequest(); }
      else { return Ok(results); }
    }

    //Create a Keep
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody]Keep newKeep)
    {
      string id = HttpContext.User.Identity.Name;
      newKeep.UserId = id;
      return _kr.CreateKeep(newKeep);
    }

    [Authorize]
    [HttpPut("{keepId}/k")]
    public ActionResult<string> UpdateKeeps(int keepId)
    {

      bool wasSuccessful = _kr.IncrementKeeps(keepId);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }

    [Authorize]
    [HttpPut("{keepId}/s")]
    public ActionResult<string> UpdateShares(int keepId)
    {

      bool wasSuccessful = _kr.IncrementShares(keepId);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }


    //Delete a Keep
    [Authorize]
    [HttpDelete("{keepId}")]
    public ActionResult<string> Delete(int keepId)
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