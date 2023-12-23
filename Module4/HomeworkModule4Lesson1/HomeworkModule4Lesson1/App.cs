using HomeworkModule4Lesson1.Services.Abstractions;


namespace HomeworkModule4Lesson1;

public class App
{
    private readonly IUserService _userService;

    public App(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Start()
    {
        var user = await _userService.GetUserById(2);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
    }
}

