$(function() {
	
    /** Tooltip **/
    $(".hastip").tooltip();
	
    /** RSS Table AutoSelect **/
    $(".rss-table .link input").each(function() {
        $(this).click(function(e) {
            $(this).select();
        });
    });
	
    /** Fixed Header **/
    $(window).scroll(function () {
        if ($(window).scrollTop() > 95) {
            $("header").addClass('fixed');
            $("#mainbody").css({ 'margin-top': '60px' });
        } else {
            $("header").removeClass('fixed');
            $("#mainbody").css({ 'margin-top': '0'});
        }
    });

    /** Item Video **/
    if ($(".item-video").length) {
        if (typeof playerData != 'undefined') {
            jwplayer('item-player').setup({
                file: playerData.file,
                image: playerData.image,
                height: '300',
                width: '420',
                stretching: 'fill',
                smoothing: 'false',
                modes: [
					{ 'type': 'html5' },
					{ 'type': 'flash', src: '/App_Themes/Theme1/mediaplayer/player.swf' },
					{ 'type': 'download' }
                ],
                autostart: playerData.autostart,
                backcolor: '#000000',
                controlbar: {
                    position: 'over',
                    idlehide: true
                },
                skin: '/App_Themes/Theme1/mediaplayer/skins/bekle/bekle.zip',
                allowscriptaccess: 'always'
            });
        }
        $(".playlist").delegate('a', 'click', function(e) {
            var $item = $(this);
            var video = $item.attr('data-video');
            var image = $item.attr('data-image');
            if (video && typeof video != 'undefined') {
                jwplayer().load({
                    file: video,
                    image: (image && typeof image != 'undefined') ? image : ""
                });
                if (typeof playerData != 'undefined') {
                    if (playerData.autostartOnPlaylistItemClick == true) {
                        jwplayer().play();
                    }
                }
                $("html, body").animate({ scrollTop: $(".item-video").offset().top }, "slow");
            }
            e.preventDefault();
        });
    }
	
    /** Stocks **/
    var titlesWidth = parseInt($('.stock-title').width());
    var carouselWidth = 910 - titlesWidth;
    if ($(".stocks").length) {
        $(".stocks").carouFredSel({
            direction		: 'right',
            width			: carouselWidth,
            padding			: [0, 10],
            prev			: "#stocks-prev",
            next			: "#stocks-next",
            auto	: {
                duration		: 30000,
                easing			: "linear",
                timeoutDuration	: 0,
                pauseOnHover    : "immediate"
            }
        });
    }

    /** Top News **/
    if ($('.slideshow').length) {
        $.each($('.slideshow'), function() {
            $slideshow = $(this);
            $pagination = ($slideshow.find('.carousel-pagination').length) ? $slideshow.find('.carousel-pagination') : false;
            $slideshow.find('ul.thumbs').carouFredSel({
                circular: true,
                infinite: true,
                direction: "left",
                auto 	: false,
                items	: 4,
                pagination	: $pagination
            });
			
            $slideshow.find('li.thumb:first').addClass('active');
            $slideshow.find('li.thumb').mouseenter(function() {
                $(this).parent().find('li.thumb').each(function() { 
                    $(this).removeClass('active'); 
                });
                $(this).addClass('active');
                var imgSource = $(this).find('img:first').attr('data-source');
                var title = $(this).find('img:first').attr('alt');
                var link = $(this).find('a:first').attr('href');
                $(this).parents('.slideshow').find('.figure').find('img').attr('src', imgSource).attr('alt', title);
                $(this).parents('.slideshow').find('.title h2 a').attr('href', link).text(title);
            });
        });
    }

    /** Poll **/
    if ($('.progress').length) {
        $('.progress').find('.bar').each(function() {
            var percent = $(this).find('span:first').text();
            $(this).after('<span class="overlay">' + percent + '</span>');
        });
    }
	
    /** Item Image Gallery Carousel **/
    if ($('.item-gallery .carousel').length) {
        $('.item-gallery .image-holder').mouseenter(function() {
            $(this).find('.figure-controls').fadeIn(300);
        }).mouseleave(function() {
            $(this).find('.figure-controls').fadeOut(300);
        });
        $('.item-gallery .carousel ul').carouFredSel({
            circular: false,
            infinite: false,
            auto 	: false,
            items	: 4,
            prev: $('#left'),
            next: $('#right'),
            scroll: {
                //items : 1
            }
        });
        var firstItemSource = $('.item-gallery .carousel ul li:first a').attr('data-source');
        var lastItemSource = $('.item-gallery .carousel ul li:last a').attr('data-source');
        $(".figure-controls #fig-next").click(function() {
            var position = $('.item-gallery .image-holder img').attr('src');
            if (position != lastItemSource) {
                $('.item-gallery .carousel ul').trigger("next", 1);
                var currentActive = $('.item-gallery .carousel ul li.active');
                currentActive.next().addClass('current');
                $('.item-gallery .carousel ul li').removeClass('active');
                $('.item-gallery .carousel ul li.current').addClass('active');
                $('.item-gallery .carousel ul li').removeClass('current');
                var largeImageSource = $('.item-gallery .carousel ul li.active').find('a:first').attr('data-source');
                var largeImageCaption = $('.item-gallery .carousel ul li.active').find('a:first').attr('title');
                $('h3.gallery-caption').text(largeImageCaption);
                $('.item-gallery .image-holder img').attr('src', largeImageSource).attr('alt', largeImageCaption);
            }
        });
        $(".figure-controls #fig-prev").click(function() {
            var position = $('.item-gallery .image-holder img').attr('src');
            if (position != firstItemSource) {
                $('.item-gallery .carousel ul').trigger("prev", 1);
                var currentActive = $('.item-gallery .carousel ul li.active');
                currentActive.prev().addClass('current');
                $('.item-gallery .carousel ul li').removeClass('active');
                $('.item-gallery .carousel ul li.current').addClass('active');
                $('.item-gallery .carousel ul li').removeClass('current');
                var largeImageSource = $('.item-gallery .carousel ul li.active').find('a:first').attr('data-source');
                var largeImageCaption = $('.item-gallery .carousel ul li.active').find('a:first').attr('title');
                $('h3.gallery-caption').text(largeImageCaption);
                $('.item-gallery .image-holder img').attr('src', largeImageSource).attr('alt', largeImageCaption);
            }
        });
        $('.item-gallery .carousel ul').find('li').each(function() {
            $(this).delegate('a', 'click', function(e) {
                var largeImageSource = $(this).attr('data-source');
                var largeImageCaption = $(this).attr('title');
                $('h3.gallery-caption').text(largeImageCaption);
                $('.item-gallery .image-holder img').attr('src', largeImageSource).attr('alt', largeImageCaption);
                $('.item-gallery .carousel ul li').removeClass('active');
                $(this).parent().addClass('active');
                e.preventDefault();
            });
        });
		
    }
	
    /** Live Player **/
    if ($('#liveplayer').length) {
		
        function loadLivePlayer(file) {
            if (file) {
                $.ajax({
                    type: 'GET',
                    url: '/modules/live/' + file + '.html',
                    cache: false,
                    success: function(msg) {
                        $('#liveplayer').html(msg);
                    }
                });
            }
        }
        loadLivePlayer('low');
        $('.bitrates a').each(function() {
            $(this).click(function(event) {
                $('.bitrates ul li').removeClass('active');
                var videoQuality = $(this).attr('data-quality');
                loadLivePlayer(videoQuality);
                $(this).parent().addClass('active');
                event.preventDefault();
            });
        });
    }
	
    /** Comments **/
    if ($('.item-comment-form').length) {
		
        /** Resolve Captcha Src **/
        var siteRoot = '/';
        var captchaImage = $('img[alt="Captcha"]');
        captchaImage.attr("src", siteRoot + captchaImage.attr("src"));
		
        if (typeof commentSuccess != 'undefined' && commentSuccess == true) {
            var commentMessage = '<div class="comment-message alert alert-success hide">پیام شما در یافت شد و پس از تایید نمایش داده خواهد شد.</div>';
            $('.item-comment-form form:first').prepend(commentMessage);
            $("html, body").animate({ scrollTop: $(document).height() }, "slow");
            $('.comment-message').delay(500).fadeIn(1000).delay(10000).fadeOut(1000);
        }
		
        function isValidEmailAddress(emailAddress) {
            var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
        return pattern.test(emailAddress);
    }
		
    $('.item-comment-form form:first').submit(function() {
        var nameField = $('#name').val();
        var emailField = $('#email').val();
        var commentText = $('#comment').val();
        if (nameField == '' || (emailField != '' && !isValidEmailAddress(emailField)) || commentText == '') {
            if (nameField == '') $('#name').parent().addClass('error');
            if (emailField != '') 
                if (!isValidEmailAddress(emailField))
                    $('#email').parent().addClass('error');
            if (commentText == '') $('#comment').parent().addClass('error');
            return false;
        } else {
            return true;
        }
    });
		
    if ($('.item-comment-form form').length) {
        $('.item-comment-form form').find('input, textarea').each(function() {
            $(this).on('focus', function() {
                $(this).parent().removeClass('error');
            });
        });
    }
}
	
	/** prices **/
	$('#prices-group .accordion-group').on('shown', function () {
	    $(this).find('a.accordion-toggle span').removeClass('icon-left-open-1').addClass('icon-down-open-1')
	}).on('hidden', function() {
	    $(this).find('a.accordion-toggle span').removeClass('icon-down-open-1').addClass('icon-left-open-1')
	});
	
/** Schedules Tab **/
$('#schedule-tabs a').click(function(event) {
    $(this).tab('show');
    var href = $(this).attr('href').replace("#", "");
    // alert(href);
    if ($('#' + href).text().length < 10) {
        $('#' + href).empty();
        $('#' + href).append("<img src=\"/App_Themes/Theme1/img/ajax-loader.gif\">");
        //Schedule_Day_Tab_Click
        $.ajax({
            type: "POST",
            url: "/CallBack/CallBack.Aspx/LoadSchedulesAjax",
            data: "{ DtId:\"" + href.replace("Date-", "") + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //  alert(data.d);
                $('#' + href).empty();
                $('#' + href).append(data.d);
                
            },
            error: function (data) {
                $('#' + href).empty();
                $('#' + href).append(data.d);
        }
        })
        
    }
    MoveToOnAir();
    event.preventDefault();
});
	
/** Return to top link smooth scroll **/
$('.totop a:first').click(function(event) {
    $("html, body").animate({ scrollTop: 0 }, "slow");
    event.preventDefault();
});

    //Move To Scroll
function MoveToOnAir() {
    if ($('.error').length) {
        $('html, body').animate({
            scrollTop: $(".error").offset().top - 70
        }, 1000);
    }
}
MoveToOnAir();

	
	
});

