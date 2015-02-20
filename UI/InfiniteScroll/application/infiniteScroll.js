var infiniteScroll = (function () {

    var app = {},
        footer = null,
        showFooter = function () { footer.style.visibility = "visible"; },
        hideFooter = function () { footer.style.visibility = "hidden"; },
        currentPage = 0,
        viewModel = {
            Items: ko.observableArray([])
        },
        isLoading = false,
        listenToScrolling = function () {
            
            var scrollTop = document.documentElement.scrollTop
                    ? document.documentElement.scrollTop
                    : document.body.scrollTop;
            
            if (document.body.offsetHeight <= scrollTop + document.documentElement.clientHeight) {
                app.LoadNextPage();
            }
        };

    app.LoadNextPage = function () {
        
        if (isLoading) {
            return;
        }
        
        isLoading = true;
        
        showFooter();
        
        $.getJSON("data/page" + (currentPage + 1) + ".json", function (d) {
            
            var i;
            
            for (i = 0; i < d.Items.length; i++) {
                viewModel.Items.push(d.Items[i]);
            }
            
            currentPage = currentPage + 1;
            
            isLoading = false;
            
            hideFooter();
        })
        .fail(function(e) {
            if (typeof e === "object" && e.status === 404) {
                
                footer.textContent = "Bottom of the Page";
                
            }
        });
    };
    
    app.Initialize = function (scrollingListId, footerId) {
        
        var scrollingList = document.getElementById(scrollingListId);
        
        ko.applyBindings(viewModel, scrollingList);
       
        footer = document.getElementById(footerId);
        
        scrollingList.style.display = "block";
        
        setInterval(listenToScrolling, 100);
    };

    return app;

}());