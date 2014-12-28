<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConInserter.ascx.cs" Inherits="Bazaar.Modules.Contact.Public.ConInserter" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Literal ID="LtrModuleTitle" runat="server"></asp:Literal>
<asp:Panel ID="PnlContactInsert" runat="server" Visible="true">
    <div id="item">
        <div class="item-comment-form">
            <form id="commentform" runat="server">
                <fieldset>
                    <div class="pull-right comment-form-col2">
                        <div class="control-group">
                            <label for="name">نام</label>
                            <asp:TextBox ID="name" CssClass="input-xlarge" placeholder="نام" ClientIDMode="Static" runat="server"></asp:TextBox>
                        </div>
                        <div class="control-group">
                            <label for="email">پست الکترونیک</label>
                            <asp:TextBox ID="email" CssClass="input-xlarge" placeholder="Email" ClientIDMode="Static" runat="server"></asp:TextBox>
                        </div>
                        <div class="control-group">
                            <label for="name">شماره تماس</label>
                            <asp:TextBox ID="phone" CssClass="input-xlarge" placeholder="شماره تماس" ClientIDMode="Static" runat="server"></asp:TextBox>
                        </div>

                        <div class="control-group">
                            <label for="name">موضوع</label>
                            <asp:DropDownList runat="server" ID="kind" CssClass="dropdown" Width="100%">
                                <asp:ListItem Text="انتقاد" Value="1">  </asp:ListItem>
                                <asp:ListItem Text="پیشنهاد" Value="2" Selected="True">  </asp:ListItem>
                                <asp:ListItem Text="درخواست" Value="3">  </asp:ListItem>
                                <asp:ListItem Text="متفرقه" Value="4">  </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                         <div class="control-group">
                            <label for="name">فایل</label>
                             <asp:FileUpload ID="FileUpload1" runat="server" title="" Width="240" />
                        </div>
                        <div class="control-group">
                            <cc1:CaptchaControl ID="Captcha1" runat="server"
                                Width="100px" CaptchaLength="3" BackColor="White" FontColor="Red" CaptchaMaxTimeout="240" CaptchaMinTimeout="5"
                                EnableViewState="False" />
                            <asp:TextBox ID="txtCaptcha" CssClass="input-small" ClientIDMode="Static" runat="server" placeholder="عبارت داخل کادر"></asp:TextBox>
                            <asp:Button ID="commentsubmit" runat="server" Text="ارسال پیام" ClientIDMode="Static" OnClick="commentsubmit_Click" CssClass="btn-success btn pull-left" />
                        </div>
                    </div>
                    <div class="pull-left comment-form-col1">
                        <div class="control-group">
                            <label for="comment">پیام</label>
                            <asp:TextBox ID="comment" CssClass="input-xlarge" Height="350" TextMode="MultiLine" ClientIDMode="Static" runat="server" placeholder="متن پیام"></asp:TextBox>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PnlContactResult" runat="server" Visible="false">
    <div class="btn-success" style="width: 99%; margin: 5px 5px 5px 5px; padding: 5px 5px 5px 5px;">پیام شما با موفقیت دریافت شد</div>
</asp:Panel>
