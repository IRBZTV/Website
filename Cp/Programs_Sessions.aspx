<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Programs_Sessions.aspx.cs" Inherits="Bazaar.Cp.Programs_Sessions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div id="overview" class="subhead subhead-collapse">
        <div class="container">
            <h3 class="pull-right">لیست قسمت های برنامه
            </h3>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:HyperLink ID="HplinkNewSession" ImageUrl="~/Cp/Theme/Icon/add.png" runat="server" Title="اضافه کردن قسمت جدید">
                </asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    CssClass="requests table table-striped table-bordered table-hover" OnRowCommand="GridView1_RowCommand">
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
                        <asp:TemplateField HeaderText="قسمت">
                            <ItemTemplate>
                                <%# Eval("NUMBER")%>
                            </ItemTemplate>
                            <ItemStyle Width="50" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تصویر">
                            <ItemTemplate>
                                <img src='<%#  Bazaar.Core.ThumbnailGenerator.Generate(Eval("IMAGE").ToString(),140,0)%>' />
                            </ItemTemplate>
                            <ItemStyle Width="140" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="موضوع">
                            <ItemTemplate>
                                <a href='<%# BuildEditUrl(Eval("ID")) %>' title="برای ویرایش کلیک کنید"><%#(Eval("Title")) %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاریخ">
                            <ItemTemplate>
                                <%# Bazaar.Core.Utility.GD2StringDateTime( DateTime.Parse(Eval("DATETIME").ToString()))%>
                            </ItemTemplate>
                            <ItemStyle Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="فعال">
                            <ItemTemplate>
                                <asp:ImageButton Width="26" ID="IngBtnActive" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Active" ImageUrl='<%# BoolToImage(Eval("Active")) %>' />
                            </ItemTemplate>
                            <ItemStyle Width="30" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
