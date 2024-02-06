
using UserRegApp.Services;

namespace UserRegApp;

internal class UI
{
    private readonly UserService _userService;
    private readonly ProfileServices _profileServices;
    private readonly UserAuthServices _userAuthServices;

    public UI(UserService userService)
    {
        _userService = userService;
    }
    
    public void CreateUser_UI()
    {
        Console.Clear();
        Console.WriteLine("----Create A User...----");

        Console.Write("Firstname:  ");
        var FirstName = Console.ReadLine();

        Console.Write("LastName:  ");
        var LastName = Console.ReadLine();


        Console.Write("Role:  ");
        var RoleName = Console.ReadLine();

        Console.Write("Email:  ");
        var Email = Console.ReadLine();

        Console.Write("Phone:  ");
        var Phone = Console.ReadLine();

        Console.Write("Password:  ");
        var Password = Console.ReadLine();

        Console.Write("City:  ");
        var city = Console.ReadLine();

        Console.Write("Postal Code:  ");
        var postalcode = Console.ReadLine();

        Console.Write("Street:   ");
        var street = Console.ReadLine();


        var Result = _profileServices.CreateProfile(FirstName,LastName, RoleName,Email,Phone,city,postalcode,street);
        if (Result != null)
        {
            Console.Clear();
            Console.WriteLine("User was Created");
            Console.ReadKey();
        }
        if (Result == null)
        {
            Console.Clear();
            Console.WriteLine("Something went Wrong...");
            Console.ReadKey();
        }
       
    }

  






}
