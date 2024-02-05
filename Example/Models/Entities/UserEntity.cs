using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Example.Models.Entities;

public class UserEntity
{
	[Key]
	public string UserID { get; set; } = Guid.NewGuid().ToString();

	[Column(TypeName = "nvarchar(45)")]
	public string FirstName { get; set; } = null!;

	[Column(TypeName = "nvarchar(45)")]
	public string LastName { get; set; } = null!;

	[Column(TypeName = "nvarchar(225)")]
	public string Email { get; set; } = null!;

	[Column(TypeName = "nvarchar(45)")]
	public string? PhoneNumber { get; set; }

	// Navigation properties
	public virtual ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();
	public virtual ICollection<UserImageEntity> UserImages { get; set; } = new HashSet<UserImageEntity>();
}

