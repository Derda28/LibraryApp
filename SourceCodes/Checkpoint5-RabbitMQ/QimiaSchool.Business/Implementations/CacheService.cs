using QimiaSchool.Business.Abstracts;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Serilog;

namespace QimiaSchool.Business.Implementations;
public class CacheService : ICacheService
{

    private readonly IDistributedCache _cache=null!;
    private readonly ILogger _logger = null!;

    public CacheService(IDistributedCache cache, ILogger logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var value = await _cache.GetStringAsync(key, cancellationToken);

        if (value != null)
        {
            _logger.Information("Cache successful for the key '{Key}'", key);
            return JsonSerializer.Deserialize<T>(value);
        }

        _logger.Information("Cache missing for the key '{Key}'", key);
        return default;
    }


    public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        var exist = await _cache.GetAsync(key, cancellationToken);
        if (exist != null)
        {
            await _cache.RemoveAsync(key, cancellationToken);
            _logger.Information("Cache's been removed for the key '{Key}'", key);
            return true;
        }
        _logger.Information("Cache removal's failed for the key '{Key}'", key);
        return false;
    }


    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? expirationDate = null, CancellationToken cancellationToken = default)
    {
        var options = new DistributedCacheEntryOptions();

        if (expirationDate.HasValue)
        {
            options.AbsoluteExpirationRelativeToNow = expirationDate.Value;
        }

        var serializedValue = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, serializedValue, options, cancellationToken);

        _logger.Information("Cache is set for the key '{Key}'", key);

        return true;
    }

}
