using Helper;
using Models;
using System.Text.Json;

namespace Repository;
public static class OrderRepository{

    private static bool IsValidShippingAddress( ShippingAddress target ){
        if( String.IsNullOrEmpty( target.address1 ) )
            return false;
        if( String.IsNullOrEmpty( target.first_name ) )
            return false;
        if( String.IsNullOrEmpty( target.last_name ) )
            return false;
        if( String.IsNullOrEmpty( target.phone ) )
            return false;
        if( String.IsNullOrEmpty( target.country ) )
            return false;
        if( String.IsNullOrEmpty( target.country_code ) )
            return false;
        if( String.IsNullOrEmpty( target.province ) )
            return false;
        if( String.IsNullOrEmpty( target.province_code ) )
            return false;
        if( String.IsNullOrEmpty( target.district_code ) )
            return false;
        if( String.IsNullOrEmpty( target.district ) )
            return false;
        if( String.IsNullOrEmpty( target.ward_code ) )
            return false;
        if( String.IsNullOrEmpty( target.ward ) )
            return false;
        return true;
    }

    public static async Task<string> PlaceOrder( OrderRequest cart ){
        string endUri = "orders.json";
        Order temp = cart.order;
        if( temp.line_items.Length == 0 )
            return "Error: There's no item in cart";
        if( temp.total_discounts < 0 )
            return "Error: Discount cannot be negative";
        if( IsValidShippingAddress( temp.shipping_address ) == false)
            return "Error: invalid shipping address";
        if( String.IsNullOrEmpty( temp.gateway ) )
            return "Error: Gateway cannot be null";
        if( cart.order.note_attributes.Length == 0 ) 
            return "Error: There is no infomation about platform";
        string json = JsonSerializer.Serialize(cart);
        HttpResponseMessage? res = await Helper.Client.PostAsync(endUri, json);
        if( res == null )
            return "Error: Missing configuration";
        if( (int)res.StatusCode != 201 ){
            Console.WriteLine(Helper.Client.GetBaseUrl() + endUri);
            Console.WriteLine(res.ReasonPhrase);
            Console.WriteLine( await res.Content.ReadAsStringAsync());
            return "Failed: Unable to create new order";
        }
        return "OK";
    }
    
    public static async Task<PlacedOrder[]?> GetByCustomerInfo(string number){
        HttpResponseMessage? res = await Helper.Client.GetAsync( $"orders.json?query={number}");
        if( res == null || (int) res.StatusCode != 200 )
            return null;
            OrdersResponse? temp = JsonSerializer.Deserialize<OrdersResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.orders;
    }

}
