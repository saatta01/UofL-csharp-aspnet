using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HA2.MyClasses
{
    public class GenerateSessionObjects
    {
        List<Account> accountList = new List<Account>();

        public GenerateSessionObjects()
        {
            Account acct1 = new Account();
            acct1.Type = "Checking";
            acct1.Balance = 1350.00;
            acct1.Nickname = "Checking1";

            Account acct2 = new Account();
            acct2.Type = "Saving";
            acct2.Balance = 32600.00;
            acct2.Nickname = "Saving1";

            Account acct3 = new Account();
            acct3.Type = "Checking";
            acct3.Balance = 225.00;
            acct3.Nickname = "Checking2";

            accountList.Add(acct1);
            accountList.Add(acct2);
            accountList.Add(acct3);

            Customer customer1 = new Customer("Sara Attarzadeh", "525 Sunshine Lane");
            HttpContext.Current.Session["custObj"] = customer1;
            HttpContext.Current.Session["acctList"] = accountList;
        }
    }
}