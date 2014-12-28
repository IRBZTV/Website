<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Services_Insert.aspx.cs" Inherits="Bazaar.Cp.Services_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="requests table table-striped table-bordered table-hover" style="height: 300px;">
        <tr>
            <td colspan="3" class="btn-danger">لطفا گزارش خود را دقیق و با ذکر توضیحات ثبت بفرمایید</td>
        </tr>
        <tr>
            <td style="width: 100px;">گروه فعالیت</td>
            <td style="width: 300px;">
                <asp:DropDownList runat="server" ID="DdlCat" AutoPostBack="true" Font-Names="B YEKAN" CssClass="badge-warning" OnSelectedIndexChanged="DdlCat_SelectedIndexChanged" Width="100%"></asp:DropDownList></td>
            <td style="width: 300px; vertical-align: top;" rowspan="9">
                <asp:TextBox ID="Txtbody" placeholder="توضیحات گزارش" runat="server" Height="500px" TextMode="MultiLine" Width="95%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px;">نوع فعالیت</td>
            <td style="width: 300px;">
                <asp:DropDownList runat="server" ID="DdlList" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%"></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px;">سرویس گیرنده</td>
            <td style="width: 300px;">
                <asp:DropDownList runat="server" ID="DdlClient" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%"></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px;">نوع خدمات</td>
            <td style="width: 300px;">
                <asp:DropDownList runat="server" ID="DdlKind" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%"></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px;">سرویس&nbsp; دهنده</td>
            <td style="width: 300px;">
                <asp:TextBox runat="server" ID="TxtUser" Font-Names="B YEKAN" CssClass="badge-warning" Width="300px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px;">شیفت</td>
            <td style="width: 300px;">
                <asp:DropDownList runat="server" ID="DdlShift" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%">
                    <asp:ListItem Text="شیفت 1" Value="1" Selected="True" />
                    <asp:ListItem Text="شیفت 2" Value="2" />
                    <asp:ListItem Text="شیفت 3" Value="3" />
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px;">دقیقه ویژه آفیش</td>
            <td style="width: 300px;">
                <asp:TextBox runat="server" ID="TxtMinute" TextMode="Number" title="ویژه آفیش به دقیقه"  Text="0"/>
        </tr>
        <tr>
            <td style="width: 100px;">تاریخ</td>
            <td style="width: 300px;">
                <asp:TextBox runat="server" dir="ltr" ID="TxtDate" Font-Names="B YEKAN" CssClass="badge-warning" Width="300px" ></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button Width="100%" Height="50" CssClass="btn btn-success" ID="BtnSave" runat="server" Text="    ذخیره   " OnClick="BtnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
