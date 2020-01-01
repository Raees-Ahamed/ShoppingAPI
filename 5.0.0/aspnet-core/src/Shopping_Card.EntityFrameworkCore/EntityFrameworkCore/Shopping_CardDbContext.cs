using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Shopping_Card.Authorization.Roles;
using Shopping_Card.Authorization.Users;
using Shopping_Card.MultiTenancy;
using Shopping_Card.Entities;

namespace Shopping_Card.EntityFrameworkCore
{
    public class Shopping_CardDbContext : AbpZeroDbContext<Tenant, Role, User, Shopping_CardDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public Shopping_CardDbContext(DbContextOptions<Shopping_CardDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set ; }
        public DbSet<Order> Orders { get; set ; }
        public DbSet<OrderItem> OrderItems { get; set ; }
        public DbSet<Product> Products { get; set ; }
    }
}
