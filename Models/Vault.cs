using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    // public Vault(string name, string description, string userId)
    // {
    //   Name = name;
    //   Description = description;
    //   UserId = userId;
    // }

  }

}