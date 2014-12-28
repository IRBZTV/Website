<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Polls.aspx.cs" Inherits="Bazaar.Cp.Polls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvPolls" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPolls_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
        <Columns>
            <asp:TemplateField HeaderText="شناسه">
                <ItemTemplate>
                    <asp:Label ID="LblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                </ItemTemplate>
                 <HeaderStyle Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان">
                <ItemTemplate>
                     <a href='<%# Eval("ID","/cp/pollsedit/{0}") %>' title="ویرایش سوال و گزینه ها">
                       <%# Eval("Title") %></a>                 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="فعال">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnActive" ImageUrl='<%# BoolToImage(Eval("Active")) %>'
                        CommandName="Active" CommandArgument='<%# Eval("ID") %>' runat="server" />
                </ItemTemplate>
                 <HeaderStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تاریخ ایجاد">
                <ItemTemplate>
                    <asp:Label ID="LblDateTime" runat="server" Text='<%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("DATETIME").ToString()),true) %>'></asp:Label>
                </ItemTemplate>
                 <HeaderStyle Width="130px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نمایش نتایج">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnSHOWRESULT" ImageUrl='<%# BoolToImage(Eval("SHOWRESULT")) %>'
                        CommandName="ToggleSHOWRESULT" CommandArgument='<%# Eval("ID") %>' runat="server" />
                </ItemTemplate>
                 <HeaderStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="رای جدید">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnALLOWNEW" ImageUrl='<%# BoolToImage(Eval("ALLOWNEW")) %>'
                        CommandName="ALLOWNEW" CommandArgument='<%# Eval("ID") %>' runat="server" />
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnDelete" OnClientClick="return confirm('آیا گزینه انتخاب شده حذف گردد؟');"
                        CommandName="DeletePoll" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="~/Cp/Theme/Icon/delete.png" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="30px" />
            </asp:TemplateField>          
        </Columns>
    </asp:GridView>
</asp:Content>
