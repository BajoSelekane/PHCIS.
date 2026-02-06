using Domain.Entities.User;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
