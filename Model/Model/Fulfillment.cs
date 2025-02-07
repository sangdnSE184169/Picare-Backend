#nullable disable

namespace Models;

public class Fulfillment{
    public DateTime created_at{ get; set; }
    public Int64 id{ get; set; }
    public Int64 order_id{ get; set; }
    public string status{ get; set; }
    public string tracking_company{ get; set; }
    public string tracking_company_code{ get; set; }
    public string tracking_number{ get; set; }
    public string tracking_url{ get; set; }
    public DateTime updated_at{ get; set; }

#region vị trí kho
    public string province{ get; set; }
    public string province_code{ get; set; }
    public string district{ get; set; }
    public string district_code{ get; set; }
    public string ward{ get; set; }
    public string ward_code{ get; set; }
    public double cod_amount{ get; set; }
    public string carrier_status_name{ get; set; }
    public string carrier_cod_status_name{ get; set; }
    public string carrier_status_code{ get; set; }
    public string carrier_cod_status_code{ get; set; }
    public Int64 location_id{ get; set; }
    public string location_name{ get; set; }
#endregion
    public string note{ get; set; }
    public string carrier_service_package_name{ get; set; }
    public DateTime ready_to_pick_date{ get; set; }
    public DateTime? picking_date{ get; set; }
    public DateTime? delivering_date{ get; set; }
    public DateTime? delivered_date{ get; set; }
    public DateTime? return_date{ get; set; }
    public DateTime? not_meet_customer_date{ get; set; }
    public DateTime? waiting_for_return_date{ get; set; }
    public DateTime? cod_paid_date{ get; set; }
    public DateTime? cod_receipt_date{ get; set; }
    public DateTime? cod_pending_date{ get; set; }
    public DateTime? cod_not_receipt_date{ get; set; }
    public DateTime? cancel_date{ get; set; }
    public double real_shipping_fee{ get; set; }
    public string shipping_notes{ get; set; }
}
