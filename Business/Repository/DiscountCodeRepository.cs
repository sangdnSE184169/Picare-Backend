using System.Text.Json;
using Helper;
using Models;

namespace Repository;
public static class DiscountRepository{
    public static async Task<Discount[]?> GetAll(){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "discounts.json");
        if( res == null || (int) res.StatusCode != 200 )
            return null;
        DiscountsResponse? temp = JsonSerializer.Deserialize<DiscountsResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.discounts;
    }

    public static async Task<Discount?> GetById(Int64 id){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "discounts/" + id + ".json");
        if( res == null || (int) res.StatusCode != 200 ){
            return null;
        }
        DiscountResponse? temp = JsonSerializer.Deserialize<DiscountResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null ){
            return null;
        }
        return temp.discount;
    }

    public static async Task<Discount[]?> GetByCode(string code){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "discounts.json?code=" + code );
        if( res == null || (int) res.StatusCode != 200 ){
            return null;
        }
        DiscountsResponse? temp = JsonSerializer.Deserialize<DiscountsResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.discounts;
    }
}
