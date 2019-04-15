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

    public IEnumerable<VaultKeep> GetKeepsByVaultId(int vaultId)
    {
      //NEED MORE IDs IN HERE. MAKE SURE TO COME BACK.
      return _db.Query<VaultKeep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId
WHERE(vaultId = @vaultId) ", new { vaultId });
    }


  }
}