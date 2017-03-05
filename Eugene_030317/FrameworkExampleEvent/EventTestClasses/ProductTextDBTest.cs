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

  [TestFixture]
  public class ProductTextDBTest
  {

    private string folder = "C:\\Users\\anuch\\Desktop\\CS 234N_Fall\\Lab 3\\FrameworkExampleEvent\\Files\\";


    [Test]
    public void TestRetrieve()
    {
      ProductTextDB db = new ProductTextDB(folder);
      ProductProps p = (ProductProps)db.Retrieve(2);
      Assert.AreEqual(20, p.qty);
      Assert.AreEqual("test 2", p.code);
    }

    [Test]
    public void TestCreate()
    {
      ProductTextDB db = new ProductTextDB(folder);
      ProductProps props = new ProductProps();
      props.code = "test 3";
      props.description = "This is a test 3";
      props.unitPrice = 300;
      props.qty = 30;

      ProductProps propsNew = (ProductProps)db.Create(props);
      Assert.AreEqual(3, propsNew.ID);
      Assert.AreEqual(1, propsNew.ConcurrencyID);
      Assert.AreEqual(300, propsNew.unitPrice);
      Assert.AreEqual(30, propsNew.qty);
    }

    [Test]
    public void TestUpdate()
    {
      ProductTextDB db = new ProductTextDB(folder);
      ProductProps props = new ProductProps();
      ProductProps propsNew = (ProductProps)db.Create(props);

    }

    [Test]
    public void TestDelete()
    {
      ProductTextDB db = new ProductTextDB(folder);
      ProductProps p = (ProductProps)db.Retrieve(2);
      Assert.AreEqual(2, p.ID);

      bool ok = db.Delete(p);
      Assert.True(ok);
      try
      {
        p = (ProductProps)db.Retrieve(2);
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
      List<ProductProps> products = new List<ProductProps>();

      ProductProps props = new ProductProps();
      props.ID = 1;
      props.code = "test 1";
      props.description = "This is a test 1";
      props.unitPrice = 100;
      props.qty = 10;
      props.ConcurrencyID = 6;
      products.Add(props);

      props = new ProductProps();
      props.ID = 2;
      props.code = "test 2";
      props.description = "This is a test 2";
      props.unitPrice = 200;
      props.qty = 20;
      props.ConcurrencyID = 6;
      products.Add(props);

      XmlSerializer serializer = new XmlSerializer(products.GetType());
      Stream writer = new FileStream(folder + "products.xml", FileMode.Create);
      serializer.Serialize(writer, products);
      writer.Close();

    }
  }
}
