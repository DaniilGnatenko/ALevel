﻿using System.Text;
using HomeworkModule4Lesson1.Services.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class InternalHttpClientService : IInternalHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;

    public InternalHttpClientService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                }), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);


        var resultContent = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
        return response!;
    }
}