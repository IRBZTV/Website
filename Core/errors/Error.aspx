<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Bazaar.Core.errors.Error" EnableViewState="false" ViewStateMode="Disabled" %>

<html>
<head>
    <title>شبکه تلویزیونی بازار</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <link rel="stylesheet" type="text/css" media="all" href="/Core/Errors/style.css" />
    <link rel="stylesheet" type="text/css" media="all" href="/Core/Errors/backgrounds.css" />
    <link rel="stylesheet" type="text/css" media="all" href="/Core/Errors/themes/blue/css/style.css" />
    <link rel="stylesheet" type="text/css" media="all" href="/Core/Errors/themes/green/css/style.css" />
    <link rel="stylesheet" type="text/css" media="all" href="/Core/Errors/themes/gray/css/style.css" />
</head>
<body>
    <div class="wrapper">
        <div class="mainWrapper">
            <div class="leftHolder">
                <a href="/" title="شبکه بازار" class="logo">شبکه بازار</a>
            </div>
            <div class="rightHolder">
                <div class="message">
                    <p>با عرض پوزش  انجام درخواست شما با مشکل مواجه شده است شما را به صفحه اول وب سایت هدایت خواهیم کرد </p>

                </div>
                <div class="robotik">
                    <img src="/Core/Errors/images/robotik.png" id="robot">
                </div>
            </div>
        </div>
    </div>
    <script type="text/JavaScript">
        setTimeout("location.href = '/';", 2000);
    </script>
</body>
</html>
