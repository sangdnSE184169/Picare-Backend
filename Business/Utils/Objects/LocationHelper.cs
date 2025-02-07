#nullable disable
using Models;

public class CountryResponse{ 
    public Country country{ get; set; }
}

public class CountriesReponse{ 
    public Country[] countries{ get; set; }
}

public class ProvinceResponse{
    public Province[] provinces{ get; set; }
}

public class DistrictResponse{
    public District[] districts{ get; set; }
}

public class WardResponse{
    public Ward[] wards{ get; set; }
}
