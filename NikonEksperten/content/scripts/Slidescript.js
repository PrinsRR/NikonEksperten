window.onload = function() {
    windowwidth();
    slideauto();
};

$(window).resize(function() {
    windowwidth();
});
function windowwidth() {
    var count = $(".slides").children().length;
    var w = $(window).width();
    if (w > 1000) {
        $(".SliderContainer").css("width", 1000);
        } else {
        $(".SliderContainer").css("width", w);
    }
    $(".slide").width(100 / count + "%");
    $(".slides").width(100 * count + "%");


}
slidegoing = 0;

function slideauto(parameters) {
    setInterval(function () {
            slide('right');
    }, 10000);
}
function slide(direction) {
    if (slidegoing === 0) {
        var count = $(".slides").children().length;
        if (direction !== "left" && count - 1 <= -parseInt($(".slides").css("margin-left")) / $(".slide").width()) {
            slidegoing = 1;
            $(".slides").animate({ marginLeft: 0 + "%" }, 3000, 'easeInOutQuint', function() {
                slidegoing = 0;
            });
            circleadmin(0);

        } else if (direction !== "right" && 0 >= -parseInt($(".slides").css("margin-left")) / $(".slide").width()) {
            slidegoing = 1;
            $(".slides").animate({ marginLeft: -100 * count + 100 + "%" }, 3000, 'easeInOutQuint', function () {
                slidegoing = 0;
            },circleadmin(count-1));
            


        } else {
            slidegoing = 1;
            var movedirection = 0;
            if (direction === "left") {
                movedirection = $(".slide").width();
                var pos = -parseInt($(".slides").css("margin-left")) / $(".slide").width() - 1;

            } else if (direction === "right") {
                movedirection = -1 * $(".slide").width();
                var pos = -parseInt($(".slides").css("margin-left")) / $(".slide").width() + 1;

            }

            var movedirectionfixed = movedirection;
            var result = parseInt(movedirectionfixed) + parseInt($(".slides").css("margin-left"));
            $(".slides").animate({ marginLeft: result / $(".slide").width() * 100 + "%" }, 2000, 'easeInOutQuint', function() {
                slidegoing = 0;
            });
            circleadmin(pos);
        }}
    
}

function circleadmin(pos) {
    $('.progress > .roundicon').not(':eq(' + pos + ')').animate({
        backgroundColor: 'rgba(255,255,255,0.9)'
    }, 1000);
    $(".progress > .roundicon:eq(" + pos + ")").animate({
        backgroundColor: 'rgba(84,167,146,1)'
    }, 1000);
}

function circleslidenav(pos) {

    if (slidegoing === 0) {
        circleadmin(pos);
        $(".slides").animate({ marginLeft: -pos * 100 + "%" }, 2000, 'easeInOutQuint', function() {
            slidegoing = 0;
        });
    }
}

function navigate(id) {
    $('.undermenu' + " a, .undermenu").not(".id" + id + " a, .id" + id).stop().fadeOut("fast");
    $(".id" + id + " a, .id" + id).stop().fadeIn("fast");

}
