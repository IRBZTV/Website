<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="News_Comments.aspx.cs" Inherits="Bazaar.Cp.News_Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:ImageButton ID="ImgBtnRefresh" runat="server" ImageUrl="~/Cp/Theme/Icon/reload.png" Width="48" title="تازه سازی لسیت نظرات" OnClick="ImgBtnRefresh_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView Width="100%" ID="gvComments" DataKeyNames="ID"  GridLines="None" runat="server" AutoGenerateColumns="False" CssClass="requests table table-striped table-bordered table-hover" OnRowCommand="gvComments_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <asp:Label ID="LbluniquID" runat="server" Text='<%#  Container.DataItemIndex+1 %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="فعال">
                            <ItemTemplate>
                                <asp:ImageButton title="فعال یا غیر فعال" ID="ImgBtnActive" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Active" ImageUrl='<%# BoolToImage(Eval("Active")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="متن">
                            <ItemTemplate>
                                <asp:TextBox  runat="server" ID="TxtComment" TextMode="MultiLine" Height="100" Width="95%" Text=' <%# Eval("text") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="300" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نام">
                            <ItemTemplate>
                                <%# Eval("Name") %>
                            </ItemTemplate>
                            <ItemStyle Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ایمیل">
                            <ItemTemplate>
                                <%# Eval("Email") %>
                            </ItemTemplate>
                            <ItemStyle Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاریخ">
                            <ItemTemplate>
                                <%# Bazaar.Core.Utility.GD2StringDateTime(DateTime.Parse(Eval("DATETIME").ToString())) %>
                            </ItemTemplate>
                            <ItemStyle Width="190" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ذخیره">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnSave" OnClientClick="return confirm('آیا محتوای انتخاب شده ذخیره گردد؟');"
                                    CommandName="SaveContent" CommandArgument='<%# Container.DataItemIndex  %>'
                                    ImageUrl="~/Cp/Theme/Icon/Save.png" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton title="حذف نظر" ID="imgBtnDelete" OnClientClick="return confirm('آیا نظر انتخاب شده حذف گردد؟');"
                                    CommandName="DeleteCom"  CommandArgument='<%# Eval("ID") %>'
                                    ImageUrl="/Cp/Theme/Icon/delete.png" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
