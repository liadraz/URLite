using System;
using Urlite.Domain.Entities;

namespace Urlite.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task DeleteAsync(Guid id);
}
