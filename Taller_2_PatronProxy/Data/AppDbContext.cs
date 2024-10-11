using Microsoft.EntityFrameworkCore;
using Taller_2_PatronProxy.Models;

namespace Taller_2_PatronProxy.Data;

public class AppDbContext: DbContext
{
    public DbSet<Heroes> Heroes { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
}