var infiniteScroll = (function () {

    var app = {},
        dom = {
            scrollFooter: null,
            sidebar: null,
            sidebarTotal: null,
            sidebarLoaded: null
        },
        currentPage = 0,
        itemCount = 0,
        totalItemCount = 0,
        pageSize = 0,
        scrollTop = 0,
        height = 0,
        isLoading = false,
        isLoaded = false,
        viewModel = { Items: ko.observableArray([]) },
        setFooterText = function (text) { dom.scrollFooter.textContent = text; },
        showFooter = function () { dom.scrollFooter.style.visibility = "visible"; },
        hideFooter = function () { dom.scrollFooter.style.visibility = "hidden"; },
        setHeight = function (e, h) { e.style.height = h + "px"; },
        setSidebarHeights = function () {
            
            setHeight(dom.sidebarTotal, height);
            
            setHeight(dom.sidebarLoaded, height * itemCount / totalItemCount);
        },
        listen = function () {
            
            if (isLoaded) {
                return;
            }
            
            scrollTop = document.documentElement.scrollTop
                    ? document.documentElement.scrollTop
                    : document.body.scrollTop;
            
            height = document.documentElement.clientHeight;
            
            setSidebarHeights();
            
            if (document.body.offsetHeight <= scrollTop + height) {
                app.LoadNextPage();
            }
        };

    app.LoadNextPage = function () {
        
        if (isLoading) {
            return;
        }
        
        isLoading = true;
        
        setFooterText("Loading...");
        
        showFooter();
        
        $.getJSON("data/page" + (currentPage + 1) + ".json", function (d) {
            
            var i;
            
            for (i = 0; i < d.Items.length; i++) {
                viewModel.Items.push(d.Items[i]);
            }
            
            itemCount = itemCount + d.Items.length;
            
            totalItemCount = d.TotalItemCount;
            
            if (pageSize === 0) {
                pageSize = d.Items.length;
            }
            
            currentPage = currentPage + 1;
            
            isLoading = false;
            
            hideFooter();
        })
        .fail(function(e) {
            
            if (typeof e === "object" && e.status === 404) {
                
                isLoaded = true;
                
                setFooterText("Bottom of the Page");
                
                dom.sidebar.style.display = "none";
                
            }
        });
    };
    
    app.Initialize = function (config) {
        
        var scrollingList = document.getElementById(config.scrollingListId);
        
        ko.applyBindings(viewModel, scrollingList);
        
        dom.scrollFooter = document.getElementById(config.scrollFooterId);
        
        dom.sidebar = document.getElementById(config.sidebarId);
        
        dom.sidebarTotal = document.getElementById(config.sidebarTotalId);
        
        dom.sidebarLoaded = document.getElementById(config.sidebarLoadedId);
        
        scrollingList.style.display = "block";
        
        setInterval(listen, 100);
    };

    return app;

}());