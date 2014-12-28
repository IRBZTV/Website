<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="Bazaar.Cp.Albums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
        CssClass="requests table table-striped table-bordered table-hover" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" >
        <Columns>
              <asp:TemplateField HeaderText="#">
              <ItemTemplate>
              <%# Container.DataItemIndex+1%>
              </ItemTemplate>
                    <ItemStyle Width="50" />
          </asp:TemplateField>              
          <asp:TemplateField HeaderText="عنوان">
              <ItemTemplate>
                  <a href='<%# (Eval("ID","/cp/Albums/Edit/{0}")) %>' title="برای ویرایش کلیک کنید" ><%#(Eval("Title")) %></a>
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
             <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnDelete" OnClientClick="return confirm('آیا آلبوم انتخاب شده حذف گردد؟');"
                                    CommandName="DeleteAlbum" CommandArgument='<%# Eval("ID") %>'
                                    ImageUrl="/Cp/Theme/Icon/delete.png" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>    
        </Columns>
    </asp:GridView>
</asp:Content>
