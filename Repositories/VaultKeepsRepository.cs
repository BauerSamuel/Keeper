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

    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      //NEED MORE IDs IN HERE. MAKE SURE TO COME BACK.
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId
WHERE(vaultId = @vaultId AND vk.userId = @userId);", new { vaultId, userId });
    }

    public VaultKeep CreateVK(VaultKeep newVK)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"INSERT INTO vaultkeeps(vaultId, keepId, userId)
          VALUES(@VaultId, @KeepId, @UserId); SELECT LAST_INSERT_ID()", newVK);
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



  }
}