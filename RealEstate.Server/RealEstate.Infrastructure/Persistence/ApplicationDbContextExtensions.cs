using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Shared.Common.Utils;
using RealEstate.Shared.Constants;

namespace RealEstate.Infrastructure.Persistence
{
    public static class ApplicationDbContextExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "admin",
                    Password = PasswordHasher.HashPassword("123qwe"),
                    Fullname = "admin",
                    UserType = UserType.ADMIN,
                    Status = UserStatus.ACTIVE,
                    PhoneNumber = "0972808703"
                },
                new User
                {
                    Id = 2,
                    Email = "customer",
                    Password = PasswordHasher.HashPassword("123qwe"),
                    Fullname = "admin",
                    UserType = UserType.CUSTOMER,
                    Status = UserStatus.ACTIVE,
                    PhoneNumber = "0972808703"
                });
            #endregion
        }
    }
}
