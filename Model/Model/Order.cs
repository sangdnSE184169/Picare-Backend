#nullable disable

namespace Models;
// DiscountCode model (assuming you have this already)
public class OrderDiscountCode
{
    public string code { get; set; }
    public double amount { get; set; }
    public string type { get; set; }
}

// ItemInCart model
public class ItemInCart
{
    public Int64 variant_id { get; set; }
    public int quantity { get; set; }
    public string sku { get; set; }
    public string name { get; set; }
}

// NoteAttribute model
public class NoteAttribute
{
    public string name { get; set; }
    public string value { get; set; }
}

// ShippingAddress model
public class ShippingAddress
{
    public string address1 { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string phone { get; set; }
    public string country { get; set; }
    public string country_code { get; set; }
    public string province { get; set; }
    public string province_code { get; set; }
    public string district_code { get; set; }
    public string district { get; set; }
    public string ward_code { get; set; }
    public string ward { get; set; }
}

// Order model
public class Order
{
    public ItemInCart[] line_items { get; set; }
    public double total_discounts { get; set; }
    public ShippingAddress shipping_address { get; set; }
    public OrderDiscountCode[] discount_codes { get; set; }
    public NoteAttribute[] note_attributes { get; set; } 
    public string gateway { get; set; }
}
