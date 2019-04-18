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
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {

      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId
WHERE(vaultId = @vaultId);", new { vaultId });
    }

    public VaultKeep CreateVK(VaultKeep newVK)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"INSERT INTO vaultkeeps(vaultId, keepId)
          VALUES(@VaultId, @KeepId); SELECT LAST_INSERT_ID()", newVK);
        newVK.Id = id;
        return newVK;
      }
      catch (Exception error)
      {
        Console.WriteLine("Error is: " + error);
        return null;
      }
    }


    //delete vaultkeep where vaultId = @vaultId AND keepId = @keepId AND userId = @userId
    public bool DeleteVK(int vaultId, int keepId)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId", new { vaultId, keepId });
      return success > 0;
    }

  }
}