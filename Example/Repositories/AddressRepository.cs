using Example.Contexts;
using Example.Models.Entities;

namespace Example.Repositories;

public class AddressRepository(DataContext dataContext) : Repo<AddressEntity>(dataContext)
{
}
