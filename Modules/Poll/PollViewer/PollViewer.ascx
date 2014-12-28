<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PollViewer.ascx.cs" Inherits="Bazaar.Modules.Poll.PollViewer.PollViewer" %>
 <asp:Literal ID="LtrModuleTitle" runat="server"></asp:Literal>
<div class="poll box">
    <section class="box-content">
        <form action="#" method="post" enctype="multipart/form-data">
            <fieldset>
                <p>
                    <asp:Label ID="LblTitle" runat="server" Text="Label"></asp:Label>
                </p>
                <div id="pollbody">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>                   
                </div>
            </fieldset>
        </form>
    </section>
</div>
