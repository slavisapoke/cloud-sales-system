using System.Net.Http.Json;

namespace Poke.CloudSalesSystem.Gateway.Application.Extensions
{
    public static class HttpExtensions
    {
        /// <summary>
        /// GET request with ensuring success code.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client">Http client</param>
        /// <param name="endpoint">Endpoint</param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns></returns>
        public static async Task<TResponse?> GetAsyncThrowable<TResponse>(
            this HttpClient client, string endpoint, CancellationToken cancellationToken)
        {
            var result = await client.GetAsync(endpoint, cancellationToken);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<TResponse>();
        }

        /// <summary>
        /// POST request with ensuring success code.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client">Http client</param>
        /// <param name="endpoint">Endpoint</param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns></returns>
        public static async Task<TResponse?> PostAsyncThrowable<TResponse, TRequest>(
            this HttpClient client, string endpoint, TRequest request, CancellationToken cancellationToken)
        {
            var result = await client.PostAsJsonAsync(endpoint, request, cancellationToken);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<TResponse>();
        }
    }
}
