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

    public IEnumerable<Vault> GetById(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id", new { id });
    }



    //Below Are intentional methods.
    internal IEnumerable<Vault> GetUserVaults(string id)
    {
      return _db.Query<Vault>("SELECT * FROM keeps WHERE userId = @id", new { id });
    }

    internal ActionResult<Vault> CreateVault(Vault newVault)
    {
      _db.Execute("INSERT INTO vaults (name, description, userId) VALUES (@Name, @Description, @userId)", newVault);
      return newVault;
    }

    internal bool DeleteVault(string vaultId)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @vaultId", new { vaultId });
      return success > 0;
    }
  }
}