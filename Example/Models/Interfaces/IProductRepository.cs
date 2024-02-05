using Example.Models.Entities;
using System.Linq.Expressions;
namespace Example.Models.Interfaces;

public interface IProductRepository : IRepo<ProductEntity>
{
	Task<IEnumerable<ProductEntity>> GetAllAsync();
	Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate);
	Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> predicate);
}
