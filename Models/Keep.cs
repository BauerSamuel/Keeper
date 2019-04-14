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
    public string Name { get; set; }
    private int Keeps { get; set; }
    public Keep(string name, string imgSource)
    {
      Name = name;
      ImgSource = imgSource;
    }

  }

}