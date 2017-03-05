using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventClasses;
using EventPropsClasses;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EventTestClasses
{
    [TestFixture]
    public class EventTests
    {
        private string folder = "C:\\Users\\anuch\\Desktop\\CS 234N_Fall\\Lab 3\\FrameworkExampleEvent\\Files\\";

        [Test]
        public void TestNewEventConstructor()
        {
            // not in Data Store - no id
            Event e = new Event(folder);
            Console.WriteLine(e.ToString());
            Assert.Greater(e.ToString().Length, 1);
        }

        
        [Test]
        public void TestRetrieveFromDataStoreContructor()
        {
            // retrieves from Data Store
            Event e = new Event(1, folder);
            Assert.AreEqual(e.ID, 1);
            Assert.AreEqual(e.Title, "First Event");
            Console.WriteLine(e.ToString());
        }
        
        [Test]
        public void TestSaveToDataStore()
        {
            Event e = new Event(folder);
            e.UserID = 1;
            e.Title = "Third Event";
            e.Description = "This is the third event in my event list.";
            e.Save();
            Assert.AreEqual(1, e.UserID);
            Assert.AreEqual("Third Event", e.Title);
        }
        
        [Test]
        public void TestUpdate()
        {
            Event e = new Event(1, folder);
            e.UserID = 2;
            e.Title = "Edited Event";
            e.Save();

            e = new Event(1, folder);
            Assert.AreEqual(e.ID, 1);
            Assert.AreEqual(e.UserID, 2);
            Assert.AreEqual(e.Title, "Edited Event");
        }
        
        [Test]
        public void TestDelete()
        {
            Event e = new Event(2, folder);
            e.Delete();
            e.Save();
            Assert.Throws<Exception>(() => new Event(2, folder));
        }

        [Test]
        public void TestStaticDelete()
        {
            Event.Delete(2, folder);
            Assert.Throws<Exception>(() => new Event(2, folder));
        }

        [Test]
        public void TestGetList()
        {
            List<Event> events = Event.GetList(folder);
            Assert.AreEqual(events.Count, 2);
        }

        [Test]
        public void TestNoRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Event e = new Event(folder);
            Assert.Throws<Exception>(() => e.Save());
        }

        [Test]
        public void TestSomeRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Event e = new Event(folder);
            Assert.Throws<Exception>(() => e.Save());
            e.UserID = 1;
            Assert.Throws<Exception>(() => e.Save());
            e.Title = "this is a test";
            Assert.Throws<Exception>(() => e.Save());
        }

        [Test]
        public void TestInvalidPropertyUserIDSet()
        {
            Event e = new Event(folder);
            Assert.Throws<ArgumentOutOfRangeException>(() => e.UserID = -1);   
        }
        
        #region OtherStuff

        [SetUp]
        public void WriteListOfProps()
        {
            List<EventProps> events = new List<EventProps>();

            EventProps props = new EventProps();
            props.ID = 1;
            props.userID = 1;
            props.date = DateTime.Now;
            props.title = "First Event";
            props.description = "This is the description of the first event";
            events.Add(props);

            props = new EventProps();
            props.ID = 2;
            props.userID = 2;
            props.date = DateTime.Now;
            props.title = "Second Event";
            props.description = "This is the description of the second event";
            events.Add(props);

            XmlSerializer serializer = new XmlSerializer(events.GetType());
            Stream writer = new FileStream(folder + "events.xml", FileMode.Create);
            serializer.Serialize(writer, events);
            writer.Close();
        }
        #endregion
    }
}
