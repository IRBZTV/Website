<%@ Page Title="" Language="C#" MasterPageFile="~/Cp/ControlPanel.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Bazaar.Cp.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="/cp/theme/js/vendor/jquery-1.9.1.min.js"></script>

    <script src="Scripts/AjaxUpload/fileuploader.js" type="text/javascript"></script>
    <div id="video-uploader">
        <noscript>
            <p>Please enable JavaScript to use file uploader.</p>
        </noscript>
    </div>
    <div>
        <ul class="library">
        </ul>
    </div>
    <div id="hfvideo"></div>
    <script type="text/javascript">
        function createUploader() {
            var uploader = new qq.FileUploader({
                element: document.getElementById('video-uploader'),
                action: 'FileUpload.ashx',
                allowedExtensions: ['flv'],
                debug: true,
                onComplete: function (id, fileName, responseJSON) {
                    if (responseJSON.success) {
                       $(".library").append("فایل با موفقیت ارسال شد");
                          alert(responseJSON.fullname);
                         $("#hfvideo").text(responseJSON.fullname);

                    }
                }
            });
        }

        $(function () {

            createUploader();
        });
    </script>
</asp:Content>
