using jwtauth.Entities;

using Microsoft.EntityFrameworkCore;

namespace jwtauth.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options): DbContext(options) {
    public DbSet <User> Users {get;set;}
}