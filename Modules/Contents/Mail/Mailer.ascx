<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mailer.ascx.cs" Inherits="Bazaar.Modules.Contents.Mail.Mailer" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<form id="Form1" runat="server">
    <asp:Panel runat="server" ID="PnlMain">
        <section id="mainbody" style="width: 300px;">
            <div class="container" style="width: 300px;">
                <div class="row" style="width: 300px;">
                    <section id="main" style="width: 300px;">
                        <div id="item" style="width: 300px;">
                            <div class="item-comment-form" style="padding-left: 20px;">

                                <fieldset>
                                    <div class="pull-left">
                                        <div class="control-group">
                                            <label for="name">
                                                نام شما</label>
                                            <asp:TextBox ID="name" runat="server" CssClass="input-xlarge" placeholder="نام"></asp:TextBox>
                                        </div>
                                        <div class="control-group">
                                            <label for="email">
                                                پست الکترونیک شما:</label>
                                            <asp:TextBox ID="TxtSender" runat="server" CssClass="input-xlarge" placeholder="Email" TextMode="Email"></asp:TextBox>
                                        </div>
                                        <div class="control-group">
                                            <label for="email">
                                                پست الکترونیک گیرنده:</label>
                                            <asp:TextBox ID="TxtReceiver" runat="server" CssClass="input-xlarge" placeholder="Email" TextMode="Email"></asp:TextBox>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="control-group">
                                            <cc1:CaptchaControl ID="Captcha1" runat="server" BackColor="White" CaptchaLength="3" EnableViewState="False" Height="50px" Width="180px" />
                                            <asp:TextBox ID="txtCaptcha" runat="server" ClientIDMode="Static" CssClass="input-xlarge" placeholder="عبارت داخل کادر" Rows="1" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <asp:Button ID="commentsubmit2" runat="server" CssClass="btn pull-left btn-danger" OnClick="commentsubmit_Click" Text="ارسال ایمیل" />
                                    </div>

                                </fieldset>

                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </section>
    </asp:Panel>
    <asp:Panel runat="server" ID="PnlSent" Visible="false">
        <section id="Section1" style="width: 300px;">
            <div class="container" style="width: 300px;">
                <div class="row" style="width: 300px;">
                    <div class="btn pull-right btn-danger ">پست الکترونیک با موفقیت ارسال شد</div>
                    <button class="btn pull-right btn-danger" onclick="window.close();" >بستن پنجره</button>
                </div>
            </div>
        </section>
    </asp:Panel>
</form>
