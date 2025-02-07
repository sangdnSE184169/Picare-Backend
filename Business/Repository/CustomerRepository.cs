using System.Text.Json;
using Helper;
using Models;

namespace Repository;
public static class CustomerReposiroty{

    public static async Task<Customer[]?> GetByQuery(string info){
        HttpResponseMessage? res = await Helper.Client.GetAsync( "customers.json?query=" + info );
        if( res == null || (int) res.StatusCode != 200 ){
            return null;
        }
        CustomerResponse? temp = JsonSerializer.Deserialize<CustomerResponse>( await res.Content.ReadAsStringAsync());
        if( temp == null )
            return null;
        return temp.customers;
    }

    public static async Task<string> CreateCustomerOnly( CustomerInfoOnlyRequest info ){
        string endUri = "customers.json";
        if( String.IsNullOrEmpty(info.customer.first_name))
            return "Error: Customer's first name cannot be empty";
        if( String.IsNullOrEmpty(info.customer.last_name))
            return "Error: Customer's last name cannot be empty";
        if( String.IsNullOrEmpty(info.customer.email))
            return "Error: Customer's email cannot be empty";
        if( String.IsNullOrEmpty(info.customer.phone))
            return "Error: Customer's phone cannot be empty";
        string json = JsonSerializer.Serialize(info);
        HttpResponseMessage? res = await Helper.Client.PostAsync(endUri, json);
        if( res == null )
            return "Error: Missing configuration";
        if( (int)res.StatusCode != 201 ){
            Console.WriteLine(res.ReasonPhrase);
            return "Failed: " + res.ReasonPhrase;
        }
        return "OK";
    }

    public static async Task<string> CreateCustomerWithAddress( CustomerWithAddressRequest info ){
        string endUri = "customers.json";
        if( String.IsNullOrEmpty(info.customer.first_name))
            return "Error: Customer's first name cannot be empty";
        if( String.IsNullOrEmpty(info.customer.last_name))
            return "Error: Customer's last name cannot be empty";
        if( String.IsNullOrEmpty(info.customer.email))
            return "Error: Customer's email cannot be empty";
        if( String.IsNullOrEmpty(info.customer.phone))
            return "Error: Customer's phone cannot be empty";
        string json = JsonSerializer.Serialize(info);
        HttpResponseMessage? res = await Helper.Client.PostAsync(endUri, json);
        if( res == null )
            return "Error: Missing configuration";
        if( (int)res.StatusCode != 201 ){
            Console.WriteLine(res.ReasonPhrase);
            return "Failed: " + res.ReasonPhrase;
        }
        return "OK";
    }

    public static async Task<string> UpdateCustomer( Int64 id, string info ){
        string endUri = $"customers/{id}.json";
        HttpResponseMessage? res = await Helper.Client.PutAsync(endUri, info);
        if( res == null )
            return "Error: Missing configuration";
        if( (int)res.StatusCode != 200 ){
            Console.WriteLine(res.ReasonPhrase);
            return "Failed: " + res.ReasonPhrase;
        }
        return "OK";
    }

}

