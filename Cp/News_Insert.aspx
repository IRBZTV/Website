<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="News_Insert.aspx.cs" Inherits="Bazaar.Cp.News_Insert" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>عنوان</td>
            <td>
                <asp:TextBox ID="TxtTitle" runat="server" MaxLength="57" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>

            <td>خلاصه</td>
            <td>
                <CKEditor:CKEditorControl ForcePasteAsPlainText="true" ID="CKEditorDescription" Toolbar="Basic" runat="server" Height="100" BasePath="~/CP/Utility/ckeditor" ContentsLangDirection="Rtl">

                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>

            <td>متن</td>
            <td>
                <CKEditor:CKEditorControl ID="CKEditorBody" ForcePasteAsPlainText="true" Toolbar="Basic" runat="server" Height="200" BasePath="~/CP/Utility/ckeditor" ContentsLangDirection="Rtl">

                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td>انتخاب نظر سنجی</td>
                        <td>
                            <asp:DropDownList ID="DdlPollSelector" runat="server" Font-Names="B Yekan">
                            </asp:DropDownList>
                        </td>
                        <td>وضعیت</td>
                        <td>
                            <asp:DropDownList ID="DdlStateSelector" runat="server" Font-Names="B Yekan">
                            </asp:DropDownList>
                        </td>
                        <td>موقعیت</td>
                        <td>
                            <asp:DropDownList ID="DdlPositionSelector" runat="server" Font-Names="B Yekan">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>دسته خبر</td>
                        <td>
                            <asp:DropDownList ID="DdlCategory" runat="server" Font-Names="B Yekan">
                            </asp:DropDownList>
                        </td>
                        <td colspan="4">
                            <asp:CheckBox ID="ChkShowComments" runat="server" Text="نمایش نظرات" Width="130px" Checked="True" />
                            <asp:CheckBox ID="ChkNewComment" runat="server" Text="ثبت نظر جدید" Width="100px" Checked="True" />
                            <asp:CheckBox ID="ChkShowPoll" runat="server" Text="نمایش نظر سنجی" Width="100px" />
                            <asp:CheckBox ID="ChkActive" runat="server" Text="نمایش روی سایت" Width="100px" CssClass="tooltip-inner btn-danger" />
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td>سال</td>
                        <td>ماه</td>
                        <td>روز</td>
                        <td>ساعت</td>
                        <td>دقیقه</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DdlYear" runat="server" Font-Names="B Yekan" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlMonth" runat="server" Font-Names="B Yekan" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlDay" runat="server" Font-Names="B Yekan" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlHour" runat="server" Font-Names="B Yekan" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlMinute" runat="server" Font-Names="B Yekan" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="BtnInsert" runat="server" Text="ذخیره" OnClick="BtnInsert_Click" CssClass="btn-danger" Font-Names="B Yekan" />
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>

        </tr>
    </table>
</asp:Content>
