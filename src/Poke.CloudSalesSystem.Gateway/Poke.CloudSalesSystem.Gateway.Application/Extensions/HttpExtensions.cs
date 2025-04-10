using System.Net.Http.Json;

namespace Poke.CloudSalesSystem.Gateway.Application.Extensions
{
    public static class HttpExtensions
    {
        /// <summary>
        /// Request GET with ensuring success code. Returns default if null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client">Http client</param>
        /// <param name="endpoint">Endpoint</param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns></returns>
        public static async Task<T?> GetAsyncThrowable<T>(this HttpClient client, string endpoint)
        {
            var result = await client.GetAsync(endpoint);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<T>();
        }
    }
}
