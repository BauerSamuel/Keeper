using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using Keepr.Models;
using Dapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {

    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetAllPublic()
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE isPrivate = 0");
    }

    public IEnumerable<Vault> GetById(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id", new { id });
    }

    public ActionResult<Vault> CreateKeep(Vault newVault)
    {
      //will crash if fails
      _db.Execute("INSERT INTO vaults (name, description, img, isPrivate) VALUES (@Name, @Description, @imgSource, @isPrivate)", newVault);
      return newVault;
    }

    public bool DeleteKeep(string vaultId)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @keepId", new { vaultId });
      return success > 0;
    }
  }
}