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
using EventPropsClasses;

namespace EventTestClasses
{
    public class CustomerTest
    {

        private string folder = "C:\\Users\\anuch\\Desktop\\CS 234N_Fall\\Lab 3\\FrameworkExampleEvent\\Files\\";

        [Test]
        public void TestNewcustomerConstructor()
        {
            Customer c = new Customer(folder);
            Console.WriteLine(c.ToString());
            Assert.Greater(c.ToString().Length, 1);
        }

        [Test]
        public void TestRetrieveFromDataConstructor()
        {
            Customer c = new Customer(2, folder);
          
            Assert.AreEqual(c.Name, "Sandra Bullock");
            Assert.AreEqual(c.Zipcode, "97401");
            Console.WriteLine(c.ToString());

        }

        [Test]
        public void TestSaveToDataStore()
        {
            Customer c = new Customer(folder);
            c.Name = "Bob Davis";
            c.Address = "123 Main st.";
            c.City = "Creswell";
            c.State = "Oregon";
            c.Zipcode = "97468";
            c.Save();
            Assert.AreEqual("Bob Davis", c.Name);
            Assert.AreEqual("Creswell", c.City);
            Assert.AreEqual("97468", c.Zipcode);

        }

        [Test]
        public void TestUpdate()
        {
            Customer c = new Customer(1, folder);
            c.Name = "John Smith";
            c.City = "Corvalis";
            c.State = "Nevada";
            c.Save();

            c = new Customer(1, folder);
            Assert.AreEqual(c.Name, "John Smith");
            Assert.AreEqual(c.City, "Corvalis");
            Assert.AreEqual(c.State, "Nevada");

        }

        [Test]
        public void TestDelete()
        {
            Customer c = new Customer(1, folder);
            c.Delete();
            c.Save();
            Assert.Throws<Exception>(() => new Customer(1, folder));
        }


        [Test]
        public void TestStaticDelete() //This method will delete without the object if you already know the primary key
        {
            Customer.Delete(2, folder);
            Assert.Throws<Exception>(() => new Customer(2, folder));
        }

        [Test]
        public void TestGetList()
        {
            List<Customer> customers = Customer.GetList(folder);
            Assert.AreEqual(customers.Count, 2);
        }

        [Test]
        public void TestNoRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Customer p = new Customer(folder);
            Assert.Throws<Exception>(() => p.Save());
        }

        [Test]
        public void TestSomeRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Customer p = new Customer(folder);
            Assert.Throws<Exception>(() => p.Save());
            p.City = "Springfield";
            Assert.Throws<Exception>(() => p.Save());
            p.State= "Oregon";
            Assert.Throws<Exception>(() => p.Save());
        }
        // <summary>
        
        // </summary>
        //[Test]
        //public void TestInvalidPropertyUserIDSet()
        //{
        //    Customer c = new Customer(folder);
        //    Assert.Throws<ArgumentOutOfRangeException>(() => c.ID = -1);
        //}


        [Test]
        public void TestIsDirty()
        {
            Customer c = new Customer(1, folder);
            c.Name = "John Smith";
            Assert.IsFalse(c.IsDirty);
        }

        [SetUp]
        public void WriteListOfProps()
        {
            CustomerProps props = new CustomerProps();
            List<CustomerProps> customers = new List<CustomerProps>();
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


  
