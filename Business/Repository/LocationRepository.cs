using System.Text.Json;
using Models;

namespace Repository;
public static class LocationRepository{

    public static async Task<Country[]?> GetAllCountries(){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "countries.json");
        if( res == null || (int) res.StatusCode != 200 )
            return null;
        CountriesReponse? temp = JsonSerializer.Deserialize<CountriesReponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.countries;
    }

    public static async Task<Country?> GetByCountryId(Int64 id){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "countries/" + id + ".json");
        if( res == null || (int) res.StatusCode != 200 ){
            return null;
        }
        CountryResponse? temp = JsonSerializer.Deserialize<CountryResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.country!;
    }

    public static async Task<Province[]?> GetWithCountryId(Int64 id){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "countries/" + id + "/provinces.json" );
        if( res == null || (int) res.StatusCode != 200 )
            return null;
        ProvinceResponse? temp = JsonSerializer.Deserialize<ProvinceResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.provinces;
    }

    public static async Task<District[]?> GetWithProvinceId(Int64 id){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "provinces/" + id + "/districts.json" );
        if( res == null || (int) res.StatusCode != 200 )
            return null;
        DistrictResponse? temp = JsonSerializer.Deserialize<DistrictResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.districts;
    }

    public static async Task<Ward[]?> GetWithDistrictId(Int64 id){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "districts/" + id + "/wards.json" );
        if( res == null || (int) res.StatusCode != 200 )
            return null;
        WardResponse? temp = JsonSerializer.Deserialize<WardResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.wards;
    }

}


