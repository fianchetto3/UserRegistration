
using UserRegApp.Services;

namespace UserRegApp;

internal class UI
{
    private readonly UserService _userService;
    private readonly ProfileServices _profileServices;
    private readonly AddressService _addressService;
    private readonly UserAuthServices _userAuthServices;
    private readonly PasswordHasher _passwordHasher;
    private readonly RoleService _roleService;

    public UI(UserService userService, ProfileServices profileServices, AddressService addressService, UserAuthServices userAuthServices, RoleService roleService)
    {
        _userService = userService;
        _profileServices = profileServices;
        _addressService = addressService;
        _userAuthServices = userAuthServices;
      
        _roleService = roleService;
    }
    // Address , Roller , användare , profil , password , activity

    public void CreateUser_UI()
    {
        Console.Clear();
        Console.WriteLine("----Create A User...----");


        Console.Write("City:  ");
        var City = Console.ReadLine()!;

        Console.Write("Postal Code:  ");
        var postalCode = Console.ReadLine()!;

        Console.Write("Street:   ");
        var Street = Console.ReadLine()!;

        Console.Write("Email:  ");
        var Email = Console.ReadLine()!;

        Console.Write("Phone:  ");
        var Phone = Console.ReadLine()!;

        Console.Write("Role:  ");
        var RoleName = Console.ReadLine()!;

        Console.Write("Firstname:  ");
        var FirstName = Console.ReadLine()!;

        Console.Write("LastName:  ");
        var LastName = Console.ReadLine()!;

        Console.Write("Password:   ");
        var password = Console.ReadLine()!;







        var userResult = _userService.CreateUser(Email, Phone, City, postalCode, Street, FirstName,LastName);
        
        
        var addressResult =  _addressService.CreateAddress(Street ,postalCode , City);
        var ProfileResutl = _profileServices.CreateProfile(FirstName,LastName, RoleName);
        var roleResult = _roleService.CreateRole(RoleName);
        var passwordResult = _userAuthServices.CreatePassword(Email,password);



        if (userResult != null && roleResult !=null &&  ProfileResutl != null && addressResult != null)
        {
            Console.Clear();
            Console.WriteLine("User was Created");
            Console.ReadKey();
        }
        else
        {
           
            Console.WriteLine("Failed to create user. Please check your input.");
            Console.ReadKey();
        }
    }







}















