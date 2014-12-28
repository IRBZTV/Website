<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Bazaar.Cp.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 60px; vertical-align: middle">از تاریخ:</td>
            <td style="width: 120px; vertical-align: top">
                <asp:TextBox runat="server" ID="txtStartDate" Width="120" /></td>
            <td style="width: 60px; vertical-align: middle">تا تاریخ:</td>
            <td style="width: 120px; vertical-align: top">
                <asp:TextBox runat="server" ID="txtEndDate" Width="120" /></td>
            <td style="width: 90px; vertical-align: top">
                <asp:Button runat="server" ID="BtnLoadNews" Text="نمایش" OnClick="BtnLoadNews_Click" CssClass="btn-danger" Width="80" /></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView Width="100%" ID="gvContents" AllowPaging="true" OnPageIndexChanging="gvContents_PageIndexChanging" PageSize="3" GridLines="None" runat="server" AutoGenerateColumns="False" CssClass="requests table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="LbluniquID2" runat="server" Text='<%# Eval("ID") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <asp:Label ID="LbluniquID" runat="server" Text='<%#  Container.DataItemIndex+1 %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="عنوان">
                            <ItemTemplate>
                                <%# Eval("Name") %>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="متن">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox2" TextMode="MultiLine" Rows="5" runat="server" Text='<%# Eval("Body") %>' Width="95%"></asp:TextBox>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="فعال">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnActive" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="ToggleActive" ImageUrl='<%# BoolToImage(Eval("IsRead")) %>' />
                            </ItemTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                         <asp:TemplateField HeaderText="ایمیل">
                            <ItemTemplate>
                                 <%# Eval("email") %>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="شماره">
                            <ItemTemplate>
                                 <%# Eval("phone") %>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="نوع">
                            <ItemTemplate>
                                 <%# SetKind(Eval("kind")) %>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="دریافت">
                            <ItemTemplate>
                                <asp:Label ID="LblCreateTime" runat="server" Text='<%#Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("DATETIME_INSERT").ToString()),true)  %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120" />
                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="مشاهده">
                            <ItemTemplate>
                                <asp:Label ID="LblDateTimeEdit" runat="server" Text='<%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("DATETIME_CHECK").ToString()),true) %>'>&gt;</asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120" />
                        </asp:TemplateField>      --%>




                        <asp:TemplateField HeaderText="فایل">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" target="_blank" title="برای ویرایش  فایل کلیک کنید"
                                     Visible='<%# CheckFilePath(Eval("FilePath")) %>' NavigateUrl='<%#Eval("FilePath") %>'>
                                    <img src="/cp/Theme/Icon/Image.png" />
                                </asp:HyperLink>                              
                            </ItemTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>

    </table>
</asp:Content>
