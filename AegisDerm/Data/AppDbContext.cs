using AegisDerm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AegisDerm.Data;

public class AppDbContext(DbContextOptions options)
    : IdentityDbContext<User>(options);
