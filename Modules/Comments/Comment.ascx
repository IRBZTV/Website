<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comment.ascx.cs" Inherits="Bazaar.Modules.Comments.Comment" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Panel ID="PnlShowComment" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Panel>
<asp:Panel ID="PnlNewComent" runat="server">
    <div id="item">
        <div class="item-comment-form">
            <header>
                <h2>
                    <span class="header-title">ارسال نظر</span>
                </h2>
            </header>
            <form id="commentform" runat="server">
                <fieldset>
                    <div class="pull-left comment-form-col1">
                        <div class="control-group">
                            <label for="name">نام</label>
                            <asp:TextBox ID="name" CssClass="input-xlarge" placeholder="نام" ClientIDMode="Static" runat="server"></asp:TextBox>
                        </div>
                        <div class="control-group">
                            <label for="email">پست الکترونیک</label>
                            <asp:TextBox ID="email" CssClass="input-xlarge" placeholder="Email" ClientIDMode="Static" runat="server"></asp:TextBox>
                        </div>
                        <div class="clearfix"></div>
                        <div class="control-group">
                            <cc1:CaptchaControl ID="Captcha1" runat="server" Height="50px"
                                Width="180px" CaptchaLength="3" BackColor="White"
                                EnableViewState="False" />
                            <asp:TextBox ID="txtCaptcha" CssClass="input-xlarge" Rows="1" TextMode="MultiLine" ClientIDMode="Static" runat="server" placeholder="عبارت داخل کادر"></asp:TextBox>

                        </div>
                        <asp:Button ID="commentsubmit" runat="server" Text="ارسال نظر" ClientIDMode="Static" CssClass="btn pull-left" OnClick="commentsubmit_Click" />
                    </div>
                    <div class="pull-right comment-form-col2">
                        <div class="control-group">
                            <label for="comment">نظر</label>
                            <asp:TextBox ID="comment" CssClass="input-xlarge" Rows="15" TextMode="MultiLine" ClientIDMode="Static" runat="server" placeholder="متن نظر"></asp:TextBox>
                        </div>


                    </div>


                </fieldset>
            </form>
        </div>
    </div>
</asp:Panel>

