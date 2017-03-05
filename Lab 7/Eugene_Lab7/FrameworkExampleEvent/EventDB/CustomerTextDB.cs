using System;
using System.Collections.Generic;
using EventPropsClasses;
using ToolsCSharp;
using DBBase = ToolsCSharp.BaseTextDB;

namespace EventPropsClasses
{
    public class CustomerTextDB : DBBase, IReadDB, IWriteDB
    {
      #region Constructors

      public CustomerTextDB() : base() { }
      public CustomerTextDB(string cnString) : base(cnString) { }

      #endregion

      public int IndexOf(List<CustomerProps> list, int key)
      {
        int index = 0;
        foreach (CustomerProps props in list)
        {
          if (props.CustomerID == key)
          {
            return index;
          }
          index++;
        }
        return -1;
      }

      public int NextID(List<CustomerProps> list)
      {
        int next = Int32.MinValue;
        foreach (CustomerProps props in list)
          if (props.CustomerID > next)
            next = props.CustomerID;
        next++;
        return next;
      }

      public void Delete(int id)
      {
        CustomerProps props = new CustomerProps();
        props.CustomerID = id;
        Delete(props);
      }

      #region IReadDB Members
      /// <summary>
      /// </summary>
      public IBaseProps Retrieve(Object key)
      {
        CustomerProps props;
        List<CustomerProps> customers = new List<CustomerProps>();

        try
        {
          customers = (List<CustomerProps>)ReadAll("customers", customers.GetType());
          int index = IndexOf(customers, (int)key);
          if (index != -1)
          {
            props = (CustomerProps)customers[index];
            return props;
          }
          else
            throw new Exception("Customer with id of " + key.ToString() + " does not exist");
        }

        catch (Exception)
        {
          // log this exception
          throw;
        }

        finally
        {
        }
      } // end of Retrieve()
      #endregion

      #region IWriteDB Members
      /// <summary>
      /// </summary>
      public IBaseProps Create(IBaseProps p)
      {
        CustomerProps props = (CustomerProps)p;
        List<CustomerProps> customers = new List<CustomerProps>();

        try
        {
          customers = (List<CustomerProps>)ReadAll("customers", customers.GetType());
          props.CustomerID = NextID(customers);
          props.ConcurrencyID = 1;
          customers.Add(props);
          WriteAll("customers", customers);
          return props;
        }

        catch (Exception)
        {
          // log the error
          throw;
        }

        finally
        {
        }
      } // end of Create()

      /// <summary>
      /// </summary>
      public bool Delete(IBaseProps p)
      {
      CustomerProps props = (CustomerProps)p;
        List<CustomerProps> customers = new List<CustomerProps>();

        try
        {
        customers = (List<CustomerProps>)ReadAll("customers", customers.GetType());
          int index = IndexOf(customers, props.CustomerID);
          if (index != -1)
          {
          customers.RemoveAt(index);
            WriteAll("customers", customers);
            return true;
          }
          else
            throw new Exception("Customer with id of " + props.CustomerID.ToString() + " does not exist");

        }

        catch (Exception)
        {
          // log the error
          throw;
        }

        finally
        {
        }
      } // end of Delete()

      /// <summary>
      /// </summary>
      public bool Update(IBaseProps p)
      {
      CustomerProps props = (CustomerProps)p;
        List<CustomerProps> customers = new List<CustomerProps>();

        try
        {
          customers = (List<CustomerProps>)ReadAll("customers", customers.GetType());
          int index = IndexOf(customers, props.CustomerID);
          if (index != -1)
          {
            if (props.ConcurrencyID == customers[index].ConcurrencyID)
            {
              customers.RemoveAt(index);
              props.ConcurrencyID++;
              customers.Add(props);
              WriteAll("customers", customers);
              return true;
            }
            else
              throw new Exception("Customer with id of " + props.CustomerID.ToString() + " appears to have been edited by another user.  Changes can not be saved.");
          }
          else
            throw new Exception("Customer with id of " + props.CustomerID.ToString() + " does not exist");

        }

        catch (Exception)
        {
          // log this error
          throw;
        }

        finally
        {
        }
      } // end of Update()
      #endregion
    }
 }




