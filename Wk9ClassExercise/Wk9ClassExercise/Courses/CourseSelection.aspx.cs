using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wk9ClassExercise.Courses
{
    public partial class CourseSelection : System.Web.UI.Page
    {
        List<string> easyCourses = new List<string>();
        List<string> difficultCourses = new List<string>();

        int noOfEasyCourses;
        int noOfDifficultCourses;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                easyCourses.Add("College Algebra");
                easyCourses.Add("Intro to Literature");
                easyCourses.Add("Intro to Biological Systems");
                easyCourses.Add("Elements of Physics");
                easyCourses.Add("Intro to Public Speaking");

                difficultCourses.Add("Advanced Biomaterials");
                difficultCourses.Add("Environmental Policy");
                difficultCourses.Add("Wills, estates, and trusts");
                difficultCourses.Add("Health Promotion and Disease Prevention");
                difficultCourses.Add("Parallel Programming");
            }


            if (PreviousPage != null)
            {
                TextBox firstNameTextBox =
                    (TextBox)PreviousPage.FindControl("firstNameTextBox");
                FirstNameLabel.Text = firstNameTextBox.Text;

                TextBox lastNameTextBox =
                    (TextBox)PreviousPage.FindControl("lastNameTextBox");
                LastNameLabel.Text = lastNameTextBox.Text;

                TextBox studentIDTextBox =
                    (TextBox)PreviousPage.FindControl("studentIDTextBox");
                StudentIDLabel.Text = studentIDTextBox.Text;
            }


        }

        protected void addCourseButton_Click(object sender, EventArgs e)
        {
            if(easyCourseListBox.SelectedIndex != -1 || difficultCoursesListBox.SelectedIndex != -1)
            {
                if (easyCourseListBox.SelectedIndex != -1 && easyCourseListBox.SelectedIndex != -1)
                {
                    selectionListBox.Items.Add(easyCourseListBox.SelectedValue);
                    selectionListBox.Items.Add(difficultCoursesListBox.SelectedValue);
                }
                else if (easyCourseListBox.SelectedIndex != -1)
                {
                    selectionListBox.Items.Add(easyCourseListBox.SelectedValue);
                }
                else
                {
                    selectionListBox.Items.Add(difficultCoursesListBox.SelectedValue);
                }

            }
            else
            {
                ErrorLabel.Text = "Please make a course selection.";
            }
            
        }

        protected void finalizeSelectionButton_Click(object sender, EventArgs e)
        {
            foreach (var item in selectionListBox.Items)
            {
                String course = item.ToString();
                if (easyCourses.Contains(course))
                {
                    noOfEasyCourses++;
                }
                if (difficultCourses.Contains(course))
                {
                    noOfDifficultCourses++;
                }
            }            if (noOfEasyCourses <= 4 && (noOfDifficultCourses>=1 && noOfDifficultCourses <= 3) && (noOfEasyCourses+noOfDifficultCourses >=4 || noOfEasyCourses + noOfDifficultCourses <=6))
            {
                Server.Transfer("FinalSelection.aspx");
            }            else
            {
                string myStringVariable = "Following are the course selection rules: (1) # of easy courses: Max 4, (2) # of difficult courses: 1 to 3, (3) Total # of courses: 4 to 6.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

            }
        }
    
        public int numberEasyCourses()
        {
            return noOfEasyCourses;
        }
        public int numberDifficultCourses()
        {
            return noOfDifficultCourses;
        }
    }
}