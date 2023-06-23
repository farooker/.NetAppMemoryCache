using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_in_memory
{
    class Program
    {
        public static MemoryCacheOptions cacheOption;
        public static MemoryCache cache;
        static void Main(string[] args)
        {
       

            Console.WriteLine("");
            Console.WriteLine("################################################");
            Console.WriteLine("#                                              #");
            Console.WriteLine("#               DEMO CACHE MEMORY              #");
            Console.WriteLine("#                                              #");
            Console.WriteLine("################################################");
            Console.WriteLine("");



            cacheOption = new MemoryCacheOptions();
            cache = new MemoryCache(cacheOption);

            MemoryCacheItem();
            MemoryCacheTable();
        }
        static void MemoryCacheItem() {
            var options = new MemoryCacheEntryOptions().SetSize(2);

            // Add an item to the cache
            string key = "keyItem";
            string value = "tesing";
            cache.Set(key, value, options);

            // Retrieve an item from the cache
            if (cache.TryGetValue(key, out string cachedValue))
            {
                Console.WriteLine($"{key} : {cachedValue}");
            }

        }
        static void MemoryCacheTable() {

            List<Dictionary<string, object>> table = new List<Dictionary<string, object>>();

            Dictionary<string, object> row1 = new Dictionary<string, object>
            {{ "ID", 1 }, { "Name", "John" },{ "Age", 25 }};
            table.Add(row1);
            Dictionary<string, object> row2 = new Dictionary<string, object>
            {{ "ID", 2 },{ "Name", "Jane" },{ "Age", 30 }};
            table.Add(row2);

            cache.Set("keyTable", table, DateTimeOffset.Now.AddMinutes(10));

            // Retrieve the table from the cache
            if (cache.Get("keyTable") is List<Dictionary<string, object>> cachedTable)
            {
                // Access and process the table
                foreach (var row in cachedTable)
                {

                    Console.WriteLine($"ID:  : {row["ID"]}");
                    Console.WriteLine($"Name : {row["Name"]}");
                    Console.WriteLine($"Age  : {row["Age"]}");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
