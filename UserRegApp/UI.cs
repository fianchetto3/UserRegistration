
using UserRegApp.Services;

namespace UserRegApp;

internal class UI
{
    private readonly UserService _userService;
    private readonly ProfileServices _profileServices;
  

    public UI(UserService userService, ProfileServices profileServices)
    {
        _userService = userService;
        _profileServices = profileServices;
        
    }

    public void CreateUser_UI()
    {
        Console.Clear();
        Console.WriteLine("----Create A User...----");



        Console.Write("Email:  ");
        var Email = Console.ReadLine();

        Console.Write("Phone:  ");
        var Phone = Console.ReadLine();

        Console.Write("City:  ");
        var city = Console.ReadLine();

        Console.Write("Postal Code:  ");
        var postalcode = Console.ReadLine();

        Console.Write("Street:   ");

        var street = Console.ReadLine();
        Console.Write("Firstname:  ");
        var FirstName = Console.ReadLine();

        Console.Write("LastName:  ");
        var LastName = Console.ReadLine();

        Console.Write("Role:  ");
        var RoleName = Console.ReadLine();


        var userResult = _userService.CreateUser(Email!, Phone!, city!, postalcode!, street!); _profileServices.CreateProfile(FirstName, LastName, RoleName, Email, Phone, city, postalcode, street);

       
    }

  
    }


  





