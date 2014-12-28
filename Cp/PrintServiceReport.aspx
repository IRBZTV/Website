<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintServiceReport.aspx.cs" Inherits="Bazaar.Cp.PrintServiceReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش عملکرد روزانه واحد فنی و انفورماتیک</title>
    <meta charset="utf-8" />
    <style>
        html, body, div, span, applet, object, iframe, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td, article, aside, canvas, details, embed, figure, figcaption, footer, header, hgroup, menu, nav, output, ruby, section, summary, time, mark, audio, video {
            margin: 0;
            padding: 0;
            border: 0;
            font-size: 100%;
            font: inherit;
            vertical-align: baseline;
        }

        article, aside, details, figcaption, figure,
        footer, header, hgroup, menu, nav, section {
            display: block;
        }

        body {
            line-height: 1;
        }

        ol, ul {
            list-style: none;
        }

        blockquote, q {
            quotes: none;
        }

            blockquote:before, blockquote:after, q:before, q:after {
                content: '';
                content: none;
            }

        .table-wrapper {
            border: 1px solid #000;
            padding: 1px;
            width: 650px;
            margin: 0 auto;
        }

        table {
            border-collapse: collapse;
            border-spacing: 0;
            border: 1px solid #000;
            width: 100%;
        }
        /*thead, tbody { display: block;border: 1px solid #000; margin: 1px; }*/
        tr {
            border-bottom: 1px solid #000;
        }

        td, th {
            padding: 1px 0;
            text-align: center;
            border-left: 1px solid #000;
            min-width: 1%;
            vertical-align: middle;
        }

        th {
            font-weight: bold;
        }

        td {
        }

        .container {
            direction: rtl;
            text-align: center;
            font-family: 'BNazanin', 'B Nazanin', Arial;
            font-size: 8px;
            line-height: 16px;
        }

        h1 {
            font-size: 16px;
            font-weight: bold;
            text-align: center;
            margin: 10px 0;
        }

        h2 {
            font-size: 12px;
            font-weight: bold;
        }

        .title {
            text-align: right;
            text-indent: 10px;
            padding: 2px 0;
        }

        .rotate {
            height: 80px;
        }

            .rotate div {
                width: 20px;
                height: 80px;
                margin: 0 auto;
                overflow: hidden;
            }

                .rotate div span {
                    width: 85px;
                    height: 80px;
                    display: block;
                    -webkit-transform: rotate(-90deg);
                    -moz-transform: rotate(-90deg);
                    -ms-transform: rotate(-90deg);
                    -o-transform: rotate(-90deg);
                    transform: rotate(-90deg);
                    -webkit-transform-origin: 50% 50%;
                    -moz-transform-origin: 50% 50%;
                    -ms-transform-origin: 50% 50%;
                    -o-transform-origin: 50% 50%;
                    transform-origin: 50% 50%;
                    filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
                    writing-mode: rl-bt;
                    -webkit-writing-mode: horizontal-bt;
                }

        .right {
            text-align: right;
            text-indent: 0.5%;
        }

        @-moz-document url-prefix() {
            .right;

        {
            text-indent: 1%;
        }

        .rotate div {
            position: relative;
        }

            .rotate div span {
                position: absolute;
                bottom: 0;
                left: 0;
            }

        }

        .p2 {
            width: 2%;
        }

        .p3h {
            width: 3.125%;
        }

        .p23 {
            width: 23%;
        }

        .p25 {
            width: 25%;
        }
        .bl {
            border-left: 2px solid #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
			<h1>گزارش عملکرد  واحد فنی و انفورماتیک</h1>
			<div class="table-wrapper">
				<asp:Literal runat="server" ID="LtrTbl"></asp:Literal>
			</div>  
           <h2 style="margin-top: 20px;"> 
            مدیر فنی و انفورماتیک	
       </h2>
    </form>
    <%--  <script type="text/javascript">print();</script>--%>
</body>
</html>
