using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Keep
  {
    [Required]
    private int Id { get; set; }

    [Required]
    private int AuthorId { get; set; }

    [Required]
    private string ImgSource { get; set; }

    [Required]
    private bool IsPrivate { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    private int Views { get; set; } = 0;

    public Keep(string name, string description, string imgSource, bool isPrivate)
    {
      Name = name;
      Description = description;
      ImgSource = imgSource;
      IsPrivate = isPrivate;
    }

  }

}