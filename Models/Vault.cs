using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Vault
  {
    [Required]
    private int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public List<string> VaultKeeps { get; set; }

    public Vault(string name)
    {
      Name = name;
      VaultKeeps = new List<string>();
    }

  }

}