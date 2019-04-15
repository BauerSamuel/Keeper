using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }

    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }

    [Required]
    public string Img { get; set; }


    // public VaultKeep(string imgSource, int vaultId, int keepId)
    // {
    //   ImgSource = imgSource;
    //   VaultId = vaultId;
    //   KeepId = keepId;
    // }

  }

}