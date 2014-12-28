<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LivePlayer.ascx.cs" Inherits="Bazaar.Modules.Live.LivePlayer" %>
<div id="live" class="row">
    <div class="span6 player">
        <div id="liveplayer">
        </div>
    </div>
    <div class="span2">
        <div class="bitrates">
            <header>
                <h2>
                    <span class="header-title">کیفیت پخش</span>
                </h2>
            </header>
            <ul>

                <li class="active">
                    <a href="#" id="bitrate-128" data-quality="low"><span class="icon-signal"></span>نرخ بیت 192kb/s </a>
                </li>
                <li>
                    <a href="#" id="bitrate-512" data-quality="384"><span class="icon-signal"></span>نرخ بیت 384kb/s</a>
                </li>

                <li>
                    <a href="#" id="bitrate-500" data-quality="500"><span class="icon-signal"></span>نرخ بیت 500kb/s</a>
                </li>

                <li>
                    <a href="#" id="bitrate-600" data-quality="600"><span class="icon-signal"></span>نرخ بیت 600kb/s</a>
                </li>
            </ul>
        </div>
    </div>
</div>
