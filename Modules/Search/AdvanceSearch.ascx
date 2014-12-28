<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvanceSearch.ascx.cs" Inherits="Bazaar.Modules.Search.AdvanceSearch" ViewStateMode="Enabled" EnableViewState="true" %>
<asp:Literal ID="LtrModuleTitle" runat="server"></asp:Literal>
<div id="search-page" class="box">
    <div id="serch-form">
        <form runat="server">
            <fieldset>
                <div class="form-inline input-group">
                    <label for="date-from">عبارت</label>
                    <asp:TextBox runat="server" ID="TxtSearchKey" CssClass="input-xlarge" />
                    <asp:Button runat="server" ID="BtnSearch" OnClick="BtnSearch_Click" Text="جستجو" class="btn btn-info" />
                </div>
                <div class="form-inline input-group">
                    <label for="date-from">از تاریخ</label>
                    <asp:TextBox runat="server" ID="TxtDateStart" CssClass="input-small" />
                    <label for="date-from">تا تاریخ</label>
                    <asp:TextBox runat="server" ID="TxtDateEnd" CssClass="input-small" />
                </div>
                <div class="form-inline input-group">
                    <asp:CheckBoxList ID="ChkLst" runat="server" CssClass="checkbox-group" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    <asp:CheckBox runat="server" ID="ChkGallery" Checked="true" Text="گالری تصاویر" CssClass="checkbox-group"  />
                    <%-- <asp:CheckBox runat="server" ID="ChkConductor" Checked="true" Text="جدول پخش" />--%>
                    <asp:CheckBox runat="server" ID="ChkPrograms" Checked="true" Text="برنامه ها" CssClass="checkbox-group" />
                </div>
            </fieldset>
        </form>
    </div>
    <div id="results">
        <h2>
            <span class="header-title">نتایج جستجو</span>
        </h2>
        <div class="clearfix"></div>
        <header class="box-header">
            <h2>
                <span class="header-title">اخبار</span>
            </h2>
        </header>
        <section class="box-content">
            <asp:Literal runat="server" ID="LtrNews"></asp:Literal>
        </section>
        <div class="clearfix"></div>
        <header class="box-header">
            <h2>
                <span class="header-title">گالری</span>
            </h2>
        </header>
        <section class="box-content">
            <asp:Literal runat="server" ID="LtrGallery"></asp:Literal>
        </section>
        <div class="clearfix"></div>
         <header class="box-header">
            <h2>
                <span class="header-title">برنامه ها</span>
            </h2>
        </header>
        <section class="box-content">
             <asp:Literal runat="server" ID="LtrSessions"></asp:Literal>           
        </section>
        <div class="clearfix"></div>
       <%-- <header class="box-header">
            <h2>
                <span class="header-title">برنامه ها</span>
            </h2>
        </header>
        <section class="box-content">
             <asp:Literal runat="server" ID="LtrProg"></asp:Literal>           
        </section>
        <div class="clearfix"></div>--%>
        <%--  <header class="box-header">
            <h2>
                <span class="header-title">کنداکتور</span>
            </h2>
        </header>
        <section class="box-content">
            <ul class="list schedules-list">
                <li>
                    <div class="image-holder">
                        <a href="#" title="">
                            <img src="" alt="" />
                        </a>
                    </div>
                    <h3><a href="#" title="">صنعت طلاسازی</a><span class="date">جمعه 14 تیر 1392 21:28</span></h3>
                </li>
                <li>
                    <div class="image-holder">
                        <a href="#" title="">
                            <img src="" alt="" />
                        </a>
                    </div>
                    <h3><a href="#" title="">صنعت طلاسازی</a><span class="date">جمعه 14 تیر 1392 21:28</span></h3>
                </li>
            </ul>
        </section>--%>
    </div>
</div>
