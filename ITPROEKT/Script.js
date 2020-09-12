var currentPage = 0;
var sortCriteria = "";
var filterCategory = "All";
var filterSeller = "All";
var pageSize = 9;
var searchString = "";
$(document).ready(function () {
    ajaxCat(filterSeller, filterCategory, false);
    //Pagination
    
    //PAGINATION FUNCTIONALITY
    /*$(".page-item").click(function () {
        if ($(this).attr('id') === "left") {
            currentPage = parseInt(currentPage);
            if (currentPage === 0)
                return;
            else {
                currentPage -= 1;
                $("#mainContainer").empty();
                ajaxCat(filterSeller, filterCategory, true);
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
                ajaxCat(filterSeller, filterCategory, true);
            }
        }
        else {
            currentPage = $(this).attr('id');
            currentPage = parseInt(currentPage);
            $("#mainContainer").empty();
            ajaxCat(filterSeller, filterCategory, true);
        }
    });*/

    //SORT
    $(".sort").click(function () {
        sortCriteria = $(this).attr('sortBy');
        FilterAndSort();
    })

    //FILTER CATEGORY
    $(".cat").click(function () {
        filterCategory = $(this).attr('cate');
        FilterAndSort();
    })

    //FILTER SELLER
    $(".seller").click(function () {
        filterSeller = $(this).attr('seller');
        FilterAndSort();
    })

    $('.search_input').on('keyup', function () {
        searchString = $(this).val().toLowerCase();
        FilterAndSort();
    })

}); 


function FilterAndSort() {
    if (searchString != "") {
        ajaxCall(searchString, filterSeller, filterCategory, true);
    }
    else {
        ajaxCat(filterSeller, filterCategory, true);
    }
}


function listItems(data, sortCall) {
    //Pagination
    
    var pageCount = Math.ceil(data.length / 9);
    $("#pagin").empty();
    $("#pagin").append('<li class="page-item" id="left">\
        <a class= "page-link" href = "#" aria - label="Previous" >\
    <span aria-hidden="true">&laquo;</span>\
    <span class="sr-only">Previous</span>\
                </a >\
            </li >');
    for (var i = 0; i < pageCount; i++) {
        if (i == 0) {
            $("#pagin").append('<li class="page-item" id = "' + i + '" ><a class= "page-link" href = "#" >' + (i + 1) + '</a ></li > ');
        }
        else {
            $("#pagin").append('<li class="page-item" id = "' + i + '" ><a class= "page-link" href = "#" >' + (i + 1) + '</a ></li > ');
        }
    }
    $("#pagin").append('<li class="page-item" id="right">\
        <a class= "page-link" href = "#" aria - label="Next" >\
    <span aria-hidden="true">&raquo;</span>\
    <span class="sr-only">Next</span>\
                </a >\
            </li >');

    $(".page-item").click(function () {
        if ($(this).attr('id') === "left") {
            currentPage = parseInt(currentPage);
            if (currentPage === 0)
                return;
            else {
                currentPage -= 1;
                $("#pagin").empty();
                ajaxCat(filterSeller, filterCategory, true);
            }
        }
        else if ($(this).attr('id') === "right") {
            currentPage = parseInt(currentPage);
            if (pageCount == (currentPage + 1)) {
                return;
            }
            else {
                currentPage += 1;
                $("#pagin").empty();
                ajaxCat(filterSeller, filterCategory, true);
            }
        }
        else {
            currentPage = $(this).attr('id');
            $("#pagin").empty();
            ajaxCat(filterSeller, filterCategory, true);
        }
    });
    
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
    var i;
    if (currentPage == 0) {
        i = 0;
    }
    else {
        i = currentPage * 9;
    }
    for (; i < (currentPage + 1) * 9; i++) {
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
        if (desc.trim().length > 46) {
            desc = desc.substring(0, 46) + '...';
        }
        var sellerName = data[i].Seller.Name;
        var rating = data[i].Rating;
        var price = data[i].Price;
        var prodId = data[i].Id; 

        var codeBlock = '<div class="float-left bg-dark"></div> \
                            <div class="col-md-4" id = "productCard"> \
                                <figure class="card card-product"> \
                                    <div class="img-wrap"><a href="/Products/Details/'+ prodId +'"><img src="' + imgURL + '"></a></div> \
                                        <figcaption class="info-wrap"> \
                                            <h4 class="title" id="productName">' + productName + '</h4> \
                                            <p class="desc">' + desc + '</p> \
                                            <a class="font-weight-bold float-right">' + sellerName + '</a> \
                                            <div class="rating-wrap"> \
                                                <div class="label-rating">' + rating + '</div> \
                                            </div> \
                                        </figcaption> \
                                        <div class="bottom-wrap"> \
                                            <a href="/Products/Details/'+ prodId + '" class="btn btn-sm text-white float-right" style="background-color:#65a4bd">Order Now</a> \
                                            <div class="price-wrap h5"> \
                                                <span class="price-new">' + price + '$</span> \
                                            </div>  \
                                        </div>  \
                                </figure>\
                            </div>'
        $('div[index="' + divNum + '"]').append(codeBlock);
        $('.page-item').filter(function () {
            var page = $(this).attr('id');
            if (page == currentPage) {
                $('.page-item').removeClass('current');
                $(this).addClass('current');
            }
        })
    }
}

function emptyFilter() {
    $("#pagin").empty();
    $("#mainContainer").empty();
    $("#mainContainer").append('<h3>There are currently no products for this filter.</h3>');
}

function ajaxCat(seller, category, sortCall) {
    $.ajax({
        url: "https://localhost:44361/api/Products/GetByCategory/" + category + "/" + seller,
        method: "GET",
        dataType: "json",
        success: function (data) {
            if (data.length == 0) {
                emptyFilter();
            }
            else {
                listItems(data, sortCall);
            }
            
        }
    });
}
function ajaxCall(searchString, seller, category, sortCall) {
    $.ajax({
        url: "https://localhost:44361/api/Products/GetBySearch/" + searchString + "/" + category + "/" + seller,
        method: "GET",
        dataType: "json",
        success: function (data) {
            if (data.length == 0) {
                emptyFilter();
            }
            else {
                listItems(data, sortCall);
            }
        }
    });
}
