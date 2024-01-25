using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserRegApp.Context;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\UserRegistrationSolution\UserRegApp\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30"));

});

builder.Build();