using Example.Models.Entities;
using System.Linq.Expressions;

namespace Example.Models.Interfaces;

public interface IUserRepository : IRepo<UserEntity>
{
	Task<IEnumerable<UserEntity>> GetAllAsync();
	Task<IEnumerable<UserEntity>> GetAllAsync(Expression<Func<UserEntity, bool>> predicate);
	Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate);
}
