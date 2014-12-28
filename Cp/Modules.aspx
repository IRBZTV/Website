<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Modules.aspx.cs" Inherits="Bazaar.Cp.Modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div id="overview" class="subhead subhead-collapse">
        <div class="container">
            <h3 class="pull-right">مدیریت ماژول ها</h3>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                انتخاب صفحه
            </td>
             <td>
                 <asp:DropDownList ID="DdlPages" Font-Names="B YEKAN" runat="server"
                      OnSelectedIndexChanged="DdlPages_SelectedIndexChanged" AutoPostBack="True" CssClass="badge-warning" ></asp:DropDownList>
            </td>
             <td>
                 انتخاب موقعیت
            </td>
             <td>
                 <asp:DropDownList Font-Names="B YEKAN" ID="DdlPagePositions" runat="server" AutoPostBack="True" CssClass="badge-warning" OnSelectedIndexChanged="DdlPagePositions_SelectedIndexChanged" ></asp:DropDownList>
            </td>
            
             <td>

            </td>
        </tr>
         <tr>
            <td colspan="5">
                <asp:GridView ID="gvModules" runat="server" AutoGenerateColumns="False" OnRowCommand="gvModules_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
        <Columns>
            <asp:TemplateField HeaderText="شناسه">
                <ItemTemplate>
                    <asp:Label ID="LblPageId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="فعال">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnPoll" ImageUrl='<%# BoolToImage(Eval("VISIBLE")) %>'
                        CommandName="Active" CommandArgument='<%# Eval("ID") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="صفحه">
                <ItemTemplate>
                    <asp:Label ID="LblPage" runat="server" Text='<%# PageTitle( Eval("PAGE_ID") )%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="محل قرارگیری">
                <ItemTemplate>
                    <asp:Label ID="LblPagePosition" runat="server" Text='<%# PositionTitle( Eval("POSITION_ID")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="نوع ماژول">
                <ItemTemplate>
                    <asp:Label ID="LblPageModule" runat="server" Text='<%# ModuleTitle( Eval("MODULE_ID") )%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان">
                <ItemTemplate>
                    <asp:Label ID="LblPageTitleHere" runat="server" Text='<%# Eval("TITLE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="قالب محتوا">
                <ItemTemplate>
                    <asp:Label ID="LblPageTemlates" runat="server" Text='<%# Eval("TEMPLATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="قالب">
                <ItemTemplate>
                    <asp:Label ID="LblPageContainer" runat="server" Text='<%#ContainerLayoutTitle( Eval("CONTAINER_LAYOUT")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ترتیب">
                <ItemTemplate>
                    <asp:Label ID="LblPageSort" runat="server" Text='<%# Eval("SORT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عملیات">
                <ItemTemplate>
                    <asp:ImageButton Width="20" ID="ImageButton1" runat="server" ImageUrl="~/Cp/Theme/Icon/down_green.png" CommandName="UpPriority" CommandArgument='<%# Eval("ID") %>' title="افرایش ترتیب" />

                    <asp:ImageButton Width="20" ID="ImageButton2" runat="server" ImageUrl="~/Cp/Theme/Icon/up_green.png" CommandName="DownPriority" CommandArgument='<%# Eval("ID") %>' title="کاهش ترتیب" />
                </ItemTemplate>
                <ItemStyle Height="20" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تنظیمات">
                <ItemTemplate>
                    <a href="<%#Eval("ID","/cp/Modules/edit/{0}") %>">
                        <img src="Theme/Icon/Config.png" width="20" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف">
                <ItemTemplate>
                    <asp:ImageButton Width="20" ID="imgBtnDelete" OnClientClick="return confirm('آیا مطئنید ماژول حذف گردد؟');" runat="server" ImageUrl="~/Cp/Theme/Icon/delete.png" CommandName="DeleteModule" CommandArgument='<%# Eval("ID") %>' title="حذف ماژول با تمام تنظیمات" />
                </ItemTemplate>
                <ItemStyle Height="20" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>
    
</asp:Content>
