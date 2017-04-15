using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HA2.MyClasses;

namespace HA2.AccountPages
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Customer customer1 = (Customer)HttpContext.Current.Session["custObj"];
            List<Account> acctList = (List<Account>)HttpContext.Current.Session["acctList"];
            int selectAcctIndx = (int)HttpContext.Current.Session["selectAcctIdx"];

            AccountNameLabel.Text = acctList[selectAcctIndx].Nickname;
            AccountTypeLabel.Text = acctList[selectAcctIndx].Type;
            BalanceLabel.Text = acctList[selectAcctIndx].Balance.ToString("c2");
            LoanLabel.Text = acctList[selectAcctIndx].hasLoanOffer().ToString();
            AddressLabel.Text = customer1.FullAddress;
        }

        protected void WithdrawalButton_Click(object sender, EventArgs e)
        {
            Customer customer1 = (Customer)HttpContext.Current.Session["custObj"];
            List<Account> acctList = (List<Account>)HttpContext.Current.Session["acctList"];
            int selectAcctIndx = (int)HttpContext.Current.Session["selectAcctIdx"];

            double wthdrawamt = double.Parse(WithdrawalTextBox.Text);
            if(wthdrawamt <= acctList[selectAcctIndx].Balance)
            {
                acctList[selectAcctIndx].Balance = acctList[selectAcctIndx].Balance - wthdrawamt;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                WithdrawErrorLabel.Text = " Withdrawal Amount is greater than Balance.";
            }
        }

        protected void LoanButton_Click(object sender, EventArgs e)
        {

        }
    }
}