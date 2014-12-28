<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Programs_Insert.aspx.cs" Inherits="Bazaar.Cp.Programs_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div id="overview" class="subhead subhead-collapse">
        <div class="container">
            <h3 class="pull-right">اطلاعات برنامه</h3>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%;">
        <tr>
            <td style="width: 100px;">شناسه</td>
            <td>
                <asp:TextBox ID="TxtId" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px;">عنوان</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>خلاصه</td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" Height="100px" TextMode="MultiLine" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>توضیحات</td>
            <td>
                <asp:TextBox ID="txtBody" runat="server" Height="150px" TextMode="MultiLine" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>عوامل</td>
            <td>
                <asp:TextBox ID="txtRoles" runat="server" Height="100px" TextMode="MultiLine" Width="99%"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td colspan="2" class="btn-danger">
                <asp:Label ID="LblError" runat="server" ></asp:Label>
            </td>          
        </tr>
          <tr>            
            <td colspan="2" class="btn-danger">فقط تصاویر با فرمت .jpg  و اندازه  عرض 610 پیکسل  و ارتفاع 343 پیکسل  قابل قبول است </td>
        </tr>        
        <tr>
            <td>انتخاب تصویر</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="190" />
            </td>
        </tr>
        <tr>
            <td>تصویر</td>
            <td>
                <asp:Image ID="Image1" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                  <asp:Button ID="BtnSave" runat="server" CssClass="btn-danger" Text="    ذخیره   " OnClick="BtnSave_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
