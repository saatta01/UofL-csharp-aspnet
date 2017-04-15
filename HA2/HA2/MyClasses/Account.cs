using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HA2.MyClasses
{
    public class Account
    {
        string _type;
        double _balance;
        string _nickname;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        public bool hasLoanOffer()
        {
            if (Balance > 15000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}