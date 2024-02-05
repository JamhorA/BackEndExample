using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Example.Models.Entities;

public class AddressEntity
{
	[Key]
	public int AddressID { get; set; }

	[Column(TypeName = "nvarchar(45)")]
	public string Street { get; set; } = null!;

	[Column(TypeName = "nvarchar(45)")]
	public string City { get; set; } = null!;

	[Column(TypeName = "nvarchar(45)")]
	public string Country { get; set; } = null!;
	// Navigation property
	public virtual ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();
}
