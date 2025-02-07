#nullable disable

namespace Models;
public class Country{
    public string code{ get; set; }
    public Int64 id{ get; set; }
    public string name{ get; set; }

    public virtual Province[] provinces{ get; set; }
}

public class District{
    public Int64 id{ get; set; }
    public string name{ get; set; }
    public string code{ get; set; }
    public Int64 province_id{ get; set; }
}

public class Province{
    public string code{ get; set; }
    public Int64 country_id{ get; set; }
    public Int64 id{ get; set; }
    public string name{ get; set; }
}

public class Ward{
    public Int64 id{ get; set; }
    public string name{ get; set; }
    public string code{ get; set; }
    public Int64 district_id{ get; set; }
}

