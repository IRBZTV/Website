<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newssend.aspx.cs" Inherits="Bazaar.Pages.newssend" %>

<%@ Register Src="../Modules/Contents/Mail/Mailer.ascx" TagName="Mailer" TagPrefix="uc1" %>
<%@ OutputCache Duration="60" VaryByParam="*" Location="Any" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <!--[if lte IE 10]>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"><![endif]-->
    <title>شبکه تلویزیونی بازار</title>
    <meta name="keywords" content="خبر, اخبار, پایگاه اطلاع رسانی, عکس, فیلم, آخرین, اخبار , اقتصادی ، بازار ، شبکه ، شبکه بازار ، صدا وسیما " />
    <meta name="description" content=" وب سایت رسمی شبکه تلویزیونی  بازار ، جامعترین پایگاه اطلاع رسانی اقتصادی شامل اخبار مکتوب، فیلم، عکس و چند رسانه ای" />
    <meta name="viewport" content="width=device-width" />
    <link rel="icon" type="image/png" href="App_Themes/Theme1/img/logosmall.png" />
    <link rel="stylesheet" href="/App_Themes/Theme1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/App_Themes/Theme1/css/main.css" />
    <link rel="stylesheet" href="/App_Themes/Theme1/css/bazaar-icons.css" />

    <!--[if IE 7]>
		<link rel="stylesheet" href="/App_Themes/Theme1/css/bazaar-icons-ie7.css"><![endif]-->
    <script src="/App_Themes/Theme1/js/vendor/modernizr-2.6.2-respond-1.1.0.min.js"></script>
</head>
<body style="width: 300px;">
    <uc1:Mailer ID="Mailer1" runat="server" />
    <script src="/App_Themes/Theme1/js/vendor/jquery-1.9.0.min.js"></script>
    <script src="/App_Themes/Theme1/js/vendor/jquery.carouFredSel-6.2.0.min.js"></script>
    <script src="/App_Themes/Theme1/js/vendor/bootstrap.min.js"></script>
    <script src="/App_Themes/Theme1/js/main.js"></script>
    <script src="/callback/CallBack.js"></script>
    <script type="text/javascript">
        var pkBaseURL = (("https:" == document.location.protocol) ? "https://77.36.157.12:8080/" : "http://77.36.157.12:8080/");
        document.write(unescape("%3Cscript src='" + pkBaseURL + "piwik.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        try {
            var piwikTracker = Piwik.getTracker(pkBaseURL + "piwik.php", 1);
            piwikTracker.trackPageView();
            piwikTracker.enableLinkTracking();
        } catch (err) { }
    </script>
    <noscript>
        <p>
            <img src="http://77.36.157.12:8080/piwik.php?idsite=1" style="border: 0" alt="" />
        </p>
    </noscript>

</body>

</html>
