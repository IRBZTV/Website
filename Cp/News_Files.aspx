<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="News_Files.aspx.cs" Inherits="Bazaar.Cp.News_Files" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="requests table table-striped table-bordered table-hover">
        <tr>
            <td colspan="4" class="btn-danger">
                <asp:Label ID="LblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 300px;">مسیر تصویر:
                <asp:FileUpload ID="FileUpload1" runat="server" Width="190" />
            </td>
            <td style="width: 150px;">ترتیب:
            
                <asp:DropDownList ID="DdlImagePriority" runat="server" Width="90">
                </asp:DropDownList>
            </td>
            <td style="text-align: left;">
                <asp:Button ID="Button1" runat="server" Text="آپلود عکس" OnClick="Button1_Click" CssClass="btn-danger" />
            </td>
            <td class="btn-danger">فقط تصاویر با فرمت .jpg  و اندازه  عرض 610 پیکسل  و ارتفاع 343 پیکسل  قابل قبول است </td>
        </tr>
        <tr>
            <td colspan="4">لیست تصاویر موجود:
            </td>
        </tr>
        <tr>

            <td colspan="4">
                <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="تصویر">
                            <ItemTemplate>
                                <img src='<%#  Bazaar.Core.ThumbnailGenerator.Generate(Eval("Path").ToString(),140,0)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ترتیب">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Priority") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="عملیات">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Cp/Theme/Icon/up_green.png" CommandName="UpImagePriority" CommandArgument='<%# Eval("ID") %>' title="افرایش ترتیب" />
                                <br />
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Cp/Theme/Icon/down_green.png" CommandName="DownImagePriority" CommandArgument='<%# Eval("ID") %>' title="کاهش ترتیب" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Cp/Theme/Icon/Delete.png" CommandName="DeleteImage" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>

        </tr>
    </table>
</asp:Content>
