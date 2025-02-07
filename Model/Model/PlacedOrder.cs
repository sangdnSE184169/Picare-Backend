#nullable disable
namespace Models;

public class PlacedItemImage{
    public string src{ get; set; }
}

public class PlacedItem{
    public int fulfillable_quantity{ get; set; }
    public string fulfillment_service{ get; set; }
    public string fulfillment_status{ get; set; }
    public Int64 id{ get; set; }
    public double price{ get; set; }
    public double price_original{ get; set; }
    public Int64 product_id{ get; set; }
    public int quantity{ get; set; }
    public string sku{ get; set; }
    public string title{ get; set; }
    public Int64 variant_id{ get; set; }
    public string variant_title{ get; set; }
    public string vendor{ get; set; }
    public string type{ get; set; }
    public string name{ get; set; }
    public PlacedItemImage image{ get; set; }
}

public class Transaction{
    public double amount{ get; set; }
    public DateTime created_at{ get; set; }
    public Int64 id{ get; set; }
    public string kind{ get; set; }
    public Int64 order_id{ get; set; }
    public Int64? user_id{ get; set; }
    public Int64 location_id{ get; set; }
    public string parent_id{ get; set; }// vì transaction lưu theo mảng nên thg này để báo có thg trước ( là status(kind) khác )
}

public class PlacedOrder{
    public Address billing_address{ get; set; }
    public string browser_ip{ get; set; }
    public bool buyer_accepts_marketing{ get; set; }
    public string cancel_reason{ get; set; }
    public DateTime? cancelled_at{ get; set; }  
    public string cart_token{ get; set; }
    public string checkout_token{ get; set; }
    public DateTime created_at{ get; set; }
    public string currency{ get; set; }
    public Customer customer{ get; set; }
    public OrderDiscountCode[] discount_codes{ get; set; }
    public string email{ get; set; }
    public string financial_status{ get; set; }
    public Fulfillment[] fulfillments{ get; set; }
    public string fulfillment_status{ get; set; }
    public string gateway{ get; set; }
    public Int64 id{ get; set; }
    public PlacedItem[] line_items{ get; set; }
    public string name{ get; set; }
    public string note{ get; set; }
    public Int64 number{ get; set; }
    public string order_number{ get; set; }
    public Address shipping_address{ get; set; }
    public double subtotal_price{ get; set; }
    public string token{ get; set; }
    public double total_discounts{ get; set; }
    public double total_line_items_price{ get; set; }
    public double total_price{ get; set; }
    public double total_tax{ get; set; }
    public DateTime updated_at{ get; set; }
    public Transaction[] transaction{ get; set; }
    public NoteAttribute[] note_attributes{ get; set; }
    public string closed_status{ get; set; }
    public string cancelled_status{ get; set; }
    public string confirmed_status{ get; set; }
    public DateTime? assigned_location_at{ get; set; }
    public Int64? user_id{ get; set; }
    public Int64 location_id{ get; set; }
    public string location_name{ get; set; }
    public string contact_email{ get; set; }
    public string order_processing_status{ get; set; }
    public Int64? prev_order_id{ get; set; }
    public string prev_order_number{ get; set; }
    public string prev_order_date{ get; set; }
}
