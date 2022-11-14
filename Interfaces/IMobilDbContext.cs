using Microsoft.EntityFrameworkCore;
using MobileStore.Models;
using System.Threading.Tasks;
using System.Threading;

namespace MobileStore.Interfaces
{
    public interface IMobilDbContext
    {
        DbSet<Phone> Phones { get; set; }
        DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
