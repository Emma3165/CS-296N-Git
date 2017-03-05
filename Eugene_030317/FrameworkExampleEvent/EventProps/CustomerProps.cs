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
  public class CustomerProps : IBaseProps
  {

    #region instance variables
    /// <summary>
    /// 
    /// </summary>
    public int CustomerID = Int32.MinValue;

    /// <summary>
    /// 
    /// </summary>
    public string name = "";

    /// <summary>
    /// 
    /// </summary>
    public string address = "";

    /// <summary>
    /// 
    /// </summary>
    public string city = "";

    public string state = "";

    /// <summary>
    /// 
    /// </summary>
    public string zipcode = "";

    /// <summary>
    /// ConcurrencyID. See main docs, don't manipulate directly
    /// </summary>
    public int ConcurrencyID = 0;
    #endregion

    #region constructor
    /// <summary>
    /// Constructor. This object should only be instantiated by Customer, not used directly.
    /// </summary>
    public CustomerProps()
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
      CustomerProps c = (CustomerProps)serializer.Deserialize(reader);
      this.CustomerID = c.CustomerID;
      this.name = c.name;
      this.address = c.address;
      this.city = c.city;
      this.state = c.state;
      this.zipcode = c.zipcode;
      this.ConcurrencyID = c.ConcurrencyID;
    }
    #endregion

    #region ICloneable Members
    /// <summary>
    /// Clones this object.
    /// </summary>
    /// <returns>A clone of this object.</returns>
    public Object Clone()
    {
      CustomerProps c = new CustomerProps();
      c.CustomerID = this.CustomerID;
      c.name = this.name;
      c.address = this.address;
      c.city = this.city;
      c.state = this.state;
      c.zipcode = this.zipcode;
      c.ConcurrencyID = this.ConcurrencyID;
      return c;
    }
    #endregion

  }
}
