using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsCSharp;
using System.Xml.Serialization;
using System.IO;

namespace EventPropsClasses
{
  [Serializable()]
  public class ProductProps : IBaseProps
  {

    #region instance variables
    /// <summary>
    /// 
    /// </summary>
    public int ID = Int32.MinValue;

    /// <summary>
    /// 
    /// </summary>
    public string code = "";

    /// <summary>
    /// 
    /// </summary>
    public string description = "";

    /// <summary>
    /// 
    /// </summary>
    public decimal unitPrice = 0.0M;

    /// <summary>
    /// 
    /// </summary>
    public int qty = 0;

    /// <summary>
    /// ConcurrencyID. See main docs, don't manipulate directly
    /// </summary>
    public int ConcurrencyID = 0;
    #endregion

    #region constructor
    /// <summary>
    /// Constructor. This object should only be instantiated by Customer, not used directly.
    /// </summary>
    public ProductProps()
    {
    }

    #endregion

    #region BaseProps Members
    /// <summary>
    /// Serializes this props object to XML, and writes the key-value pairs to a string.
    /// </summary>
    /// <returns>String containing key-value pairs</returns>	
    public string GetState()
    {
      XmlSerializer serializer = new XmlSerializer(this.GetType());
      StringWriter writer = new StringWriter();
      serializer.Serialize(writer, this);
      return writer.GetStringBuilder().ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetState(string xml)
    {
      XmlSerializer serializer = new XmlSerializer(this.GetType());
      StringReader reader = new StringReader(xml);
      ProductProps p = (ProductProps)serializer.Deserialize(reader);
      this.ID = p.ID;
      this.code = p.code;
      this.unitPrice = p.unitPrice;
      this.qty = p.qty;
      this.description = p.description;
      this.ConcurrencyID = p.ConcurrencyID;
    }
    #endregion

    #region ICloneable Members
    /// <summary>
    /// Clones this object.
    /// </summary>
    /// <returns>A clone of this object.</returns>
    public Object Clone()
    {
      ProductProps p = new ProductProps();
      p.ID = this.ID;
      p.code = this.code;
      p.unitPrice = this.unitPrice;
      p.qty = this.qty;
      p.description = this.description;
      p.ConcurrencyID = this.ConcurrencyID;
      return p;
    }
    #endregion

  }
}