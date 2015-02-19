var infiniteScroll = (function () {

    var app = {},
        footer = null,
        showFooter = function () { footer.style.visibility = "visible"; },
        hideFooter = function () { footer.style.visibility = "hidden"; },
        currentPage = 0,
        viewModel = {
            Items: ko.observableArray([])
        },
        isLoading = false;

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
        })
        .done(function() {
            
            isLoading = false;
            
        })
        .fail(function(e) {
            if (typeof e === "object") {
                console.dir(e);
            } else {
                console.log(e);
            }
        })
        .always(function() {
            
            hideFooter();
            
        });
    };
    
    app.Initialize = function (listId, footerId) {
        ko.applyBindings(viewModel, document.getElementById(listId));
        footer = document.getElementById(footerId);
    };

    return app;

}());