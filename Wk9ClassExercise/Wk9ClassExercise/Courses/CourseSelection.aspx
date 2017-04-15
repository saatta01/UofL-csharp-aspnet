<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseSelection.aspx.cs" Inherits="Wk9ClassExercise.Courses.CourseSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Selections</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 146px;
        }
        .auto-style3 {
            width: 172px;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 172px;
            text-align: center;
        }
        .auto-style6 {
            width: 146px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style6">Easy Courses</td>
            <td class="auto-style5">Difficult Courses</td>
            <td class="auto-style4">Selections</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:ListBox ID="easyCourseListBox" runat="server" Width="135px"></asp:ListBox>
            </td>
            <td class="auto-style3">
                <asp:ListBox ID="difficultCoursesListBox" runat="server"></asp:ListBox>
            </td>
            <td>
                <asp:ListBox ID="selectionListBox" runat="server"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="addCourseButton" runat="server" OnClick="addCourseButton_Click" Text="Add Course" />
            </td>
            <td class="auto-style3">
                <asp:Button ID="finalizeSelectionButton" runat="server" OnClick="finalizeSelectionButton_Click" Text="Finalize Selection" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="FirstNameLabel" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LastNameLabel" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="StudentIDLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div>
    
    </div>
    </form>
</body>
</html>
