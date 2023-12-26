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
        var listUsers = await _userService.GetUsersFromPage(2); // 1
        var singleUser = await _userService.GetUserById(2); // 2
        var singleUserNotFound = await _userService.GetUserById(23); // 3
        var listResources = await _userService.GetResources(); // 4
        var singleResource = await _userService.GetResourceById(2); // 5
        var singleResourceNotFound = await _userService.GetResourceById(23); // 6
        var create = await _userService.CreateUser("morpheus", "leader"); // 7
        var updatePut = await _userService.UpdateUserByPut(2, "morpheus", "zion resident"); // 8
        var updatePatch = await _userService.UpdateUserByPatch(2, "morpheus", "zion resident"); // 9
        await _userService.DeleteUserByID(2); // 10
        var successfulRegistration = await _userService.RegisterUser("eve.holt@reqres.in", "pistol"); //11
        var unsuccessfulRegistration = await _userService.UnsuccessfulRegistration("sydney@fife"); // 12
        var successfulLogin = await _userService.LoginUser("eve.holt@reqres.in", "cityslicka"); // 13
        var unsuccessfulLogin = await _userService.UnsuccessfulLogin("peter@klaven"); // 14
        var delayedResponse = await _userService.GetUsersWithDelay(3); //15
    }
}