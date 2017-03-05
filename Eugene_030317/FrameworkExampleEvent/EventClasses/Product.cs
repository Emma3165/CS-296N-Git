using System;
using System.Collections.Generic;
using ToolsCSharp;
using EventPropsClasses;

using DB = EventPropsClasses.ProductTextDB;
using Props = EventPropsClasses.ProductProps;


namespace EventClasses
{
  public class Product : BaseBusiness
  {
    #region SetUpStuff
    /// <summary>
    /// 
    /// </summary>		
    protected override void SetDefaultProperties()
    {
    }

    /// <summary>
    /// Sets required fields for a record.
    /// </summary>
    protected override void SetRequiredRules()
    {
      mRules.RuleBroken("Code", true);
      mRules.RuleBroken("UnitPrice", true);
    
    }

    /// <summary>
    /// Instantiates mProps and mOldProps as new Props objects.
    /// Instantiates mbdReadable and mdbWriteable as new DB objects.
    /// </summary>
    protected override void SetUp()
    {
      mProps = new ProductProps();
      mOldProps = new ProductProps();

      if (this.mConnectionString == "")
      {
        mdbReadable = new DB();
        mdbWriteable = new DB();
      }

      else
      {
        mdbReadable = new DB(this.mConnectionString);
        mdbWriteable = new DB(this.mConnectionString);
      }
    }
    #endregion

    #region constructors
    /// <summary>
    /// Default constructor - does nothing.
    /// </summary>
    public Product() : base()
    {
    }

    /// <summary>
    /// One arg constructor.
    /// Calls methods SetUp(), SetRequiredRules(), 
    /// SetDefaultProperties() and BaseBusiness one arg constructor.
    /// </summary>
    /// <param name="cnString">DB connection string.
    /// This value is passed to the one arg BaseBusiness constructor, 
    /// which assigns the it to the protected member mConnectionString.</param>
    public Product(string cnString)
        : base(cnString)
    {
    }

    /// <summary>
    /// Two arg constructor.
    /// Calls methods SetUp() and Load().
    /// </summary>
    /// <param name="key">ID number of a record in the database.
    /// Sent as an arg to Load() to set values of record to properties of an 
    /// object.</param>
    /// <param name="cnString">DB connection string.
    /// This value is passed to the one arg BaseBusiness constructor, 
    /// which assigns the it to the protected member mConnectionString.</param>
    public Product(int key, string cnString)
        : base(key, cnString)
    {
    }

    public Product(int key)
        : base(key)
    {
    }
    #endregion

    #region properties
    /// <summary>
    /// Read-only ID property.
    /// </summary>
    public int ID
    {
      get
      {
        return ((Props)mProps).ID;
      }
    }

    /// <summary>
    /// Read/Write property. 
    /// </summary>
    public int Quantity
    {
      get
      {
        return ((Props)mProps).qty;
      }

      set
      {
        if (!(value == ((Props)mProps).qty))
        {
          if (value >= 0)
          {
       
            ((Props)mProps).qty = value;
            mIsDirty = true;
          }

          else
          {
            throw new ArgumentOutOfRangeException("Quantity must be equal or greater than 0.");
          }
        }
      }
    }

    /// <summary>
    /// Read/Write property. 
    /// </summary>
    /// <exception cref="ArgumentException">
    /// 
    /// </exception>
    public string Code
    {
      get
      {
        return ((Props)mProps).code;
      }

      set
      {
        if (!(value == ((Props)mProps).code))
        {
          if (value.Length == 4)
          {
            mRules.RuleBroken("Code", false);
            ((Props)mProps).code = value;
            mIsDirty = true;
          }

          else
          {
            throw new ArgumentException("Code must be 4 characters");
          }
        }
      }
    }

    /// <summary>
    /// Read/Write property. 
    /// </summary>
    /// <exception cref="ArgumentException">
    /// 
    /// </exception>
    public string Description
    {
      get
      {
        return ((Props)mProps).description;
      }

      set
      {
        if (!(value == ((Props)mProps).description))
        {
          if (value.Length >= 1 && value.Length <= 2000)
          {
            ((Props)mProps).description = value;
            mIsDirty = true;
          }

          else
          {
            throw new ArgumentException("Description must be between 1 and 2000 characters");
          }
        }
      }
    }

    /// <summary>
    /// Read/Write property. 
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if the value is null or less than 1.
    /// </exception>
    public Decimal UnitPrice
    {
      get
      {
        return ((Props)mProps).unitPrice;
      }

      set
      {
        if (!(value == ((Props)mProps).unitPrice))
        {
          if (value > 0.0M) 
          mRules.RuleBroken("UnitPrice", false);
          ((Props)mProps).unitPrice = value;
          mIsDirty = true;
        }
      

          else
          {
        throw new ArgumentException("Code must be 4 characters");
      }
    }
    }
    #endregion

    #region others
    /// <summary>
    /// Retrieves a list of Events.
    /// </summary>
    public static List<Product> GetList()
    {
      DB db = new DB();
      List<Product> products = new List<Product>();
      List<Props> props = new List<Props>();

      props = (List<Props>)db.ReadAll("products", props.GetType());
      foreach (Props prop in props)
      {
        Product p = new Product(prop.ID, "");
        products.Add(p);
      }

      return products;
    }

    public static List<Product> GetList(string cnString)
    {
      DB db = new DB(cnString);
      List<Product> products = new List<Product>();
      List<Props> props = new List<Props>();

      props = (List<Props>)db.ReadAll("products", props.GetType());
      foreach (Props prop in props)
      {
        Product p = new Product(prop.ID, cnString);
        products.Add(p);
      }

      return products;
    }

    /// <summary>
    /// Deletes the customer identified by the id.
    /// </summary>
    public static void Delete(int id)
    {
      DB db = new DB();
      db.Delete(id);
    }

    public static void Delete(int id, string cnString)
    {
      DB db = new DB(cnString);
      db.Delete(id);
    }
    #endregion
  }
}
