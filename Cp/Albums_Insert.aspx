<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Albums_Insert.aspx.cs" Inherits="Bazaar.Cp.Albums_Insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 70px">عنوان</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>توضیحات</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>عکاس</td>
            <td>
                <asp:TextBox ID="txtPhotographer" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                  <asp:Button ID="BtnSave"  runat="server" Text="ذخیره" CssClass="btn-danger" OnClick="BtnSave_Click" />
            </td>
        </tr>
           <tr>
            <td colspan="2" class="btn-danger">
                <asp:Label ID="LblError" runat="server" ></asp:Label>
            </td>          
        </tr>
          <tr>            
            <td colspan="2" class="btn-danger">فقط تصاویر با فرمت .jpg  و اندازه  عرض 610 پیکسل  و ارتفاع 343 پیکسل  قابل قبول است </td>
        </tr>       
         <tr>
             <td>مسیر تصویر:</td>
            <td ">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="190" />
            ترتیب:
                <asp:DropDownList ID="DdlImagePriority" runat="server" Width="90">
                </asp:DropDownList>
                <asp:Button ID="Button1"  runat="server" Text="آپلود عکس" CssClass="btn-danger" OnClick="Button1_Click" />
            </td>
                
        </tr>
        <tr>
            <td colspan="2">
                 <table style="width: 100%;">
                    <tr>
                        <td>سال</td>
                        <td>ماه</td>
                        <td>روز</td>
                        <td>ساعت</td>
                        <td>دقیقه</td>
                        <td>نوع</td>
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
                            <asp:DropDownList ID="DdlKind" runat="server" Font-Names="B Yekan" Width="100px">
                                <asp:ListItem Text="بازار" Value="1">بازار </asp:ListItem>
                                  <asp:ListItem Text="برنامه ها" Value="2">برنامه ها </asp:ListItem>
                                  <asp:ListItem Text="نشست ها" Value="3">نشست ها </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="BtnInsert" runat="server" Text="ذخیره" OnClick="BtnSave_Click" CssClass="btn-danger" Font-Names="B Yekan" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                لیست تصاویر موجود:
            </td>
        </tr>
        <tr>
            <td colspan="2">
                   <asp:GridView ID="GridView1" Width="300px" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
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
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Cp/Theme/Icon/up_green.png" CommandName="DownImagePriority" CommandArgument='<%# Eval("ID") %>' title="افرایش ترتیب" />
                                <br />
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Cp/Theme/Icon/down_green.png" CommandName="UpImagePriority" CommandArgument='<%# Eval("ID") %>' title="کاهش ترتیب" />
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
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
