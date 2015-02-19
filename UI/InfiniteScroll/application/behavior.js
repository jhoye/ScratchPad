(function () {

    var ulScrollingList = $("#scrollingList");
    
    // assign handlers to DOM events for scrolling
    
    // call any initialization in app
    infiniteScroll.Initialize("scrollingList", "footer");
    ulScrollingList.show();
    infiniteScroll.LoadNextPage();
    
    setInterval(function () {
        
        var totalHeight, currentScroll, visibleHeight;
        
        if (document.documentElement.scrollTop) {
            currentScroll = document.documentElement.scrollTop;
        } else {
            currentScroll = document.body.scrollTop;
        }
        
        totalHeight = document.body.offsetHeight;
        visibleHeight = document.documentElement.clientHeight;
        
        if (totalHeight <= currentScroll + visibleHeight) {
            infiniteScroll.LoadNextPage();
        }
    }, 100);
    
}());