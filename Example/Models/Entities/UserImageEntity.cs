using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Example.Models.Entities;

[PrimaryKey(nameof(UserID), nameof(ImageID))]
public class UserImageEntity
{
	[ForeignKey(nameof(User))]
	public required string UserID { get; set; }
	[ForeignKey(nameof(Image))]
	public string? ImageID { get; set; }
	public virtual UserEntity User { get; set; } = null!;
	public virtual ImageEntity? Image { get; set; }
}
