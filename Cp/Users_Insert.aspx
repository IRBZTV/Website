<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Users_Insert.aspx.cs" Inherits="Bazaar.Cp.Users_Insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">







    <table style="width: 100%;">
        <tr>
            <td>نام کاربری</td>
            <td>
                <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
            </td>
            <td>نام کامل</td>
            <td>
                <asp:TextBox ID="TxtFullName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>رمز</td>
            <td>
                <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
            </td>
            <td>تکرارا رمز</td>
            <td>
                <asp:TextBox ID="TxtPassConfirm" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>برنامه</td>
            <td>
                <asp:DropDownList ID="DdlProg" runat="server" Font-Names="B YEKAN" CssClass="badge-warning">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td>برنامه</td>
            <td>
            <asp:RadioButtonList runat="server" ID="RadioProgKind">
                <asp:ListItem Text="همه" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="تولیدی" Value="1" ></asp:ListItem>
                  <asp:ListItem Text="بازرگانی" Value="2" ></asp:ListItem>                 
            </asp:RadioButtonList>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>منو ها</td>
            <td>&nbsp;</td>
            <td>دسترسی</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="vertical-align: top">
                <asp:TreeView ID="tvMenus" runat="server" ShowCheckBoxes="All">
                </asp:TreeView>
            </td>
            <td>&nbsp;</td>
            <td style="vertical-align: top">
                <asp:TreeView ID="tvAccess" runat="server" ShowCheckBoxes="All">
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" CssClass="btn-danger" Text="ذخیره" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
