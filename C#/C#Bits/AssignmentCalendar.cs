//Spy Assignment Calendar 
//devu.com C# Fundamentals via ASP.NET Web Applications
//Lesson 5 Challenge Working with ASP.NET and Formatting Strings
//This code is located at Default.aspx.cs in project solution.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssignmentForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                prevCalendar.SelectedDate = DateTime.Now.Date;
                startCalendar.VisibleDate = DateTime.Now.Date.AddDays(16);
                startCalendar.SelectedDate = DateTime.Now.Date.AddDays(16);
                endCalendar.VisibleDate = DateTime.Now.Date.AddDays(36);
                endCalendar.SelectedDate = DateTime.Now.Date.AddDays(36);
            }
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string assign = assignTextBox.Text;

            if (nameTextBox.Text == "" || assignTextBox.Text == "")
            {
                resultLabel.Text = "You have to choose an agent and an assignment.";
                return;
            }

            TimeSpan sincePrevDays = startCalendar.SelectedDate.Subtract(prevCalendar.SelectedDate);

            if (sincePrevDays.TotalDays > 15)
            {
                TimeSpan assignLength = endCalendar.SelectedDate.Subtract(startCalendar.SelectedDate);
                double salary = 500.00 * (assignLength.TotalDays + 1);

                if (assignLength.TotalDays > 20)
                {
                    salary += 1000.00;
                }
               
                resultLabel.Text = String.Format("Assigning {0} to assignment: {1}. Approved. Budget: {2:C}.", name, assign, salary);
            }

            else
            {
                resultLabel.Text = "Give a spy a break. Sorry, you need to choose a later start date. Union rules.";
                startCalendar.SelectedDate = prevCalendar.SelectedDate.AddDays(14);
            }
            
        }
    }
}