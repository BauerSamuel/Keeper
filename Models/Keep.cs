using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }


    public string UserId { get; set; }

    [Required]
    public string Img { get; set; }

    [Required]
    public bool IsPrivate { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    public int Views { get; set; } = 0;
    public int Shares { get; set; } = 0;
    public int Keeps { get; set; } = 0;

    // public Keep(string name, string description, string imgSource, bool isPrivate)
    // {
    //   Name = name;
    //   Description = description;
    //   ImgSource = imgSource;
    //   IsPrivate = isPrivate;
    // }

  }

}