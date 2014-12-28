<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="Programs_Sessions_Insert.aspx.cs" Inherits="Bazaar.Cp.Programs_Sessions_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/cp/theme/js/vendor/jquery-1.9.1.min.js"></script>

    <script src="/cp/Scripts/AjaxUpload/fileuploader.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%;">
        <tr>
            <td style="width: 100px;">موضوع برنامه</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>شماره قسمت</td>
            <td>
                <asp:TextBox ID="txtNumber" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>تاریخ پخش:</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ساعت پخش:</td>
            <td>
                <asp:TextBox ID="txtTime" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>متن</td>
            <td>
                <asp:TextBox ID="txtBody" runat="server" Height="100px" TextMode="MultiLine" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>عکس</td>
            <td>
                 <asp:FileUpload ID="FileUpload1" runat="server" Width="190" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
              <td class="btn-danger">فقط تصاویر با فرمت .jpg  و اندازه  عرض 610 پیکسل  و ارتفاع 343 پیکسل  قابل قبول است </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Image ID="Image1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>ویدیو</td>
            <td>
                 <asp:HiddenField runat="server" ID="hfvideo" ClientIDMode="Static" Value="" />
             <%--   <div id="hfvideo"></div>--%>
                <div id="video-uploader">
                    <noscript>
                        <p>Please enable JavaScript to use file uploader.</p>
                    </noscript>
                </div>
                <div>
                    <ul class="library">
                    </ul>
                </div>
                <script type="text/javascript">
                    function createUploader() {
                        var uploader = new qq.FileUploader({
                            element: document.getElementById('video-uploader'),
                            action: '/cp/FileUpload.ashx',
                            allowedExtensions: ['flv'],
                            debug: true,
                            onComplete: function (id, fileName, responseJSON) {
                                if (responseJSON.success) {
                                     $(".library").text("فایل با موفقیت ارسال شد");
                                   // alert(responseJSON.success);
                                     $("#hfvideo").val(responseJSON.fullname);

                                }

                            }
                        });
                    }

                    $(function () {

                        createUploader();
                    });
                </script>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>

                <asp:Literal runat="server" ID="LtrVideoPlayer"></asp:Literal>

            </td>

        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnSave" runat="server" CssClass="btn-danger" Text="    ذخیره   " OnClick="BtnSave_Click" />
            </td>
        </tr>
    </table>



</asp:Content>
