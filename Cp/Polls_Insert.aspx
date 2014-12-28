<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Polls_Insert.aspx.cs" Inherits="Bazaar.Cp.Polls_Insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:100%;">
        <tr><td>عنوان</td>
            <td>
                <asp:TextBox ID="TxtTitle" runat="server" Width="100%"></asp:TextBox>
            </td>
            
        </tr>
        <tr>  <td>&nbsp;</td>
            <td>
                <asp:Button CssClass="btn-danger" ID="btnSave" runat="server" Text="ذخیره" OnClick="btnSave_Click" />
            </td>
          
        </tr>
        <tr>  <td>گزینه جدید</td>
            <td>
                <asp:TextBox ID="txtOptionTitle" runat="server" Width="100%"></asp:TextBox>
            </td>
          
        </tr>
        <tr> <td>ترتیب</td>
            <td>
                <asp:DropDownList ID="DdlOptionPriority" runat="server">
                </asp:DropDownList>
            </td>
           
        </tr>
         <tr><td>&nbsp;</td>
            <td>
                <asp:Button CssClass="btn-danger" ID="btnSaveOption" runat="server" Text="افزودن گزینه" OnClick="btnSaveOption_Click" />
             </td>
            
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td>گزینه های موجود</td>
        </tr>
         <tr>
               <td>&nbsp;</td>
            <td>
                <asp:GridView ID="gvOptions" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="gvOptions_RowCommand" CssClass="requests table table-striped table-bordered table-hover">
                    <Columns>
                         <asp:TemplateField HeaderText="شناسه">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="OptionLblTitle" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="عنوان گزینه">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="OptionTxtTitle" Text='<%# Eval("Title") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="ذخیره">
                            <ItemTemplate>
                                 <asp:ImageButton ID="imgBtnSave"
                       CommandName="SavePollOption" CommandArgument='<%#  Container.DataItemIndex %>'
                        ImageUrl="~/Cp/Theme/Icon/Save.png" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ترتیب">
                            <ItemTemplate>
                                 <asp:Label runat="server" ID="OptionLblPriority" Text='<%# Eval("Priority") %>'></asp:Label>
                               </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="ترتیب">
                            <ItemTemplate>
                                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Cp/Theme/Icon/up_green.png" CommandName="UpPriority" CommandArgument='<%# Eval("ID") %>' title="افرایش ترتیب" />
                                <br />
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Cp/Theme/Icon/down_green.png" CommandName="DownPriority" CommandArgument='<%# Eval("ID") %>'  title="کاهش ترتیب"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                 <asp:ImageButton ID="imgBtnDelete" OnClientClick="return confirm('آیا گزینه انتخاب شده حذف گردد؟');"
                       CommandName="DeletePollOption" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="~/Cp/Theme/Icon/delete.png" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="تعداد رای">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="LblCount" Text='<%# Eval("Count") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
             </td>
          
        </tr>
    </table>

</asp:Content>
