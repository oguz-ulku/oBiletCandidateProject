﻿using DataModels.Interfaces;
using StackExchange.Redis;
using WebAPI.Utils;
using IServer = StackExchange.Redis.IServer;


namespace WebAPI.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _client;
        private readonly IServer _server;

        public RedisCacheService(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("RedisCache:ConnectionString")?.Value;

            ConfigurationOptions options = new ConfigurationOptions
            {
                EndPoints =
                {
                    connectionString 
                },
                AbortOnConnectFail = false,
                AsyncTimeout = 10000,
                ConnectTimeout = 10000
            };

            _client = ConnectionMultiplexer.Connect(options); 
            _server = _client.GetServer(connectionString);
        }

        public void Set(string key, string value)
        {
            _client.GetDatabase().StringSet(key, value);
        }

        public void Set<T>(string key, T value) where T : class
        {
            _client.GetDatabase().StringSet(key, value.ToJson());
        }

        public Task SetAsync(string key, object value)
        {
            return _client.GetDatabase().StringSetAsync(key, value.ToJson());
        }

        public void Set(string key, object value, TimeSpan expiration)
        {
            _client.GetDatabase().StringSet(key, value.ToJson(), expiration);
        }

        public Task SetAsync(string key, object value, TimeSpan expiration)
        {
            return _client.GetDatabase().StringSetAsync(key, value.ToJson(), expiration);
        }

        public T Get<T>(string key) where T : class
        {
            string value = _client.GetDatabase().StringGet(key);

            return value.ToObject<T>();
        }

        public string Get(string key)
        {
            return _client.GetDatabase().StringGet(key);
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            string value = await _client.GetDatabase().StringGetAsync(key);

            return value.ToObject<T>();
        }

        public void Remove(string key)
        {
            _client.GetDatabase().KeyDelete(key);
        }

        public async Task<List<string>> GetCacheList()
        {
            var listKeys = new List<string>();
            var keys = _server.Keys();
            listKeys.AddRange(keys.Select(key => (string)key).ToList());

            return listKeys;
        }
    }
}
