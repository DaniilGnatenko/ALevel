using HomeworkModule4Lesson1.Config;
using HomeworkModule4Lesson1.Dtos.Requests;
using HomeworkModule4Lesson1.Dtos.Responses;
using HomeworkModule4Lesson1.Dtos;
using HomeworkModule4Lesson1.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HomeworkModule4Lesson1.Services;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/users/";

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{_userApi}{id}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"User with id = {result.Data.Id} was found");

        }

        return result?.Data;
    }

    public async Task<ResourceDto> GetResourceById(int id)
    {
        string newPath = "api/unknown/";
        var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>($"{_options.Host}{newPath}{id}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Resource with id = {result.Data.Id} was found");

        }

        return result?.Data;
    }

    public async Task<ResourceDto[]> GetResources()
    {
        string newPath = "api/unknown/";
        var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto[]>, object>($"{_options.Host}{newPath}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Resources were found");

        }

        return result?.Data;
    }

    public async Task<UserDto[]> GetUsersFromPage(int page)
    {
        string newPath = "api/users?page=";
        var result = await _httpClientService.SendAsync<BaseResponse<UserDto[]>, object>($"{_options.Host}{newPath}{page}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Users from page {page} received");

        }

        return result?.Data;
    }

    public async Task<UserResponse> CreateUser(string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}",
            HttpMethod.Post,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.Id} was created");
        }

        return result;
    }

    public async Task<UserUpdateResponse> UpdateUserByPut(int id, string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserUpdateResponse, UserRequest>(
            $"{_options.Host}{_userApi}{id}",
            HttpMethod.Put,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User was updated by put");
        }

        return result;
    }

    public async Task<UserUpdateResponse> UpdateUserByPatch(int id, string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserUpdateResponse, UserRequest>(
            $"{_options.Host}{_userApi}{id}",
            HttpMethod.Patch,
            new UserRequest()
            {
                Job = job,
                Name = name,

            });

        if (result != null)
        {
            _logger.LogInformation($"User was updated by patch");
        }

        return result;
    }

    public async Task DeleteUserByID(int id)
    {
        await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{_userApi}{id}", HttpMethod.Delete);

    }

    public async Task<RegistrationResponse> RegisterUser(string email, string password)
    {
        string newPath = "api/register";
        var result = await _httpClientService.SendAsync<RegistrationResponse, UserRegistrationRequest>($"{_options.Host}{newPath}",
            HttpMethod.Post,
            new UserRegistrationRequest
            {
                Password = password,
                Email = email
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.Id} was signed up");
            _logger.LogInformation($"User token = {result?.Token}");
        }

        return result;
    }

    public async Task<UnsuccessfulResponse> UnsuccessfulRegistration(string email)
    {
        string newPath = "api/register";
        var result = await _httpClientService.SendAsync<UnsuccessfulResponse, UnsuccessfulRequst>($"{_options.Host}{newPath}",
            HttpMethod.Post,
            new UnsuccessfulRequst
            {
                Email = email
            });

        if (result != null)
        {
            _logger.LogInformation($"error :{result?.Error}");
        }

        return result;
    }

    public async Task<RegistrationResponse> LoginUser(string email, string password)
    {
        //string newPath = "api/login";
        var result = await _httpClientService.SendAsync<RegistrationResponse, UserLoginRequest>($"{_options.Host}api/login", HttpMethod.Post,
            new UserLoginRequest()
            {
                Email = email,
                Password = password
            });

        if (result != null)
        {
            _logger.LogInformation($"User token = {result?.Token}");
        }

        return result;
    }

    public async Task<UnsuccessfulResponse> UnsuccessfulLogin(string email)
    {
        //string newPath = "api/login";
        var result = await _httpClientService.SendAsync<UnsuccessfulResponse, UnsuccessfulRequst>($"{_options.Host}api/login",
            HttpMethod.Post,
            new UnsuccessfulRequst
            {
                Email = email
            });

        if (result != null)
        {
            _logger.LogInformation($"{result?.Error}");
        }

        return result;
    }

    public async Task<UserDto[]> GetUsersWithDelay(int delay)
    {
        string newPath = "api/users?delay=";
        var result = await _httpClientService.SendAsync<BaseResponse<UserDto[]>, object>($"{_options.Host}{newPath}{delay}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Users was found");

        }

        return result?.Data;
    }
}

