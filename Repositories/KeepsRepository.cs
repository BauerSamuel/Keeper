using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using Keepr.Models;
using Dapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAllPublic()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }

    public IEnumerable<Keep> GetById(string id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @id", new { id });
    }

    public ActionResult<Keep> CreateKeep(Keep newKeep)
    {
      //will crash if fails
      _db.Execute("INSERT INTO keeps (name, description, img, isPrivate, views, shares, keeps) VALUES (@Name, @Description, @Img, @isPrivate, 0, 0, 0)", newKeep);
      return newKeep;
    }

    public bool DeleteKeep(string keepId)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @keepId", new { keepId });
      return success > 0;
    }
  }
}