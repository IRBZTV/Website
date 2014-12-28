<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bazaar.Login" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<form id="form1" runat="server">
    <!--[if gt IE 8]><!-->
    <html class="no-js">
    <!--<![endif]-->
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <title>شبکه بازار</title>
        <meta name="description" content="">
        <meta name="viewport" content="width=device-width">
        <link rel="stylesheet" href="Cp/Theme/css/bootstrap.min.css">
        <link rel="stylesheet" href="Cp/Theme/css/icons.min.css">
        <!--[if lte IE 7]><link rel="stylesheet" href="Cp/Theme/css/icons-ie7.min.css"><![endif]-->
        <link rel="stylesheet" href="Cp/Theme/css/main.css">
        <script src="Cp/Theme/js/vendor/modernizr-2.6.2-respond-1.1.0.min.js"></script>
    </head>
    <body>
        <div class="container">
            <div class="row">
                <asp:Login ID="Login1" runat="server" MembershipProvider="MyMembershipProvider" DestinationPageUrl="~/cp/DashBoard" RenderOuterTable="False" OnLoggingIn="Login1_LoggingIn">
                    <LayoutTemplate>
                        <div id="login" class="span4 offset4">
                            <section class="login_form">
                                <div class="login-header-right"></div>
                                <header>
                                    <h3 class="logo">شبکه بازار</h3>
                                </header>
                                <br />
                                <br />
                                <br />
                                <br />
                                <div class="control-group">
                                    <div class="controls">
                                        <div class="input-append">
                                            <span class="add-on"><i class="icon-user"></i></span>
                                            <asp:TextBox runat="server" class="span3" ID="username" name="username" type="text" value="" onblur="" onfocus="" placeholder="نام کاربری"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <div class="input-append">
                                            <span class="add-on"><i class="icon-key"></i></span>

                                            <asp:TextBox runat="server" TextMode="Password" class="span3" ID="password" name="password" type="password" value="" onblur="" onfocus="" placeholder="رمز عبور"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                               <%-- <div class="control-group" style="display:none">
                                    <div class="controls">
                                        <div class="input-append">
                                            <span class="add-on"><i class="icon-cogs"></i></span>
                                            <asp:TextBox ID="txtCaptcha"  CssClass="span3"  TextMode="SingleLine" ClientIDMode="Static" runat="server" placeholder="عبارت زیر"></asp:TextBox>
                                            <cc1:CaptchaControl ID="Captcha1" FontColor="Red" CssClass="span3" runat="server" Height="50px"
                                                Width="180px" CaptchaLength="5" BackColor="WhiteSmoke"
                                                EnableViewState="False" BorderWidth="2" BorderColor="Black" />
                                        </div>
                                    </div>
                                </div>--%>
                                <asp:Button ID="LoginButton" Width="295" runat="server" CommandName="Login" Text="ورود" ValidationGroup="Login1" CssClass="btn btn-danger pull-left" />
                                <div class="clearfix"></div>
                            </section>
                        </div>
                    </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
        <script src="Cp/Theme/js/vendor/jquery-1.9.1.min.js"></script>
        <script src="Cp/Theme/js/vendor/bootstrap.min.js"></script>
        <script src="Cp/Theme/js/main.js"></script>
    </body>
    </html>
</form>
