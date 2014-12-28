<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="Bazaar.Cp.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="width: 50px; vertical-align: middle">از تاریخ:</td>
            <td style="width: 90px; vertical-align: top">
                <asp:TextBox runat="server" ID="txtStartDate" Width="90" /></td>
            <td style="width: 50px; vertical-align: middle">تا تاریخ:</td>
            <td style="width: 90px; vertical-align: top">
                <asp:TextBox runat="server" ID="txtEndDate" Width="90" /></td>
            <td style="width: 90px; vertical-align: top">
                <asp:Button runat="server" ID="BtnLoadNews" Text="نمایش" CssClass="btn-danger" OnClick="BtnLoadNews_Click" Width="80" /></td>
            <td colspan="2">
            <asp:HyperLink runat="server" ID="PrintUrl" target="_blank">
                <img width="40" src="/cp/Theme/img/Print.png" /></asp:HyperLink></td>
        </tr>
        <tr>
            <td style="width: 120px; vertical-align: middle">
                <asp:DropDownList runat="server" ID="DdlCat" AutoPostBack="true" Font-Names="B YEKAN" CssClass="badge-warning" OnSelectedIndexChanged="DdlCat_SelectedIndexChanged" Width="100%"></asp:DropDownList>
            </td>
            <td style="width: 120px; vertical-align: top">
                <asp:DropDownList runat="server" ID="DdlList" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%"></asp:DropDownList></td>
            <td style="width: 80px; vertical-align: middle">
                <asp:DropDownList runat="server" ID="DdlClient" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%"></asp:DropDownList></td>
            <td style="width: 120px; vertical-align: top">
                <asp:DropDownList runat="server" ID="DdlKind" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%"></asp:DropDownList></td>
            <td style="width: 120px; vertical-align: top">
                <asp:DropDownList runat="server" ID="DdlUser" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%"></asp:DropDownList></td>

            <td style="width: 120px; vertical-align: top">
                <asp:DropDownList runat="server" ID="DdlShift" Font-Names="B YEKAN" CssClass="badge-warning" Width="100%">
                    <asp:ListItem Text="شیفت" Value="0" Selected="True" />
                    <asp:ListItem Text="شیفت 1" Value="1" />
                    <asp:ListItem Text="شیفت 2" Value="2" />
                    <asp:ListItem Text="شیفت 3" Value="3" />
                </asp:DropDownList></td>
            <td style="width: 120px; vertical-align: top">
                <asp:TextBox runat="server" ID="TxtBody" placeholder="جستجوی توضیحات گزارش"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:GridView Width="100%" ID="gvContents" OnPageIndexChanging="gvContents_PageIndexChanging" AllowPaging="true" PageSize="10" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gvContents_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <asp:Label ID="LbluniquID" runat="server" Text='<%#  Container.DataItemIndex+1 %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="گروه فعالیت">
                            <ItemTemplate>
                                <a target="_blank" style="font-size: 9pt;" title="برای ویرایش کلیک کنید" href="<%#Eval("ID","/cp/Service/Edit/{0}") %>"><%# GetCatTitle(Eval("Cat_Id")) %></a>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="فعالیت">
                            <ItemTemplate>
                                <a target="_blank" style="font-size: 9pt;" title="برای ویرایش کلیک کنید" href="<%#Eval("ID","/cp/Service/Edit/{0}") %>"><%# GetListTitle(Eval("List_Id")) %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="واحد">
                            <ItemTemplate>
                                <a target="_blank" style="font-size: 9pt;" title="برای ویرایش کلیک کنید" href="<%#Eval("ID","/cp/Service/Edit/{0}") %>"><%# GetClientTitle(Eval("Client_Id")) %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نوع">
                            <ItemTemplate>
                                <asp:Label Style="font-size: 9pt;" ID="LblCreateTime" runat="server" Text='<%# GetKindTitle(Eval("Kind_Id")) %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="سرویس دهنده">
                            <ItemTemplate>
                                <asp:Label Style="font-size: 9pt;" ID="LblDateTimeEdit" runat="server" Text='<%#GetUSer(Eval("User_Id"))%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاریخ">
                            <ItemTemplate>
                                <asp:Label Style="font-size: 9pt;" ID="LblCategory" runat="server" Text='<%# Bazaar.Core.Utility.GD2JD(DateTime.Parse(Eval("DATETIME").ToString()),true) %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="شیفت">
                            <ItemTemplate>
                                <asp:Label Style="font-size: 9pt;" ID="LblDateTimeEdit" runat="server" Text='<%#ShiftTitle(Eval("SHIFT"))%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="دقیقه">
                            <ItemTemplate>
                                <asp:Label Style="font-size: 9pt;" ID="LblDateTimeEdit" runat="server" Text='<%#Eval("Minute")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="توضیحات">
                            <ItemTemplate>
                                <a style="font-size: 9pt;" target="_blank" title='<%# Eval("text") %>' href="<%#Eval("ID","/cp/Service/Edit/{0}") %>"><%# CutText(Eval("text")) %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
