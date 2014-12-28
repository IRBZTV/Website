<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="Bazaar.Cp.Programs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div id="overview" class="subhead subhead-collapse">
        <div class="container">
            <h3 class="pull-right">لیست برنامه ها</h3>
            <a href="/cp/print/programs.aspx" target="_blank">
                <img width="40" src="Theme/img/Print.png" /></a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
        CssClass="requests table table-striped table-bordered table-hover" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1%>
                </ItemTemplate>
                <ItemStyle Width="30" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="شناسه">
                <ItemTemplate>
                    <%# Eval("ID")%>
                </ItemTemplate>
                <ItemStyle Width="50" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="اولویت">
                <ItemTemplate>
                    <asp:TextBox ID="TxtPriority" Width="50" runat="server" Text='<%# Eval("PRIORITY") %>'></asp:TextBox>
                    <asp:ImageButton Width="26" ID="IngBtnPriority" runat="server" CommandArgument='<%# Container.DisplayIndex %>'
                        CommandName="Priority" ImageUrl="~/Cp/Theme/Icon/Save.png" ImageAlign="Top" />
                </ItemTemplate>
                <ItemStyle Width="100" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تصویر">
                <ItemTemplate>
                    <img src='<%#  Bazaar.Core.ThumbnailGenerator.Generate(Eval("IMAGE").ToString(),80,0)%>' width="80" />
                </ItemTemplate>
                <ItemStyle Width="80" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان">
                <ItemTemplate>
                    <a href='<%# (Eval("ID","/cp/Programs/Edit/{0}")) %>' title="برای ویرایش کلیک کنید"><%#(Eval("Title")) %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="فعال">
                <ItemTemplate>
                    <asp:ImageButton Width="26" ID="IngBtnActive" runat="server" CommandArgument='<%# Eval("ID") %>'
                        CommandName="Active" ImageUrl='<%# BoolToImage(Eval("Active")) %>' />
                </ItemTemplate>
                <ItemStyle Width="30" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تاریخ">
                <ItemTemplate>
                    <%# Bazaar.Core.Utility.GD2StringDateTime( DateTime.Parse(Eval("DATETIME").ToString()))%>
                </ItemTemplate>
                <ItemStyle Width="200" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="صفحه اول">
                <ItemTemplate>
                    <asp:ImageButton Width="26" ID="ImgBtHomePage" runat="server" CommandArgument='<%# Eval("ID") %>'
                        CommandName="HomePage" ImageUrl='<%# BoolToImage(Eval("Homepage")) %>' />
                </ItemTemplate>
                <ItemStyle Width="65" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="قسمت ها">
                <ItemTemplate>
                    <a href='<%# (Eval("ID","/cp/Programs/Session/{0}")) %>' target="_blank" title=" دیدن لیست قسمت ها">
                        <img src="Theme/Icon/video.png" />
                    </a>
                </ItemTemplate>
                <ItemStyle Width="65" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnDelete" OnClientClick="return confirm('آیا برنامه انتخاب شده حذف گردد؟');"
                        CommandName="DeleteProg" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="/Cp/Theme/Icon/delete.png" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تصاویر">
                <ItemTemplate>
                    <a target="_blank" title="برای ویرایش  تصاویر  کلیک کنید" href="<%#Eval("ID","/cp/Programs/Photos/{0}") %>">
                        <img src="/cp/Theme/Icon/Image.png" /></a>
                </ItemTemplate>
                <ItemStyle Width="50" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
