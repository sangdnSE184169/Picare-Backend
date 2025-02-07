#nullable disable
using Models;

namespace Helper;

public class OrderRequest{
    public Order order{ get; set; }
}

public class OrdersResponse{
    public PlacedOrder[] orders{ get; set; }
}
