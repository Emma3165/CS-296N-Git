using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductClasses
{
  /// <summary>
  /// provide 
  /// </summary>
  public class Product
  {
    private string code;
    private string description;
    private decimal unitPrice;
    private int onHandQuality;

    public string Code { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }

    public int OnHandQuality { get; set; }
  }
}
