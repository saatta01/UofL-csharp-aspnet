using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HA2.MyClasses;

namespace HA2.AccountPages
{
    public partial class LoanApplicationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Customer customer1 = (Customer)HttpContext.Current.Session["custObj"];
            NameLabel.Text = customer1.FullName;           

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            List<Account> acctList = (List<Account>)HttpContext.Current.Session["acctList"];
            int selectAcctIndx = (int)HttpContext.Current.Session["selectAcctIdx"];
            
            if (int.Parse(AgeTextBox.Text) > 18 && double.Parse(LoanAmountTextBox.Text) < acctList[selectAcctIndx].Balance && double.Parse(LoanAmountTextBox.Text) < 0.5*double.Parse(SalaryTextBox.Text))
            {
                LoanApprovalLabel.Text = "Congratulations!! Your loan is approved";
            }
            else
            {
                LoanApprovalLabel.Text = "Your loan is not approved. Sorry!!";
            }
        }
    }
}