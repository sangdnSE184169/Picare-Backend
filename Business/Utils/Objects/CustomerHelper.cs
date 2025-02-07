#nullable disable
using Models;
namespace Helper;

public class CustomerResponse{
    public Customer[] customers{ get; set; }
}

public class CustomerInfoOnly{
    public string first_name{ get; set; }
    public string last_name{ get; set; }
    public string email{ get; set; }
    public string phone{ get; set; }
    public bool verified_email{ get; set; }
    public bool send_email_invite{ get; set; }
}

public class CustomerInfoOnlyRequest{
    public CustomerInfoOnly customer{ get; set; }
}

public class CustomerWithAddress{
    public string first_name{ get; set; }
    public string last_name{ get; set; }
    public string email{ get; set; }
    public string phone{ get; set; }
    public bool verified_email{ get; set; }
    public bool send_email_invite{ get; set; }
    public Address[] addresses{ get; set; }
}

public class CustomerWithAddressRequest{
    public CustomerWithAddress customer{ get; set; }
}
