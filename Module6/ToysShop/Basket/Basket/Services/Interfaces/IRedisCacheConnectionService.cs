using StackExchange.Redis;

namespace Basket.Services.Interfaces;

public interface IRedisCacheConnectionService
{
    public IConnectionMultiplexer Connection { get; }
}
