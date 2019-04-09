$(function () {
    console.log("jq fungerer");

    // Delete
    $("body").on("click", ".delete-movie", function () {
        console.log("click delete");
        var $this = $(this);
        var $row = $this.closest(".row");

        var idName = "";

        if ($this.data("controller") === "MoviesAdministration") {
            idName = "movieId";
        }
        else if ($this.data("controller") === "CustomerAdministration") {
            idName = "userName";
        }
        else if ($this.data("controller") === "MoviesOrderAdministration") {
            idName = "movieOrderId";
        }
        else if ($this.data("controller") === "AdminUserAdministration") {
            idName = "userName";
        }

        var url = "/" + $this.data("controller") + "/" + $this.data("action") + "?" + idName + "=" + $this.data("id");
        //var url = "/" + $this.data("controller") + "/" + $this.data("action") + "/";

        console.log(url);

        console.log($row);

        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: url,
            dataType: "json",
            success: function (data) {
                removeDeletedRow($row);
            },
            error: function (data) {
                console.log("Error in JSON return", data);
                couldNotDeleteRow($row);
            }
        });
    });
});

var removeDeletedRow = function ($row) {
    $row.addClass("admin-list-row-deleted");

    setTimeout(function () {
        $row.slideUp(500, function () {
            $(this).remove();
        });
    }, 800);
}

var couldNotDeleteRow = function ($row) {
    $row.append("<p class='col-12 text-danger text-center padding-top'>Something went wrong. Could not delete row.</p>");
}