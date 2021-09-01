using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

//namespace XEngineAPI.DBContext
namespace IdentityServerMVC.RedisContext
{
    public static class XRedisCache
    {
        // Sets the activeprograms list
        /// <summary>
        /// Sets the activeprograms list
        /// If list is null its converted to a list with one empty string.
        /// </summary>
        public static async Task<bool> SetActivePrograms(IDistributedCache _cache)
        {
           
            return true;
        }

       }

    namespace IdentityServerMVC.RedisContext.Redis
    {

        [MessagePackObject]
        public class ActiveProgram
        {
            [Key(0)]
            [JsonProperty(PropertyName = "MyProperty")]
            public int MyProperty { get; set; }

        }

    }
}
