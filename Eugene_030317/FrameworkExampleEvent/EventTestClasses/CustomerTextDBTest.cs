using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;
using EventPropsClasses;
using System.Xml.Serialization;
using System.IO;

namespace EventTestClasses
{
  class CustomerTextDBTest
  {
    private string folder = "C:\\Users\\anuch\\Desktop\\CS 234N_Fall\\Lab 3\\FrameworkExampleEvent\\Files\\";


    [Test]
    public void TestRetrieve()
    {
      CustomerTextDB db = new CustomerTextDB(folder);
      CustomerProps p = (CustomerProps)db.Retrieve(2);
      Assert.AreEqual("Sandra Bullock", p.name);
      Assert.AreEqual("Eugene", p.city);
    }

    [Test]
    public void TestCreate()
    {
      CustomerTextDB db = new CustomerTextDB(folder);
      CustomerProps props = new CustomerProps();
      props.CustomerID = 3;
      props.name = "Christine McVie";
      props.address = "123 Rodeo dr.";
      props.city = "Creswell";
      props.state = "Oregon";
      props.zipcode = "97404";
      

      CustomerProps propsNew = (CustomerProps)db.Create(props);
      Assert.AreEqual(3, propsNew.CustomerID);
      Assert.AreEqual("123 Rodeo dr.", propsNew.address);
      Assert.AreEqual("Creswell", propsNew.city);
      Assert.AreEqual("97404", propsNew.zipcode);
    }

    [Test]
    public void TestUpdate()
    {
      CustomerTextDB db = new CustomerTextDB(folder);
      CustomerProps props = new CustomerProps();
      CustomerProps propsNew = (CustomerProps)db.Create(props);

    }

    [Test]
    public void TestDelete()
    {
      CustomerTextDB db = new CustomerTextDB(folder);
      CustomerProps p = (CustomerProps)db.Retrieve(2);
      Assert.AreEqual(2, p.CustomerID);

      bool ok = db.Delete(p);
      Assert.True(ok);
      try
      {
        p = (CustomerProps)db.Retrieve(2);
        Assert.Fail();
      }
      catch
      {
        Assert.Pass();
      }
    }

    [SetUp]
    public void WriteListOfProps()
    {
      List<CustomerProps> customers = new List<CustomerProps>();

      CustomerProps props = new CustomerProps();
      props.CustomerID = 1;
      props.name = "John Smith";
      props.address = "678 Main st.";
      props.city = "Springfield";
      props.state = "Oregon";
      props.zipcode = "97402-9867";
      props.ConcurrencyID = 6;
      customers.Add(props);

      props = new CustomerProps();
      props.CustomerID = 2;
      props.name = "Sandra Bullock";
      props.address = "3365 W. 11th. Ave.";
      props.city = "Eugene";
      props.state = "OR";
      props.zipcode = "97401";
      props.ConcurrencyID = 7;
      customers.Add(props);

      XmlSerializer serializer = new XmlSerializer(customers.GetType());
      Stream writer = new FileStream(folder + "customers.xml", FileMode.Create);
      serializer.Serialize(writer, customers);
      writer.Close();

    }
  }
}


