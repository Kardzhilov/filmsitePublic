$(function () {
    // Show movie info
    $("body").on("click", ".movie-info-link", function (e) {
        e.preventDefault();
        $this = $(this);

        var movieId = $this.data("movie-id");
        var $targetContainer = $("#" + $this.data("movie-genre") + "-information-toggle");

        if ($(".active").length) $(".active").removeClass("active");

        if ($targetContainer.hasClass("open") && movieId == $targetContainer.data("current-movie-id")) {
            $targetContainer.empty().removeClass("open");
            $this.removeClass("active");
            return;
        } else if ($targetContainer.hasClass("open")) {
            $this.addClass("active");
        } else {
            $(".open").empty().removeClass("open");
            $targetContainer.addClass("open");
            $this.addClass("active");
        }

        $targetContainer.data("current-movie-id", movieId);
        showMovieInfo(movieId, $targetContainer);
    });

    // Rental confirm modal
    $("body").on("click", ".info-toggle-rent-button", function (e) {
        var movieId = $(this).data("movie-id");
        var movieTitle = $(this).data("movie-title");
        $("#rent-confirm-button").data("movie-id", movieId);
        $("#rent-confirm-modal-movie-title").text(movieTitle);
    });

    // Rental confirm button
    $("body").on("click", "#rent-confirm-button", function (e) {
        var movieId = $(this).data("movie-id");

        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: '/Home/NewRental/',
            data: { 'movieId': movieId.toString() },
            dataType: "json",
            success: function (data) {
                if (data == "OK") {
                    window.location.href = "/MyMovies/Index";
                }
                else if (data == "UserError") {
                    window.location.href = "/Home/UserNotLoggedInRedirect"
                }
            },
            error: function (data) {
                console.log("Error in JSON return", data);
            }
        });
    });

    // Search
    var $mainconten = $("#main-content");
    var $searchField = $('#search-field');
    var $searchResultContainer = $("#search-result");
    var $searchResult = $searchResultContainer.find(".category-scroller-content");
    var $searchResultTemplate = $("#search-result-template").html();

    $searchField.on('input', function (e) {
        delay(function () {
            $searchResultContainer.fadeIn("fast");
            $searchResult.empty();
            var input = $searchField.val();

            if (input == null || input == "") {
                $searchResultContainer.hide();
                $mainconten.fadeIn("fast");
                return;
            }

            $mainconten.hide();

            $.ajax({
                type: "GET",
                contentType: "application/json",
                url: '/Home/GetMovieData/',
                data: { 'searchQuery': input },
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < Object.keys(data).length && i < 12; i++) {
                        $searchResult.append($searchResultTemplate);
                        var $result = $searchResult.find(".movie-info-link:last-child");
                        $searchResultTemplate;
                        $result.data("movie-id", data[i].ID);
                        $result.attr("aria-label", data[i].Title);
                        $result.find("img").attr("src", data[i].Poster);
                        $result.find("img").attr("alt", data[i].Title);
                    }
                },
                error: function (data) {
                    console.log("Error in JSON return", data);
                }
            });

        }, 250);

    });

    // Scroll categories on click
    $("body").on("click", ".category-js-scroller-arrow", function () {
        var $this = $(this);
        var $scrollDiv = $this.parent().find(".category-scroller-wrapper");
        var scrollPosition = $scrollDiv.scrollLeft();
        var directionRight = $this.data("direction-right");
        var newScrollPosition = scrollPosition;
        var scrollLenght = 650;

        directionRight ? newScrollPosition += scrollLenght : newScrollPosition -= scrollLenght;

        // Activate or deactivate scroll buttons
        $scrollDiv.animate({ scrollLeft: newScrollPosition }, 400, "swing", function () {
            $scrollDiv.parent(".category-scrollbar-hider").mouseenter();
        });

    });

    // Hide scroller when not necessary
    $("body").on("mouseenter", ".category-scrollbar-hider", function () {
        var $this = $(this);
        var $scrollLeftButton = $this.find(".category-js-scroller-left");
        var $scrollRightButton = $this.find(".category-js-scroller-right");
        var contentPosition = $this.find(".category-scroller-wrapper").scrollLeft();
        var contentWidth = $this.find(".site-content-padding").outerWidth();

        if (contentPosition == 0) {
            $scrollLeftButton.addClass("inactive");
        } else {
            $scrollLeftButton.removeClass("inactive");
        }

        if (contentWidth <= $this.width() || contentPosition + $this.width() >= Math.floor(contentWidth)) {
            $scrollRightButton.addClass("inactive");
        } else {
            $scrollRightButton.removeClass("inactive");
        }
    });
});

// Show movie info
var showMovieInfo = function (movieId, $targetContainer) {
    var jsonUrl = "/Home/GetMovieById/" + movieId;
    var htmlTemplate = $("#ajax-movie-info-template").html();

    $.getJSON(jsonUrl).done(function (movieData) {
        $targetContainer.html(htmlTemplate);
        $targetContainer.find(".info-toggle-tilte").text(movieData.Title);
        $targetContainer.find(".info-toggle-priority-metadata").text(movieData.Year + " | " + movieData.Genre);
        $targetContainer.find(".info-toggle-plot").text(movieData.Plot);
        $targetContainer.find(".info-toggle-metadata").text("Runtime: " + movieData.Runtime + " | Rated: " + movieData.Rated + " | IMDb: " + movieData.ImdbRating);
        $targetContainer.find(".info-toggle-screenshot").attr("src", movieData.ScreenShot);
        $targetContainer.find(".info-toggle-screenshot").attr("alt", movieData.Title);
        $targetContainer.find(".info-toggle-rent-button").data("movie-id", movieData.ID);
        $targetContainer.find(".info-toggle-rent-button").data("movie-title", movieData.Title);
    }).fail(function () {
        console.log("Could not load JSON for movie info toggle");
    });
};

// Delay function from Stack Overflow
// https://stackoverflow.com/questions/1909441/how-to-delay-the-keyup-handler-until-the-user-stops-typing
var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();