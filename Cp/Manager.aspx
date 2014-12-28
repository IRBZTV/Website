<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="Bazaar.Cp.Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div id="overview" class="subhead subhead-collapse">
        <div class="container">
            <h3 class="pull-right">تنظیمات ماژول </h3>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="requests table table-striped table-bordered table-hover">
        <tr>
            <td>صفحه:</td>
            <td>
                <asp:DropDownList ID="DdlPages" Font-Names="B Yekan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlPages_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>موقعیت:</td>
            <td>
                <asp:DropDownList ID="DdlPagePositions" runat="server" Font-Names="B Yekan">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>نوع ماژول</td>
            <td>
                <asp:DropDownList ID="DdlModules" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlModules_SelectedIndexChanged" Font-Names="B Yekan">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>قالب محتوا:</td>
            <td>
                <asp:DropDownList ID="DdlTemplates" runat="server" Font-Names="B Yekan">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td>عنوان:</td>
            <td>
                <asp:TextBox ID="txtModuleTitle" runat="server" Font-Names="B Yekan"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>قالب عنوان:</td>
            <td>
                <asp:DropDownList ID="DdlModuleContainer" runat="server" Font-Names="B Yekan">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>پارامترها</td>
            <td>
                <asp:GridView ID="GvModulesParams" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnDataBound="GvModulesParams_DataBound" CssClass="requests table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="مقدار">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfmoduleconfigid" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="پارامتر">
                            <ItemTemplate>
                                <asp:Label ID="LblParamKind" Font-Names="B Yekan" runat="server" Text='<%# Eval("TITLE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="شناسه">
                            <ItemTemplate>
                                <asp:Label ID="LblId" Font-Names="B Yekan" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <asp:Button ID="BtnSave" Font-Names="B Yekan" runat="server" CssClass="btn-danger" Text="ذخیره" OnClick="BtnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
