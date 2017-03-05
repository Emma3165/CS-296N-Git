using System;
using System.Collections.Generic;

using ToolsCSharp;
using EventDB = EventPropsClasses.EventTextDB;

namespace EventClasses
{
    public class Event : BaseBusiness
    {
        #region SetUpStuff
        /// <summary>
        /// 
        /// </summary>		
        public override void SetDefaultProperties()
        {
            mProps = new EventProps();
        }

        /// <summary>
        /// Sets required fields for a record.
        /// </summary>
        public override void SetRequiredRules()
        {
            mRules.RuleBroken("UserID", true);
            mRules.RuleBroken("Title", true);
            mRules.RuleBroken("Description", true);
        }

        /// <summary>
        /// Instantiates mProps and mOldProps as new Props objects.
        /// Instantiates mbdReadable and mdbWriteable as new DB objects.
        /// </summary>
        private void SetUp()
        {
            mProps = new EventProps();
            mOldProps = new EventProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new EventDB();
                mdbWriteable = new EventDB();
            }

            else
            {
                mdbReadable = new EventDB(this.mConnectionString);
                mdbWriteable = new EventDB(this.mConnectionString);
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Default constructor - does nothing.
        /// </summary>
        public Event()
        {
            SetUp();
            SetRequiredRules();
            SetDefaultProperties();
        }

        /// <summary>
        /// One arg constructor.
        /// Calls methods SetUp(), SetRequiredRules(), 
        /// SetDefaultProperties() and BaseBusiness one arg constructor.
        /// </summary>
        /// <param name="cnString">DB connection string.
        /// This value is passed to the one arg BaseBusiness constructor, 
        /// which assigns the it to the protected member mConnectionString.</param>
        public Event(string cnString)
            : base(cnString)
        {
            SetUp();
            SetRequiredRules();
            SetDefaultProperties();
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
        public Event(int key, string cnString)
            : base(cnString)
        {
            SetUp();
            Load(key);
        }

        public Event(int key)
            : base()
        {
            SetUp();
            Load(key);
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
                return ((EventProps)mProps).ID;
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public int UserID
        {
            get
            {
                return ((EventProps)mProps).userID;
            }

            set
            {
                if (!(value == ((EventProps)mProps).userID))
                {
                    if (value > 0)
                    {
                        mRules.RuleBroken("UserID", false);
                        ((EventProps)mProps).userID = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("UserID must be a positive number.");
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
        public string Title
        {
            get
            {
                return ((EventProps)mProps).title;
            }

            set
            {
                if (!(value == ((EventProps)mProps).title))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("Title", false);
                        ((EventProps)mProps).title = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Title must be between 1 and 50 characters");
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
                return ((EventProps)mProps).description;
            }

            set
            {
                if (!(value == ((EventProps)mProps).description))
                {
                    if (value.Length >= 1 && value.Length <= 2000)
                    {
                        mRules.RuleBroken("Description", false);
                        ((EventProps)mProps).description = value;
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
        public DateTime Date
        {
            get
            {
                return ((EventProps)mProps).date;
            }

            set
            {
                if (!(value == ((EventProps)mProps).date))
                {
                    ((EventProps)mProps).date = value;
                    mIsDirty = true;
                }
            }
        }
        #endregion

        #region others
        /// <summary>
        /// Retrieves a list of Events.
        /// </summary>
        public static List<Event> GetList()
        {
            EventDB db = new EventDB();
            List<Event> events = new List<Event>();
            List<EventProps> props = new List<EventProps>();

            props = (List<EventProps>)db.ReadAll("events", props.GetType());
            foreach (EventProps prop in props)
            {
                Event e = new Event(prop.ID, "");
                events.Add(e);
            }

            return events;
        }

        public static List<Event> GetList(string cnString)
        {
            EventDB db = new EventDB(cnString);
            List<Event> events = new List<Event>();
            List<EventProps> props = new List<EventProps>();

            props = (List<EventProps>)db.ReadAll("events", props.GetType());
            foreach (EventProps prop in props)
            {
                Event e = new Event(prop.ID, cnString);
                events.Add(e);
            }

            return events;
        }

        /// <summary>
        /// Deletes the customer identified by the id.
        /// </summary>
        public static void Delete(int id)
        {
            EventDB db = new EventDB();
            db.Delete(id);
        }

        public static void Delete(int id, string cnString)
        {
            EventDB db = new EventDB(cnString);
            db.Delete(id);
        }
        #endregion
    }
}
