var currentPage = 0;
var sortCriteria = "";

$(document).ready(function () {
    ajaxCall(0);

    //PAGINATION FUNCTIONALITY
    $(".page-item").click(function () {
        if ($(this).attr('id') === "left") {
            currentPage = parseInt(currentPage);
            if (currentPage === 0)
                return;
            else {
                currentPage -= 1;
                $("#mainContainer").empty();
                ajaxCall(currentPage);
            }
        }
        else if ($(this).attr('id') === "right") {
            currentPage = parseInt(currentPage);
            if ($(".pagination").attr("numPages") == (currentPage + 1)) {
                return;
            }
            else {
                currentPage += 1;
                $("#mainContainer").empty();
                ajaxCall(currentPage);
            }
        }
        else {
            currentPage = $(this).attr('id');
            currentPage = parseInt(currentPage);
            $("#mainContainer").empty();
            ajaxCall($(this).attr('id'));
        }
    });

    //SORT
    $(".dropdown-item").click(function () {
        $("#mainContainer").empty();
        sortCriteria = $(this).attr('sortBy');
        sort();
    })
});


function sort() {
    ajaxCall(currentPage, true);
}

function listItems(data, sortCall) {

    var divNum;
    var div;

    //SORTING
    if (sortCall == true) {
        switch (sortCriteria) {
            case "min-max":
                data.sort(function (a, b) {
                    return a.Price - b.Price;
                });
                break;
            case "max-min":
                data.sort(function (a, b) {
                    return b.Price - a.Price;
                });
                break;
            case "name":
                data.sort(function (a, b) {
                    var nameA = a.Name.toUpperCase(); 
                    var nameB = b.Name.toUpperCase();
                    if (nameA < nameB) {
                        return -1;
                    }
                    if (nameA > nameB) {
                        return 1;
                    }
                    return 0;
                });
                break;
            case "seller":
                data.sort(function (a, b) {
                    var nameA = a.Seller.Name.toUpperCase();
                    var nameB = b.Seller.Name.toUpperCase();
                    if (nameA < nameB) {
                        return -1;
                    }
                    if (nameA > nameB) {
                        return 1;
                    }
                    return 0;
                });
                break;
        }
    }

    for (var i = 0; i < data.length; i++) {
        if (i % 3 == 0) {
            divNum = i;
            div = $("<div></div>").attr({
                class: 'row',
                index: divNum
            });
            $("#mainContainer").append(div);
        }

        var imgURL = data[i].URL;
        var productName = data[i].Name;
        var desc = data[i].Description;
        var sellerName = data[i].Seller.Name;
        var rating = data[i].Rating;
        var price = data[i].Price;

        var codeBlock = '<div class="float-left bg-dark"></div> \
                            <div class="col-md-4" id = "productCard"> \
                                <figure class="card card-product"> \
                                    <div class="img-wrap"><img src="' + imgURL + '"></div> \
                                        <figcaption class="info-wrap"> \
                                            <h4 class="title">' + productName + '</h4> \
                                            <p class="desc">' + desc + '</p> \
                                            <a class="font-weight-bold float-right">' + sellerName + '</a> \
                                            <div class="rating-wrap"> \
                                                <div class="label-rating">' + rating + '</div> \
                                            </div> \
                                        </figcaption> \
                                        <div class="bottom-wrap"> \
                                            <a href="" class="btn btn-sm btn-primary float-right">Order Now</a> \
                                            <div class="price-wrap h5"> \
                                                <span class="price-new">' + price + '$</span> \
                                            </div>  \
                                        </div>  \
                                </figure>\
                            </div>'
        $('div[index="' + divNum + '"]').append(codeBlock);
    }
}

function ajaxCall(pageNum, sortCall) {
    pageNum *= 9;
    $.ajax({
        url: "https://localhost:44361/api/Products/GetProducts/" + pageNum,
        method: "GET",
        dataType: "json",
        success: function (data) {
            listItems(data, sortCall);
        }
    });
}