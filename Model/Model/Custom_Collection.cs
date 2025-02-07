#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;
public class CustomCollection
{
    public string body_html { get; set; }
    public string handle { get; set; }

    public Int64 id { get; set; }
    public bool published { get; set; }
    public DateTime published_at { get; set; }
    public string published_scope { get; set; }

    public string title { get; set; }
    public DateTime updated_at { get; set; }
    public int products_count { get; set; }
}
