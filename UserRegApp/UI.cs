
using UserRegApp.Services;

namespace UserRegApp;

internal class UI
{
    private readonly UserService _userService;
    private readonly ProfileServices _profileServices;
    private readonly AddressService _addressService;



    public UI(UserService userService, ProfileServices profileServices, AddressService addressService)
    {
        _userService = userService;
        _profileServices = profileServices;
        _addressService = addressService;

    }

    public void CreateUser_UI()
    {
        Console.Clear();
        Console.WriteLine("----Create A User...----");



        Console.Write("Email:  ");
        var Email = Console.ReadLine()!;

        Console.Write("Phone:  ");
        var Phone = Console.ReadLine()!;

        Console.Write("City:  ");
        var city = Console.ReadLine()!;

        Console.Write("Postal Code:  ");
        var postalcode = Console.ReadLine()!;

        Console.Write("Street:   ");
        var street = Console.ReadLine()!;

        Console.Write("Firstname:  ");
        var FirstName = Console.ReadLine()!;

        Console.Write("LastName:  ");
        var LastName = Console.ReadLine()!;

        Console.Write("Role:  ");
        var RoleName = Console.ReadLine()!;


        var userResult = _userService.CreateUser(Email, Phone, city, postalcode, street );
        var profileResult = _profileServices.CreateProfile(FirstName, LastName, RoleName, Email); 
        var addressResult =  _addressService.CreateAddress(street , city, postalcode);

        if (userResult != null && profileResult != null && addressResult != null)
        {
            Console.Clear();
            Console.WriteLine("User was Created");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Failed to create user. Please check your input.");
            Console.ReadKey();
        }
    }







}















