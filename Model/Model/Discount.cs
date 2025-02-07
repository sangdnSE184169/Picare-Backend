#nullable disable
namespace Models;

public class DiscountCustomRule{
    public string name{ get; set; }
    public string value{ get; set; }
}

public class Discount{
    public string code{ get; set; }
    public DateTime ends_at{ get; set; }
    public Int64 id{ get; set; }
    public double minimum_order_amount{ get; set; }
    public DateTime starts_at{ get; set; }
    public string status{ get; set; }
    public int usage_limit{ get; set; }
    public double value{ get; set; }
    public int times_used{ get; set; }
    public DateTime created_at{ get; set; }
    public DateTime updated_at{ get; set; }
    public bool is_new_coupon{ get; set; }
    public double? max_amount_apply{ get; set; }
    public bool once_per_customer{ get; set; }
    public string take_type{ get; set; }
}
