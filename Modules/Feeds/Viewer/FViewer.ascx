<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FViewer.ascx.cs" Inherits="Bazaar.Modules.Feeds.Viewer.FViewer" %>
<asp:Literal ID="LtrModuleTitle" runat="server"></asp:Literal>
<div id="rss">
    <table class="rss-table table table-hover">
        <tbody>
          <asp:Literal runat="server" ID="LtrRss"></asp:Literal>    
        </tbody>
    </table>
</div>
