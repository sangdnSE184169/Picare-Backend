using Helper;
using Models;
using System.Text.Json;

namespace Repository;
public static class CustomCollectionRepository{

    public static async Task<CustomCollection[]?> GetWithQuery(string query){
        HttpResponseMessage? res = await Helper.Client.GetAsync("custom_collections.json" + query);
        if( res == null || (int)res.StatusCode != 200 )
            return null;
        string? json = await res.Content.ReadAsStringAsync();
        if( json == null || json.Length == 0 )
            return null;
        CustomCollectionsArray? temp = JsonSerializer.Deserialize<CustomCollectionsArray>( json );
        if( temp == null )
            return null;
        return temp.custom_collections;
    }

    public static async Task<CustomCollection?> GetWithId(Int64 id){
        HttpResponseMessage? res = await Helper.Client.GetAsync("custom_collections/"+ id + ".json");
        if( res == null || (int)res.StatusCode != 200 )
            return null;
        string? json = await res.Content.ReadAsStringAsync();
        if( json == null || json.Length == 0 )
            return null;
        CustomCollectionResponse? temp = JsonSerializer.Deserialize<CustomCollectionResponse>( json );
        if( temp == null )
            return null;
        return temp.custom_collection;
    }
}
