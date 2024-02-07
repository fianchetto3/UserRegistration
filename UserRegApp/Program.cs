using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserRegApp;
using UserRegApp.Context;
using UserRegApp.Repositories;
using UserRegApp.Services;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\UserRegistrationSolution\UserRegApp\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<UserRepository>();
    services.AddScoped<ProfileRepository>();
    services.AddScoped<UserAuthRepository>();
    services.AddScoped<UserActivityRepository>();
    services.AddScoped<RoleRepository>();

    services.AddScoped<RoleService>();
    services.AddScoped<UserService>();
    services.AddScoped<UserAuthServices>();
    services.AddScoped<UserActivityService>();
    services.AddScoped<AddressService>();
    services.AddScoped<ProfileServices>();
    services.AddScoped<PasswordHasher>();

    services.AddSingleton<UI>();

}) .Build();

var ui = builder.Services.GetRequiredService<UI>();
ui.CreateUser_UI();
