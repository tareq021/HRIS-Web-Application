<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRISWebForm.aspx.cs" Inherits="HRISWebApplication.HRISWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <h2>Human Resource Information System</h2>
        <h3>Employee Information</h3>
        
    <div>
    <table>
        <tr>
            <td>
                ID
            </td>
            <td>
                <asp:TextBox ID="employeeIdTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                Name
            </td>
            <td>
                <asp:TextBox ID="employeeNameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                Department
            </td>
            <td>
                <asp:DropDownList ID="departmentDropDownList" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />                
                <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click" />            
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="ReportLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        </table>

        <table>
         <tr>
            
            <td colspan="2">
                <asp:GridView ID="displayGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>

                        <asp:TemplateField HeaderText ="Name">
                            <ItemTemplate>
                                <%#Eval("Name") %>
                            </ItemTemplate>
                            </asp:TemplateField>

                        <asp:TemplateField HeaderText ="ID">
                            <ItemTemplate>
                                <%#Eval("ID") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText ="Department">
                            <ItemTemplate>
                                <%#Eval("DepartmentID") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl ='<%# String.Concat("~/UI/HRISWebForm.aspx?id=", Eval("Id") ) %>' Text="Edit"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
