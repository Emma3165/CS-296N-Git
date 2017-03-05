using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPropsClasses;
using ToolsCSharp;
using DB = EventPropsClasses.CustomerTextDB;


namespace EventClasses
{
    public class Customer : BaseBusiness
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
            mRules.RuleBroken("Name", true);
            mRules.RuleBroken("Address", true);
            mRules.RuleBroken("City", true);
            mRules.RuleBroken("State", true);
            mRules.RuleBroken("Zipcode", true);


        }

        /// <summary>
        /// Instantiates mProps and mOldProps as new Props objects.
        /// Instantiates mbdReadable and mdbWriteable as new DB objects.
        /// </summary>
        protected override void SetUp()
        {
            mProps = new CustomerProps();
            mOldProps = new CustomerProps();

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
        public Customer() : base()
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
        public Customer(string cnString)
            : base(cnString)
        {
        }

        /// <summary>
        /// Two arg constructor.
        /// Calls methods SetUp() and Load().
        /// </summary>
        /// <param name="key">CustomerID number of a record in the database.
        /// Sent as an arg to Load() to set values of record to properties of an 
        /// object.</param>
        /// <param name="cnString">DB connection string.
        /// This value is passed to the one arg BaseBusiness constructor, 
        /// which assigns the it to the protected member mConnectionString.</param>
        public Customer(int key, string cnString)
            : base(key, cnString)
        {
        }

        public Customer(int key)
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
                return ((Props)mProps).CustomerID;
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the value is null or more than 25.
        public string Name
        {
            get
            {
                return ((Props)mProps).name;
            }
            set
            {
                if (!(value == ((Props)mProps).name))
                {
                    if (value.Length > 0 && value.Length < 25)
                    {
                        mRules.RuleBroken("Name", false);
                        ((Props)mProps).name = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Name has to be between 1 and 25 characters.");
                    }

                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the value is null or more than 50
        /// </exception>
        public string Address
        {
            get
            {
                return ((Props)mProps).address;
            }

            set
            {
                if (!(value == ((Props)mProps).address))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("Address", false);
                        ((Props)mProps).address = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Address must be between 1 and 50 characters");
                    }
                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the value is null or more than 20
        /// </exception>
        public string City
        {
            get
            {
                return ((Props)mProps).city;
            }

            set
            {
                if (!(value == ((Props)mProps).city))
                {
                    if (value.Length >= 1 && value.Length <= 20)
                    mRules.RuleBroken("City", false);
                    ((Props)mProps).city = value;
                    mIsDirty = true;
                }
                else
                {
                    throw new ArgumentException("City need must be between 1 and 20 characters");
                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the value is null or more than 15
        /// </exception>
        public string State
        {
            get
            {
                return ((Props)mProps).state;
            }

            set
            {
                if (!(value == ((Props)mProps).state))
                {
                    if (value.Length >= 1 && value.Length <= 15)
                    mRules.RuleBroken("State", false);
                    ((Props)mProps).state = value;
                    mIsDirty = true;
                }
                else
                {
                    throw new ArgumentException("State must be between 1 and 15 characters");
                }
            }
        }


        /// <summary>
        /// Read/Write property. 
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the value is between 5-10 characters.
        /// </exception>
        public string Zipcode
        {
            get
            {
                return ((Props)mProps).zipcode;
            }

            set
            {
                if (!(value == ((Props)mProps).zipcode))
                {
                    if (value.Length <= 5 && value.Length <= 10)
                    {
                        mRules.RuleBroken("Zipcode", false);
                        ((Props)mProps).zipcode = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("zipcode must be betwen 5 and 10 characters");
                    }
                }
            }
        }



        #endregion

        #region others
        /// <summary>
        /// Retrieves a list of Customers.
        /// </summary>
        public static List<Customer> GetList()
        {
            DB db = new DB();
            List<Customer> customers = new List<Customer>();
            List<Props> props = new List<Props>();

            props = (List<Props>)db.ReadAll("customers", props.GetType());
            foreach (Props prop in props)
            {
                Customer p = new Customer(prop.CustomerID, "");
                customers.Add(p);
            }

            return customers;
        }

        public static List<Customer> GetList(string cnString)
        {
            DB db = new DB(cnString);
            List<Customer> customers = new List<Customer>();
            List<Props> props = new List<Props>();

            props = (List<Props>)db.ReadAll("customers", props.GetType());
            foreach (Props prop in props)
            {
                Customer c = new Customer(prop.CustomerID, cnString);
                customers.Add(c);
            }

            return customers;
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


