<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Bazaar.Cp.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="width: 60px; vertical-align: middle">از تاریخ:</td>
            <td style="width: 120px; vertical-align: top">
                <asp:TextBox runat="server" ID="txtStartDate" Width="120" /></td>
            <td style="width: 60px; vertical-align: middle">تا تاریخ:</td>
            <td style="width: 120px; vertical-align: top">
                <asp:TextBox runat="server" ID="txtEndDate" Width="120" /></td>
            <td style="width: 90px; vertical-align: top">
                <asp:Button runat="server" ID="BtnLoadNews" Text="نمایش" CssClass="btn-danger" OnClick="BtnLoadNews_Click" Width="80" /></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView Width="100%" ID="gvContents" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gvContents_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="شناسه" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="LbluniquID2" runat="server" Text='<%# Eval("ID") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <asp:Label ID="LbluniquID" runat="server" Text='<%#  Container.DataItemIndex+1 %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="عنوان">
                            <ItemTemplate>
                                <a target="_blank" title="برای ویرایش کلیک کنید" href="<%#Eval("ID","/cp/newsedit/{0}") %>"><%# Eval("Title") %></a>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="فعال">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnActive" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="ToggleActive" ImageUrl='<%# BoolToImage(Eval("Active")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تولید">
                            <ItemTemplate>
                                <asp:Label ID="LblCreateTime" runat="server" Text='<%#Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("DATETIME_CREATE").ToString()),true)  %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ویرایش">
                            <ItemTemplate>
                                <asp:Label ID="LblDateTimeEdit" runat="server" Text='<%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("DATETIME_MODIFIED").ToString()),true) %>'>&gt;</asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="دسته">
                            <ItemTemplate>
                                <asp:Label ID="LblCategory" runat="server" Text='<%# CategoryTitle(Eval("CATEGORY_ID")) %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="موقعیت">
                            <ItemTemplate>
                                <asp:Label ID="LblPosition" runat="server" Text='<%# PositionTitle(Eval("POSITION")) %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="وضعیت">
                            <ItemTemplate>
                                <asp:Label ID="LblState" runat="server" Text='<%# StateTitle(Eval("STATE")) %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--    <asp:TemplateField HeaderText="نظرسنجی">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnPoll" ImageUrl='<%# BoolToImage(Eval("SHOWPOLL")) %>'
                        CommandName="TogglePoll" CommandArgument='<%# Eval("ID") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>--%>


                        <asp:TemplateField HeaderText="لیست نظرات">
                            <ItemTemplate>
                                <a target="_blank" title='<%# UnActiveComments(Eval("Id")) %>' href="<%#Eval("ID","/cp/news/comments/{0}") %>">
                                    <%# UnActiveComments(Eval("Id")) %>
                                </a>
                            </ItemTemplate>
                            <ItemStyle Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نظرجدید">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnNewComment" ImageUrl='<%# BoolToImage(Eval("NEWCOMENT")) %>'
                                    CommandName="ToggleComment" CommandArgument='<%# Eval("ID") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="50" />
                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="کاربر">
                <ItemTemplate>
                    <asp:Label ID="LblAuthor" runat="server" Text='<%# GetUSer(Eval("AUTHOR")) %>'>></asp:Label>
                </ItemTemplate> <ItemStyle Width="80" />
            </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnDelete" OnClientClick="return confirm('آیا محتوای انتخاب شده حذف گردد؟');"
                                    CommandName="DeleteContent" CommandArgument='<%# Eval("ID") %>'
                                    ImageUrl="/Cp/Theme/Icon/delete.png" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="فایل">
                            <ItemTemplate>
                                <a target="_blank" title="برای ویرایش  فایل کلیک کنید" href="<%#Eval("ID","/cp/newsfiles/{0}") %>">
                                    <img src="/cp/Theme/Icon/Image.png" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>






</asp:Content>
