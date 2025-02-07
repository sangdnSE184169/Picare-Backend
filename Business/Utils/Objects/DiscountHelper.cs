#nullable disable
using Models;
namespace Helper;

public class DiscountResponse{
    public Discount discount{ get; set; }
}

public class DiscountsResponse{
    public Discount[] discounts{ get; set; }
}

