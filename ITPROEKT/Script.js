var currentPage = 0;
var sortCriteria = "";
var filterCategory = "All";
$(document).ready(function () {
    ajaxCat(filterCategory, false);

    //PAGINATION FUNCTIONALITY
    $(".page-item").click(function () {
        if ($(this).attr('id') === "left") {
            currentPage = parseInt(currentPage);
            if (currentPage === 0)
                return;
            else {
                currentPage -= 1;
                $("#mainContainer").empty();
                ajaxCat(filterCategory, true);
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
                ajaxCat(filterCategory, true);
            }
        }
        else {
            currentPage = $(this).attr('id');
            currentPage = parseInt(currentPage);
            $("#mainContainer").empty();
            ajaxCat(filterCategory, true);
        }
    });

    //SORT
    $(".sort").click(function () {
        sortCriteria = $(this).attr('sortBy');
        FilterAndSort();
    })

    //FILTER
    $(".cat").click(function () {
        filterCategory = $(this).attr('cate');
        FilterAndSort();
    })

});

function FilterAndSort() {
    ajaxCat(filterCategory, true);
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
    for (var i = currentPage; i < (currentPage + 1) * 9; i++) {
        if (i % 3 == 0) {
            if (i % 9 == 0) {
                $("#mainContainer").empty();
                divNum = i;
                div = $("<div></div>").attr({
                    class: 'row',
                    index: divNum
                });
                $("#mainContainer").append(div);
            }
            else {
                divNum = i;
                div = $("<div></div>").attr({
                    class: 'row',
                    index: divNum
                });
                $("#mainContainer").append(div);
            }
            
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

function ajaxCat(category, sortCall) {
    $.ajax({
        url: "https://localhost:44361/api/Products/GetByCategory/" + category,
        method: "GET",
        dataType: "json",
        success: function (data) {
            listItems(data, sortCall);
        }
    });
}
