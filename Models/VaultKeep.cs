using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class VaultKeep
  {
    [Required]
    private int Id { get; set; }
    [Required]
    private int VaultId { get; set; }
    [Required]
    public string ImgSource { get; set; }

    public VaultKeep(string imgSource)
    {
      ImgSource = ImgSource;
    }

  }

}