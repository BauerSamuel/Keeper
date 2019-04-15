using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Vault
  {
    [Required]
    private int Id { get; set; }
    [Required]
    private string UserId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public List<string> VaultKeeps { get; set; }

    public Vault(string name, string description, string userId)
    {
      Name = name;
      Description = description;
      UserId = userId;
      VaultKeeps = new List<string>();
    }

  }

}