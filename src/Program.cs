using AegisDerm.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("")
    );

var app = builder.Build();
app.MapGet("/.", () => "Hello World!");
app.Run();