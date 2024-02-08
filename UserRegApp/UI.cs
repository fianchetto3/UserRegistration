using UserRegApp.Services;


// Vid skapandet av användare finns det ett delay till Profile Tabellen i databasen. 
// Profile tar någon minut på sig innan den uppdateras med rätta uppgifter från vad användaren har angett. Antagligen pågrund av dålig kod på något ställe eller avsaknad av async await i programmet, eller båda :D. 





internal class UI
{
    private readonly UserService _userService;
    private readonly ProfileServices _profileServices;
    private readonly AddressService _addressService;
    private readonly UserAuthServices _userAuthServices;
    private readonly PasswordHasher _passwordHasher;
    private readonly RoleService _roleService;

    public UI(UserService userService, ProfileServices profileService, AddressService addressService, UserAuthServices userAuthServices, RoleService roleService)
    {
        _userService = userService;
        _profileServices = profileService;
        _addressService = addressService;
        _userAuthServices = userAuthServices;
        _roleService = roleService;
    }

    public void CreateUser_UI()
    {
        Console.Clear();
        Console.WriteLine("----Create A User...----");

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("Street: ");
        var street = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Phone: ");
        var phone = Console.ReadLine()!;

        Console.Write("Role: ");
        var roleName = Console.ReadLine()!;

        Console.Write("Firstname: ");
        var firstName = Console.ReadLine()!;

        Console.Write("LastName: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Password: ");
        var password = Console.ReadLine()!;

        var userResult = _userService.CreateUser(email, phone, city, postalCode, street, firstName, lastName);

        if (userResult != null)
        {
            var profileResult = _profileServices.CreateProfile(firstName, lastName, roleName, userResult);
            var addressResult = _addressService.CreateAddress(street, postalCode, city);
            var roleResult = _roleService.CreateRole(roleName);
            var passwordResult = _userAuthServices.CreatePassword(email, password);

            if (profileResult != null && addressResult != null && roleResult != null && passwordResult != null)
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
        else
        {
            Console.WriteLine("Failed to create user. Please check your input.");
            Console.ReadKey();
        }
    }
}
