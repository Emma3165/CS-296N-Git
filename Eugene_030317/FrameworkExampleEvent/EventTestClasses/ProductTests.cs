using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventClasses;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EventTestClasses
{
  [TestFixture]
  public class ProductTests
  {
    private string folder = "C:\\Users\\anuch\\Desktop\\CS 234N_Fall\\Lab 3\\FrameworkExampleEvent\\Files\\";

    [Test]
    public void TestNewproductConstructor()
    {
      Product p = new Product(folder);
      Console.WriteLine(p.ToString());
      Assert.Greater(p.ToString().Length,1);
    }

    [Test]
    public void TestRetrieveFromDataConstructor()
    {
      Product p = new Product(2, folder);
      Assert.AreEqual(p.ID, 2);
      Assert.AreEqual(p.Code, "pro2");
      Console.WriteLine(p.ToString());

    }

    [Test]
    public void TestSaveToDataStore()
    {
      Product p = new Product(folder);
      p.Code = "pro3";
      p.UnitPrice = 39.99M;
      p.Quantity = 4;
      p.Save();
      Assert.AreEqual("pro3", p.Code);
      Assert.AreEqual(39.99M, p.UnitPrice);
      Assert.AreEqual(4, p.Quantity);
    }

    [Test]
    public void TestUpdate()
    {
      Product p = new Product(1, folder);
      p.Code = "pro4";
      p.Description = "Dumbell";
      p.Quantity = 6;
      p.Save();

      p = new Product(1, folder);
      Assert.AreEqual(p.Code, "pro4");
      Assert.AreEqual(p.Description, "Dumbell");
      Assert.AreEqual(p.Quantity, 6);

      
    }

    [Test]
    public void TestDelete()
    {
      Product p = new Product(1, folder);
      p.Delete();
      p.Save();
      Assert.Throws<Exception>(() => new Product(1, folder));
    }

    
    [Test]
    public void TestStaticDelete() //This method will delete without the object if you already know the primary key
    {
      Product.Delete(2, folder);
      Assert.Throws<Exception>(() => new Product(2, folder));
    }

    [Test]
    public void TestGetList()
    {
      List<Product> products = Product.GetList(folder);
      Assert.AreEqual(products.Count, 2);
    }

    [Test]
    public void TestNoRequiredPropertiesNotSet()
    {
      // not in Data Store - userid, title and description must be provided
      Product p = new Product(folder);
      Assert.Throws<Exception>(() => p.Save());
    }

    [Test]
    public void TestSomeRequiredPropertiesNotSet()
    {
      // not in Data Store - userid, title and description must be provided
      Product p = new Product(folder);
      Assert.Throws<Exception>(() => p.Save());
      p.Code = "pro1";
      Assert.Throws<Exception>(() => p.Save());
      p.Quantity = 10;
      Assert.Throws<Exception>(() => p.Save());
    }

    [Test]
    public void TestInvalidPropertyUserIDSet()
    {
      Event e = new Event(folder);
      Assert.Throws<ArgumentOutOfRangeException>(() => e.UserID = -1);
    }




    [SetUp]
    public void WriteListOfProps()
    {
      List<ProductProps> products = new List<ProductProps>();

      ProductProps props = new ProductProps();
      props.ID = 1;
      props.qty = 10;
      props.code = "pro1";
      props.description = "Tennis Racket";
      props.unitPrice = 49.99M;
      products.Add(props);

      props = new ProductProps();
      props.ID = 2;
      props.qty = 12;
      props.code = "pro2";
      props.description = "Shoes";
      props.unitPrice = 29.99M;
      products.Add(props);

      XmlSerializer serializer = new XmlSerializer(products.GetType());
      Stream writer = new FileStream(folder + "products.xml", FileMode.Create);
      serializer.Serialize(writer, products);
      writer.Close();
    }
  }

}

