#nullable disable
namespace Models;

public class Option{                                                    //  ? nếu ko đụng thì có thể cân nhắc bỏ luôn 
    public string name{ get; set; }                                                           //  ? chỉ có 1 cái số lượng và 1 cái là quy cách? 
    public Int64 id{ get; set; }
    public int position{ get; set; }
    public Int64? product_id{ get; set; }
}

public class Inventory_advance{                                         //  ? Docs ko nois ro cai nay nen se can hoi lai 
    public int qty_available{ get; set; }
    public int qty_onhand{ get; set; }
    public int qty_commited{ get; set; }
    public int qty_incoming{ get; set; }
}

public class Variant {
    //barcode: string | null,
    public double compare_at_price{ get; set; } //cái này là giá chưa được giảm (nếu có)
    public string created_at{ get; set; }
    //fulfillment_service: string | null,                                       
    public double grams{ get; set; }
    public Int64 id{ get; set; }
    public string inventory_management{ get; set; }                           //"haravan", null,  ?
    public string inventory_policy{ get; set; } //'deny', 'continue'                              ? cái này có phải hết hàng vẫn đặt được ko ấy nhỉ?
    public int inventory_quantity{ get; set; } 
    //old_inventory_quantity: int,                                           ?
    public string  inventory_quantity_adjustment{ get; set; }
    //position: int,                                                         ? mặc định mình ko dùng variance nên chỉ có 1 position duy nhất à
    public double price{ get; set; }
    public Int64 product_id{ get; set; }
    public bool requires_shipping{ get; set; } //                                              ? bộ có sản phầm ko cần giao hàng à?
    public string  sku{ get; set; } //                                                      ? Chắc chắn cần nhưng có sản phẩm chưa có
    public bool taxable{ get; set; } //                                                        ? đang ko hiểu sao 91 cái thì chỉ có  1 cái là false
    public string title{ get; set; }
    public string updated_at{ get; set; }
    public int? image_id{ get; set; } 
    public string option1{ get; set; }
    //option2: string | null,
    //option3: string | null,
    public Inventory_advance inventory_advance{ get; set; } 
}

public class Image {
    public string created_at{ get; set; }
    public Int64 id{ get; set; }
    public int position{ get; set; }
    public Int64 product_id{ get; set; }
    public string src{ get; set; }
    public string updated_at{ get; set; }
    //attachment: string | null,
    public string filename{ get; set; }
    //variant_ids: []
}

public class Product{
    public string body_html{ get; set; }
    public string handle{ get; set; }
    public Int64 id{ get; set; }
    public Image[] images{ get; set; }
    public string product_type{ get; set; }
    public string published_at{ get; set; }
    public string published_scope{ get; set; } //cái này sẽ có giá trị là "global", "pos", "web"
    public string  tags{ get; set; } 
    public string template_suffix{ get; set; } //"product" và "product.hoa_chat"
    public string title{ get; set; }
    public string updated_at{ get; set; }
    public Variant[] variants{ get; set; }
    public string vendor{ get; set; }
    public Option[] options{ get; set; }
    public bool only_hide_from_list{ get; set; }
    public bool not_allow_promotion{ get; set; }
}
