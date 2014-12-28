<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="Bazaar.Cp.Menus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:DropDownList Font-Names="B YEKAN"  CssClass="badge-warning" ID="DdlMenuKindSelector" runat="server" OnSelectedIndexChanged="DdlMenuKindSelector_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="منوی کنترل پنل" Value="1" >                      
                    </asp:ListItem>
                    <asp:ListItem Text="منوی عمومی" Value="2" Selected="True">                      
                    </asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="imgBtnSaveMenus" title="ذخیره ترتیب و عنوان منو ها" runat="server" ImageUrl="~/Cp/Theme/Icon/Save.png" OnClick="imgBtnSaveMenus_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="requests table table-striped table-bordered table-hover" DataKeyNames="ID" DataMember="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="شناسه">
                            <ItemTemplate>
                                <asp:Label ID="LblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="عنوان">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("TITLE") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ترتیب">
                            <ItemTemplate>
                                <asp:TextBox Width="50" ID="txtSort" runat="server" Text='<%# Eval("sort") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="50" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