/*! http://mths.be/placeholder v2.0.7 by @mathias */
;(function(f,h,$){var a='placeholder' in h.createElement('input'),d='placeholder' in h.createElement('textarea'),i=$.fn,c=$.valHooks,k,j;if(a&&d){j=i.placeholder=function(){return this};j.input=j.textarea=true}else{j=i.placeholder=function(){var l=this;l.filter((a?'textarea':':input')+'[placeholder]').not('.placeholder').bind({'focus.placeholder':b,'blur.placeholder':e}).data('placeholder-enabled',true).trigger('blur.placeholder');return l};j.input=a;j.textarea=d;k={get:function(m){var l=$(m);return l.data('placeholder-enabled')&&l.hasClass('placeholder')?'':m.value},set:function(m,n){var l=$(m);if(!l.data('placeholder-enabled')){return m.value=n}if(n==''){m.value=n;if(m!=h.activeElement){e.call(m)}}else{if(l.hasClass('placeholder')){b.call(m,true,n)||(m.value=n)}else{m.value=n}}return l}};a||(c.input=k);d||(c.textarea=k);$(function(){$(h).delegate('form','submit.placeholder',function(){var l=$('.placeholder',this).each(b);setTimeout(function(){l.each(e)},10)})});$(f).bind('beforeunload.placeholder',function(){$('.placeholder').each(function(){this.value=''})})}function g(m){var l={},n=/^jQuery\d+$/;$.each(m.attributes,function(p,o){if(o.specified&&!n.test(o.name)){l[o.name]=o.value}});return l}function b(m,n){var l=this,o=$(l);if(l.value==o.attr('placeholder')&&o.hasClass('placeholder')){if(o.data('placeholder-password')){o=o.hide().next().show().attr('id',o.removeAttr('id').data('placeholder-id'));if(m===true){return o[0].value=n}o.focus()}else{l.value='';o.removeClass('placeholder');l==h.activeElement&&l.select()}}}function e(){var q,l=this,p=$(l),m=p,o=this.id;if(l.value==''){if(l.type=='password'){if(!p.data('placeholder-textinput')){try{q=p.clone().attr({type:'text'})}catch(n){q=$('<input>').attr($.extend(g(this),{type:'text'}))}q.removeAttr('name').data({'placeholder-password':true,'placeholder-id':o}).bind('focus.placeholder',b);p.data({'placeholder-textinput':q,'placeholder-id':o}).before(q)}p=p.removeAttr('id').hide().prev().attr('id',o).show()}p.addClass('placeholder');p[0].value=p.attr('placeholder')}else{p.removeClass('placeholder')}}}(this,document,jQuery));$(function() { $('input, textarea').placeholder(); }); // Calling an instance of placeholder for all input areas
    function DoSearch (Key) {
        if (Key.length > 0) {
            window.location = "/search/"+Key;
        }
        else {
            window.location = "/search/";
        }
    }
	
	
	
	
$(function() {
	$(".box.carousel").each(function() {
		var $carousel = $(this);
		var $controls = ($carousel.find(".carousel-controls").length) ? $carousel.find(".carousel-controls") : null;
		var $items = $carousel.find("ul:first");
		$items.carouFredSel({
			items: 4
			, auto: false
			, next: ($controls) ? $controls.find(".next") : false
			, prev: ($controls) ? $controls.find(".prev") : false
			, scroll: 1
			, width: 610
		});
	});
});





