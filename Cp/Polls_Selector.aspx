<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Polls_Selector.aspx.cs" Inherits="Bazaar.Cp.Polls_Selector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvPolls" runat="server" AutoGenerateColumns="False" OnDataBound="gvPolls_DataBound" DataKeyNames="PAGE_MODULE_ID" OnRowCommand="gvPolls_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
        <Columns>
            <asp:TemplateField HeaderText="عنوان صفحه">
                <ItemTemplate>
                    <asp:Label runat="server" ID="OptionLblTitle" Text='<%# GetPageTitle(Eval("page_Module_ID")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان ماژول">
                <ItemTemplate>
                    <asp:Label runat="server" ID="OptionLblTitlee" Text='<%# GetPageModuleTitle(Eval("page_Module_ID")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان نظر سنجی">
                <ItemTemplate>
                    <asp:HiddenField ID="hfmoduleconfigid" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ذخیره">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnSave"
                        CommandName="SaveValue" CommandArgument='<%#  Container.DataItemIndex %>'
                        ImageUrl="~/Cp/Theme/Icon/Save.png" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
