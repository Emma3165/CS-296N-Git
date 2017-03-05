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
  class CustomerPropTests
  {
    private CustomerProps c;

    [SetUp]
    public void CreateC()
    {
      c = new CustomerProps();
      c.CustomerID = 12;
      c.name = "John Smith";
      c.address = "3676 W.11th ave.";
      c.city = "Eugene";
      c.state = "Oregon";
      c.zipcode = "97401";
      c.ConcurrencyID = 6;
    }

    [Test]
    public void TestGetState()
    {

      string xml = c.GetState();
      // check the text to make sure that there is text in xml.
      Assert.Greater(xml.Length, 0);
      // compare there is the text contain in xml
      Assert.True(xml.Contains("John Smith"));
      Console.WriteLine(xml);
    }

    [Test]
    public void TestSetState()
    {
      string xml = c.GetState();
      CustomerProps newC = new CustomerProps();
      newC.SetState(xml);
      Assert.AreEqual(c.state, newC.state);
      Assert.AreNotEqual(c.name, newC.zipcode);
    }

    [Test]
    public void TestClone()
    {
      CustomerProps newC = (CustomerProps)c.Clone();
      Assert.AreEqual(c.zipcode, newC.zipcode);
      Assert.AreEqual(c.address, newC.address);
    }
    
  }
}

