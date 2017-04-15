using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HA2.MyClasses;

namespace HA2
{
    public partial class AccountSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["CustObj"] == null)
            {
              GenerateSessionObjects genSession1 = new GenerateSessionObjects();
            }
            Customer customer1 = (Customer)HttpContext.Current.Session["custObj"];
            List<Account> acctList = (List<Account>)HttpContext.Current.Session["acctList"];

            WelcomeLabel.Text = "Weclome " + customer1.FullName;
            foreach (Account a in acctList)
            {
                AccountNicknameListBox.Items.Add(a.Nickname);
            }
             

        }

        protected void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            int selectAcctIndx = AccountNicknameListBox.SelectedIndex;
            HttpContext.Current.Session["selectAcctIdx"] = selectAcctIndx;
            Server.Transfer("AccountPages/AccountDetails.aspx");
        }
    }
}