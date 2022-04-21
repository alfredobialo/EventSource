using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace CacheServerCore;

public class AsomRedisLib
{
    private readonly IDatabase db;

    public AsomRedisLib()
    {
        ConfigurationOptions opts = new ConfigurationOptions()
        {
            EndPoints = { "127.0.0.1:6300", "127.0.0.1:6301", },
            ConnectRetry = 3,
            ClientName = "asom:",
        };

        ConnectionMultiplexer redisCon = ConnectionMultiplexer.Connect(opts);
        db = redisCon.GetDatabase();
    }

    public async Task<TimeSpan> PingRedis()
    {
        var res = await db.PingAsync();

        return res;
    }

    public async Task<bool> AddItem(string key, string data, TimeSpan expiresOn)
    {
        var res = await db.StringSetAsync(new RedisKey(key), new RedisValue(data), expiresOn);
        return res;
    }

    public async Task<RedisValue> GetItem(string key)
    {
        var res = await db.StringGetAsync(new RedisKey(key));
        return res;
    }

    public async Task<bool> AddItem<T>(string key, T data, TimeSpan expiresOn)
    {
        var szData = JsonConvert.SerializeObject(data, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        });
        return await AddItem(key, szData, expiresOn);
    }

    public async Task<T> GetItem<T>(string key)
    {
        var tryGet = await GetItem(key);
        if (!tryGet.IsNullOrEmpty)
        {
            var szData = JsonConvert.DeserializeObject<T>(tryGet.ToString());
            return szData;
        }

        return default(T);
    }
}
