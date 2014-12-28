function Poll(OptionId) {
    $.ajax({
        type: "POST",
        url: "/CallBack/CallBack.Aspx/PollInserter",
        data: "{ OptionId:" + OptionId + " }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#pollbody').empty();
            $('#pollbody').append(data.d);
        }
    })
};

$('#submit-poll').each(function () {
    $(this).click(function (event) {
        var val = $('input:radio[name=poll-options]:checked').val();
        if (val > 0) {
            $('#pollbody').empty();
            $('#pollbody').append("<img src=\"/App_Themes/Theme1/img/ajax-loader.gif\">");
            Poll(val);
        }
        event.preventDefault();

    });
});




$(document).ready(function () {
    var Skip = 10;
    var Take = 5;
    function LoadPrograms() {
        $('#divPostsLoader').html("<img src=\"/App_Themes/Theme1/img/ajax-loader.gif\">");
        $.ajax({
            type: "POST",
            url: "/CallBack/CallBack.Aspx/LoadPrograms",
            data: "{ Skip:" + Skip + ", Take:" + Take + " }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d != "No") {
                    if (data != "") {
                        $('.list').find('ul').append(data.d);
                        $('#divPostsLoader').empty();
                    }

                }
                else {
                    $('#divPostsLoader').empty();
                }
            }

        })
    };
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            if (document.location.href.indexOf('programs') > -1) {
                LoadPrograms(Skip, Take);
                Skip = Skip + 5;
            }
        }
    });
});

//MoreNewsList
$(document).ready(function () {
    $('#content-more-list').each(function () {
        function loadcontents(skipcnt, categoryid) {
            //  alert('ddd');
            $.ajax({
                type: "POST",
                url: "/CallBack/CallBack.Aspx/LoadContents",
                data: "{ Skip:" + skipcnt + ", Take:" + 5 + ", CatId:" + categoryid + "  }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //  alert(data.d);
                    if (data.d != "No") {
                        if (data != "") {
                            $("ul.item-titles").append(data.d);
                            $('#imgcontentmorelist').remove();
                        }
                    }
                    else {
                        // $('#divPostsLoader').empty();
                        $('#content-more-list').hide();
                        $('#imgcontentmorelist').remove();
                    }
                }

            })
        }
        $(this).click(function (event) {
            var skipcount = $("ul.item-titles").children().length;
            var categid = $('#content-more-list').attr("catid");
            // alert(skipcount);
            $("ul.item-titles").append("<img id=\"imgcontentmorelist\" src=\"/App_Themes/Theme1/img/ajax-loader.gif\">");
            loadcontents(skipcount, categid);
            event.preventDefault();

        });
    });
});


//MoreNewspage
$(document).ready(function () {
    $('#content-more-newspage').each(function () {
        function loadcontents(skipcnt, categoryid) {
            //  alert('ddd');
            $.ajax({
                type: "POST",
                url: "/CallBack/CallBack.Aspx/LoadContentsNewsPage",
                data: "{ Skip:" + skipcnt + ", Take:" + 5 + ", CatId:" + categoryid + "  }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //   alert(data.d);
                    // alert(skipcnt+1);
                    if (data.d != "No") {
                        if (data != "") {
                            $("#ulnewspagelist").append(data.d);
                            $('#imgcontentmorenewspage').remove();
                        }
                    }
                    else {
                        // $('#divPostsLoader').empty();
                        $('#content-more-newspage').hide();
                        $('#imgcontentmorenewspage').remove();
                    }
                }

            })
        }
        $(this).click(function (event) {
            var skipcount = $("#ulnewspagelist").children('li').length;
            var categid = $('#content-more-newspage').attr("catid");
            // alert(skipcount);
            $("content-more-list").append("<img id=\"imgcontentmorenewspage\" src=\"/App_Themes/Theme1/img/ajax-loader.gif\">");
            loadcontents(skipcount + 1, categid);
            event.preventDefault();

        });
    });
});



