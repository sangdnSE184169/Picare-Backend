#nullable disable
namespace Models;
public class Customer
{
    public bool accepts_marketing{ get; set; }
    public Address[] addresses{ get; set; }
    public DateTime created_at{ get; set; }
    public Address default_address{ get; set; }
    public string email{ get; set; }
    public string phone{ get; set; }
    public string first_name{ get; set; }
    public Int64 id{ get; set; }
    public string last_name{ get; set; }
    public Int64? last_order_id{ get; set; }
    public string last_order_name{ get; set; }
    public int orders_count{ get; set; }
    public string state{ get; set; }
    public string tags{ get; set; } // only has "newsletter"
    public DateTime updated_at{ get; set; }
    public bool verified_email{ get; set; }
    public string group_name{ get; set; }
    public DateTime? last_order_date{ get; set; }
}            
