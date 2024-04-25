using System.Net.Http.Json;

namespace WebApp.Extensions
{
    public static class HttpClientExtension
    {
        public async static Task<TResult> PostGetResponseAsync<TResult, TValue>(this HttpClient client, String url, TValue value)
        {
            var httpRes = await client.PostAsJsonAsync(url, value);

            if (httpRes.IsSuccessStatusCode)
                return await httpRes.Content.ReadFromJsonAsync<TResult>();

            return default;
        }

        public async static Task PostAsync<TValue>(this HttpClient client, String url, TValue value)
        {
            await client.PostAsJsonAsync(url, value);
        }

        public async static Task<T> GetAsync<T>(this HttpClient client, String url)
        {
            return await client.GetFromJsonAsync<T>(url);
        }
    }
}
