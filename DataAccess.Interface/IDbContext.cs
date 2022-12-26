using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interface
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }
        Task<int> SaveChagesAsync(CancellationToken cancellationToken);
    }
}