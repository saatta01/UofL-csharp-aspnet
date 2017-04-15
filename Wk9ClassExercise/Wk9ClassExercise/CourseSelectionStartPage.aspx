<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseSelectionStartPage.aspx.cs" Inherits="Wk9ClassExercise.CourseSelectionStartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Details</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">First Name</td>
                <td>
                    <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Last Name</td>
                <td>
                    <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Student ID</td>
                <td>
                    <asp:TextBox ID="studentIDTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="goCourseSelectionButton" runat="server" Text="Go To Course Selection" OnClick="goCourseSelectionButton_Click" PostBackUrl="~/Courses/CourseSelection.aspx" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:RequiredFieldValidator ID="fNameRequiredFieldValidator" runat="server" ControlToValidate="firstNameTextBox" ErrorMessage="First name is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:RequiredFieldValidator ID="lNameRequiredFieldValidator" runat="server" ControlToValidate="lastNameTextBox" ErrorMessage="Last name is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:RequiredFieldValidator ID="studentIDRequiredFieldValidator" runat="server" ControlToValidate="studentIDTextBox" ErrorMessage="Student ID is required."></asp:RequiredFieldValidator>
&nbsp;&nbsp;
                    <asp:RangeValidator ID="studentIDRangeValidator" runat="server" ControlToValidate="studentIDTextBox" ErrorMessage="Student ID must be a six digit number." MaximumValue="999999" MinimumValue="100000" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
