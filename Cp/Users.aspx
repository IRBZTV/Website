<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="~/Cp/Users.aspx.cs" EnableEventValidation="true"  Inherits="Bazaar.Cp.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="requests table table-striped table-bordered table-hover" OnRowCommand="GridView1_RowCommand">
        <Columns>
              <asp:TemplateField HeaderText="#">
              <ItemTemplate>
              <%# Container.DataItemIndex+1%>
              </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="نام  کامل">
              <ItemTemplate>
                  <a href='<%# EditPage(Eval("UserName")) %>' title="برای ویرایش کلیک کنید" ><%#GetUserFullName(Eval("UserName")) %></a>
              </ItemTemplate>
          </asp:TemplateField>
             <asp:TemplateField HeaderText="نام کاربری">
              <ItemTemplate>
                   <a href='<%# EditPage(Eval("UserName")) %>' title="برای ویرایش کلیک کنید" ><%#Eval("UserName") %></a>
              </ItemTemplate>
          </asp:TemplateField>          
                <asp:TemplateField HeaderText="فعال">
              <ItemTemplate>
                   <asp:ImageButton ID="ImgBtnActive" runat="server" CommandArgument='<%# Eval("USERNAME") %>' CommandName="Active" ImageUrl='<%# BoolToImage(Eval("IsApproved")) %>' />
              </ItemTemplate>
          </asp:TemplateField>
              <asp:TemplateField HeaderText="قفل">
              <ItemTemplate>
                   <asp:ImageButton Width="26" ID="ImgBtnLock" runat="server" CommandArgument='<%# Eval("USERNAME") %>' CommandName="Lock" ImageUrl='<%# IsLock(Eval("IsLockedOut")) %>' />
              </ItemTemplate>
          </asp:TemplateField>
               <asp:TemplateField HeaderText="آنلاین">
              <ItemTemplate>
                   <asp:ImageButton ID="ImgBtnOnline" runat="server" CommandArgument='<%# Eval("USERNAME") %>' CommandName="ToggleActive" ImageUrl='<%# IsOnline(Eval("IsOnline")) %>' />
              </ItemTemplate>
          </asp:TemplateField>
              <asp:TemplateField HeaderText="ایجاد">
              <ItemTemplate>
                   <a href=""><%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("CreationDate").ToString()),true) %></a>
              </ItemTemplate>
          </asp:TemplateField>
               <asp:TemplateField HeaderText="آخرین ورود">
              <ItemTemplate>
                <a href=""><%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("LastLoginDate").ToString()),true) %></a>
              </ItemTemplate>
          </asp:TemplateField>
               <asp:TemplateField HeaderText="آخرین قفل">
              <ItemTemplate>
                  <a href=""><%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("LastLockoutDate").ToString()),true) %></a>
              </ItemTemplate>
          </asp:TemplateField>
              <asp:TemplateField HeaderText="تغییر رمز">
              <ItemTemplate>
                  <a href=""><%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("LastPasswordChangedDate").ToString()),true) %></a>
              </ItemTemplate>
          </asp:TemplateField>
             <asp:TemplateField HeaderText="حذف">
              <ItemTemplate>
                   <asp:ImageButton ID="imgBtnDelete" OnClientClick="return confirm('آیا کاربر انتخاب شده حذف گردد؟');"
                                    CommandName="DeleteUser" CommandArgument='<%# Eval("USERNAME") %>'
                                    ImageUrl="/Cp/Theme/Icon/delete.png" runat="server" />
              </ItemTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
