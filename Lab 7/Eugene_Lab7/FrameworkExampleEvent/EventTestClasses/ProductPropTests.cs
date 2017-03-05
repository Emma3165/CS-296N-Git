using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;

namespace EventTestClasses
{
  [TestFixture]
  class ProductPropTests
  {
    private ProductProps p;

    [SetUp]
    public void CreateP()
    {
      p = new ProductProps();
      p.ID = 47;
      p.code = "test";
      p.description = "This is a test";
      p.qty = 10;
      p.unitPrice = 10;

      p.ConcurrencyID = 6;

    }
    

    

    [Test]
    public void TestGetState()
    {
      
      string xml = p.GetState();
      // check the text to make sure that there is text in xml.
      Assert.Greater(xml.Length, 0);
      // compare there is the text contain in xml
      Assert.True(xml.Contains("This is a test"));
      Console.WriteLine(xml);
    }

    [Test]
    public void TestSetState()
    {

     string xml = p.GetState();
     ProductProps newP = new ProductProps();
      newP.SetState(xml);
      Assert.AreEqual(p.ID, newP.ID);
      Assert.AreEqual(p.unitPrice, newP.unitPrice);
    }


    [Test]
    public void TestClone()
    {
    ProductProps newP = (ProductProps)p.Clone();
    Assert.AreEqual(p.ID, newP.ID);
    Assert.AreEqual(p.unitPrice, newP.unitPrice);
    }
  }
}
