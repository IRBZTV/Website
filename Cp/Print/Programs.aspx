<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="Bazaar.Cp.Print.Programs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="/cp/theme/css/main.css" />
    <title>لیست برنامه های شبکه در وب سایت</title>
</head>
<body style="margin-top:0;padding-top:0;direction:rtl">
    <form id="form1" runat="server" style="margin-top:0;padding-top:0;">
       لطفا کد مورد نظر را در قسمت کلاکت وارد نمایید
       <%-- <asp:GridView Width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="requests table table-striped table-bordered table-hover">
            <Columns>
                <asp:TemplateField HeaderText="ردیف">
                    <ItemTemplate>
                      
                    </ItemTemplate>
                    <ItemStyle Width="60" />
                </asp:TemplateField>             

                <asp:TemplateField HeaderText="عنوان">
                    <ItemTemplate>
                     
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="کد برنامه">
                    <ItemTemplate>
                      
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>--%>
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" ShowFooter="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="0" CellSpacing="5" ShowHeader="False" GridLines="None" Width="90%">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <ItemStyle ForeColor="#000066" />
            <ItemTemplate>
                <table style="padding: 0px; margin: 0px; border-color: black; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: 0;width:100%" >
                    <tr>                       
                        <td style="border-left-color:black;border-left-width:1px;border-left-style:solid; margin:0;padding:0;float:right; width:50%;padding-right:5px;" >   <%#(Eval("Title")) %></td>
                        <td style="margin:0;padding:0;float:left; padding-left:5px;" >  <%# Eval("ID")%></td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    <script>window.print();</script>
        

    </form>
    </body>
</html>
