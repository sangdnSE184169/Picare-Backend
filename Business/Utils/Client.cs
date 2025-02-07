using System.Net.Http.Headers;
using System.Text;

namespace Helper;

public static class Client{
    private static string? apiKey = Helper.Configuration.GetConfiguration()["Others:HaravanToken"];
    private static HttpClient client = new HttpClient();

    static Client(){
        client.BaseAddress = new Uri("https://apis.haravan.com/com/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
    }

    public static string GetBaseUrl(){
        return client.BaseAddress!.ToString();
    }

    private static bool isTokenNull(){
        if( string.IsNullOrEmpty(apiKey) )
            return true;
        return false;
    }

    public static async Task<HttpResponseMessage?> GetAsync(string endUri){
        if( isTokenNull() ){
            Console.WriteLine("Appsetting is missing haravan token");
            return null;
        }
        return await client.GetAsync(endUri);
    }

    public static async Task<HttpResponseMessage?> PostAsync(string endUri, string body){
        if( isTokenNull() ){
            Console.WriteLine("Appsetting is missing haravan token");
            return null;
        }
        return await client.PostAsync(endUri, new StringContent(body, Encoding.UTF8, "application/json"));
    }

    public static async Task<HttpResponseMessage?> PutAsync(string endUri, string body){
        if( isTokenNull() ){
            Console.WriteLine("Appsetting is missing haravan token");
            return null;
        }
        return await client.PutAsync(endUri, new StringContent(body, Encoding.UTF8, "application/json"));
    }

}
