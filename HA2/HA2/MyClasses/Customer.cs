using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HA2.MyClasses
{
    public class Customer
    {
        string _fullName;
        string _fullAddress;

        public string FullName
        {
            get { return _fullName; }
        }
        public string FullAddress
        {
            get { return _fullAddress; }
        }

        public Customer(string name, string address)
        {
            _fullName = name;
            _fullAddress = address;
        }
    }
}