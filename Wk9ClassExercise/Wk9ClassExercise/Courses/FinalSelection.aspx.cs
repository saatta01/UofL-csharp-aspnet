using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wk9ClassExercise.Courses
{
    public partial class FinalSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null)
            {
                TextBox firstNameTextBox =
                    (TextBox)PreviousPage.FindControl("firstNameTextBox");
                FirstNameLabel.Text = firstNameTextBox.Text;

                TextBox lastNameTextBox =
                    (TextBox)PreviousPage.FindControl("lastNameTextBox");
                LstNameLabel.Text = lastNameTextBox.Text;

                TextBox studentIDTextBox =
                    (TextBox)PreviousPage.FindControl("studentIDTextBox");
                StudentIDLabel.Text = studentIDTextBox.Text;

                ListBox selectionListBox =
                    (ListBox)PreviousPage.FindControl("selectionListBox");
                //finalSelectionsListBox.Items.Add(selectionListBox.SelectedValue
                foreach (var item in selectionListBox.Items)
                {
                                  
                }


            }



        }
    }
}