(function () {

    var i,
        dna = {
            Items: ko.observableArray([]),
            SelectedSpecies: []
        },
        iterate = function (f) {
            
            var i;
            
            for (i = 0; i < dna.Items().length; i++) {
                f(dna.Items()[i]);
            }
        },
        buttons = document.getElementById("buttons"),
        scale = 3,
        dnaItem = function (id, name, coordinates) {
            
            var i, x, y,
                height = 0,
                width = 0;
            
            for (i = 0; i < coordinates.length; i++) {
                x = coordinates[i].x * scale;
                y = coordinates[i].y * scale;
                if (y > height) {
                    height = y;
                }
                if (x > width) {
                    width = x;
                }
            }
            
            height = height + scale;
            width = width + scale;
            
            this.CssClass = ko.observable("");
            this.Id = id;
            this.Name = name;
            this.Coordinates = coordinates;
            this.Height = height;
            this.Width = width;
            this.RenderCoordinates = function (f) {
                
                var i,
                    canvas = document.getElementById(id),
                    plane = canvas.getContext("2d");
                
                plane.fillStyle = "#000";
            
                for (i = 0; i < coordinates.length; i++) {
                    plane.fillRect(coordinates[i].x * scale, coordinates[i].y * scale, scale, scale);
                }
                
                canvas.addEventListener(
                    "mouseup",
                    function () {
                        f(coordinates);
                    },
                    false);
            },
            this.Select = function () {
                this.CssClass("selected");
            },
            this.Deselect = function () {
                this.CssClass("");
            };
        };
    
    // build dna items
    dna.Items.push(new dnaItem("block", "block", [{x: 0, y: 0}, {x: 0, y: 1}, {x: 1, y: 0}, {x: 1, y: 1}]));
    dna.Items.push(new dnaItem("beehive", "beehive", [{x: 0, y: 1}, {x: 1, y: 0}, {x: 1, y: 2}, {x: 2, y: 0}, {x: 2, y: 2}, {x: 3, y: 1}]));
    dna.Items.push(new dnaItem("loaf", "loaf", [{x: 0, y: 1}, {x: 1, y: 0}, {x: 1, y: 2}, {x: 2, y: 0}, {x: 2, y: 3}, {x: 3, y: 1}, {x: 3, y: 2}]));
    dna.Items.push(new dnaItem("boat", "boat", [{x: 0, y: 0}, {x: 0, y: 1}, {x: 1, y: 0}, {x: 1, y: 2}, {x: 2, y: 1}]));
    dna.Items.push(new dnaItem("blinker", "blinker", [{x: 1, y: 0}, {x: 1, y: 1}, {x: 1, y: 2}]));
    dna.Items.push(new dnaItem("toad", "toad", [{x: 0, y: 1}, {x: 1, y: 0}, {x: 1, y: 1}, {x: 2, y: 0}, {x: 2, y: 1}, {x: 3, y: 0}]));
    dna.Items.push(new dnaItem("beacon", "beacon", [{x: 0, y: 0}, {x: 1, y: 0}, {x: 0, y: 1}, {x: 2, y: 3}, {x: 3, y: 2}, {x: 3, y: 3}]));
    dna.Items.push(new dnaItem("pulsar", "pulsar", [{x: 0, y: 2}, {x: 0, y: 3}, {x: 0, y: 4}, {x: 0, y: 8}, {x: 0, y: 9}, {x: 0, y: 10}, {x: 5, y: 2}, {x: 5, y: 3}, {x: 5, y: 4}, {x: 5, y: 8}, {x: 5, y: 9}, {x: 5, y: 10}, {x: 7, y: 2}, {x: 7, y: 3}, {x: 7, y: 4}, {x: 7, y: 8}, {x: 7, y: 9}, {x: 7, y: 10}, {x: 12, y: 2}, {x: 12, y: 3}, {x: 12, y: 4}, {x: 12, y: 8}, {x: 12, y: 9}, {x: 12, y: 10}, {x: 2, y: 0}, {x: 3, y: 0}, {x: 4, y: 0}, {x: 8, y: 0}, {x: 9, y: 0}, {x: 10, y: 0}, {x: 2, y: 5}, {x: 3, y: 5}, {x: 4, y: 5}, {x: 8, y: 5}, {x: 9, y: 5}, {x: 10, y: 5}, {x: 2, y: 7}, {x: 3, y: 7}, {x: 4, y: 7}, {x: 8, y: 7}, {x: 9, y: 7}, {x: 10, y: 7}, {x: 2, y: 12}, {x: 3, y: 12}, {x: 4, y: 12}, {x: 8, y: 12}, {x: 9, y: 12}, {x: 10, y: 12}]));
    dna.Items.push(new dnaItem("glider1", "glider &LowerRightArrow;", [{x: 0, y: 1}, {x: 1, y: 2}, {x: 2, y: 0}, {x: 2, y: 1}, {x: 2, y: 2}]));
    dna.Items.push(new dnaItem("glider2", "glider &UpperLeftArrow;", [{x:0 , y:0}, {x:0 , y:1}, {x:0 , y:2}, {x:1 , y:0}, {x:2 , y:1}]));
    dna.Items.push(new dnaItem("glider3", "glider &LowerLeftArrow;", [{x:0 , y:0}, {x:0 , y:1}, {x:0 , y:2}, {x:1 , y:2}, {x:2 , y:1}]));
    dna.Items.push(new dnaItem("glider4", "glider &UpperRightArrow;", [{x:0 , y:1}, {x:1 , y:0}, {x:2 , y:0}, {x:2 , y:1}, {x:2 , y:2}]));
    dna.Items.push(new dnaItem("lwss1", "lightweight spaceship &LowerRightArrow;", [{x: 0, y: 0}, {x: 0, y: 2}, {x: 1, y: 3}, {x: 2, y: 3}, {x: 3, y: 0}, {x: 3, y: 3}, {x: 4, y: 1}, {x: 4, y: 2}, {x: 4, y: 3}]));
    dna.Items.push(new dnaItem("lwss2", "lightweight spaceship &UpperLeftArrow;", [{x: 0, y: 1}, {x: 0, y: 2}, {x: 0, y: 3}, {x: 1, y: 0}, {x: 1, y: 3}, {x: 2, y: 3}, {x: 3, y: 3}, {x: 4, y: 0}, {x: 4, y: 2}]));
    dna.Items.push(new dnaItem("lwss3", "lightweight spaceship &LowerLeftArrow;", [{x: 0, y: 1}, {x: 0, y: 2}, {x: 0, y: 3}, {x: 0, y: 4}, {x: 1, y: 0}, {x: 1, y: 4}, {x: 2, y: 4}, {x: 3, y: 0}, {x: 3, y: 3}]));
    dna.Items.push(new dnaItem("lwss4", "lightweight spaceship &UpperRightArrow;", [{x: 0, y: 0}, {x: 0, y: 1}, {x: 0, y: 2}, {x: 0, y: 3}, {x: 1, y: 0}, {x: 1, y: 4}, {x: 2, y: 0}, {x: 3, y: 1}, {x: 3, y: 4}]));
    dna.Items.push(new dnaItem("mwss", "mediumweight spaceship", [{x:3, y:0},{x:1, y:1},{x:5, y:1},{x:0, y:2},{x:0, y:3},{x:5, y:3},{x:0, y:4},{x:1, y:4},{x:2, y:4},{x:3, y:4},{x:4, y:4}]));
    dna.Items.push(new dnaItem("hwss", "heavyweight spaceship", [{x:3, y:0}, {x:4, y:0}, {x:1, y:1}, {x:6, y:1}, {x:0, y:2}, {x:0, y:3}, {x:6, y:3}, {x:0, y:4}, {x:1, y:4}, {x:2, y:4}, {x:3, y:4}, {x:4, y:4}, {x:5, y:4}]));
    dna.Items.push(new dnaItem("fpentomino", "fpentomino", [{x: 0, y: 1}, {x: 1, y: 0}, {x: 1, y: 1}, {x: 1, y: 2}, {x: 2, y: 0}]));
    dna.Items.push(new dnaItem("diehard", "diehard", [{x: 0, y: 1}, {x: 1, y: 1}, {x: 1, y: 2}, {x: 5, y: 2}, {x: 6, y: 0}, {x: 6, y: 2}, {x: 7, y: 2}]));
    dna.Items.push(new dnaItem("acorn", "acorn", [{x: 0, y: 2}, {x: 1, y: 0}, {x: 1, y: 2}, {x: 3, y: 1}, {x: 4, y: 2}, {x: 5, y: 2}, {x: 6, y: 2}]));
    dna.Items.push(new dnaItem("glidergun", "glider gun", [{x: 0, y: 4}, {x: 0, y: 5}, {x: 1, y: 4}, {x: 1, y: 5}, {x: 10, y: 4}, {x: 10, y: 5}, {x: 10, y: 6}, {x: 11, y: 3}, {x: 11, y: 7}, {x: 12, y: 2}, {x: 12, y: 8}, {x: 13, y: 2}, {x: 13, y: 8}, {x: 14, y: 5}, {x: 15, y: 3}, {x: 15, y: 7}, {x: 16, y: 4}, {x: 16, y: 5}, {x: 16, y: 6}, {x: 17, y: 5}, {x: 20, y: 2}, {x: 20, y: 3}, {x: 20, y: 4}, {x: 21, y: 2}, {x: 21, y: 3}, {x: 21, y: 4}, {x: 22, y: 1}, {x: 22, y: 5}, {x: 24, y: 0}, {x: 24, y: 1}, {x: 24, y: 5}, {x: 24, y: 6}, {x: 34, y: 2}, {x: 34, y: 3}, {x: 35, y: 2}, {x: 35, y: 3}]));
    dna.Items.push(new dnaItem("infinite1", "infinite 1", [{x: 0, y: 5}, {x: 2, y: 4}, {x: 2, y: 5}, {x: 4, y: 1}, {x: 4, y: 2}, {x: 4, y: 3}, {x: 6, y: 0}, {x: 6, y: 1}, {x: 6, y: 2}, {x: 7, y: 1}]));
    dna.Items.push(new dnaItem("infinite2", "infinite 2", [{x: 0, y: 0}, {x: 0, y: 1}, {x: 0, y: 4}, {x: 1, y: 0}, {x: 1, y: 3}, {x: 2, y: 1}, {x: 2, y: 3}, {x: 2, y: 4}, {x: 3, y: 2}, {x: 4, y: 0}, {x: 4, y: 2}, {x: 4, y: 3}, {x: 4, y: 4}]));
    dna.Items.push(new dnaItem("infinite3", "infinite 3", [{x: 0, y: 0}, {x: 1, y: 0}, {x: 2, y: 0}, {x: 3, y: 0}, {x: 4, y: 0}, {x: 5, y: 0}, {x: 6, y: 0}, {x: 7, y: 0}, {x: 9, y: 0}, {x: 10, y: 0}, {x: 11, y: 0}, {x: 12, y: 0}, {x: 13, y: 0}, {x: 17, y: 0}, {x: 18, y: 0}, {x: 19, y: 0}, {x: 26, y: 0}, {x: 27, y: 0}, {x: 28, y: 0}, {x: 29, y: 0}, {x: 30, y: 0}, {x: 31, y: 0}, {x: 32, y: 0}, {x: 34, y: 0}, {x: 35, y: 0}, {x: 36, y: 0}, {x: 37, y: 0}, {x: 38, y: 0}]));

    // bind dna items to buttons UI
    ko.applyBindings(dna, buttons);
    
    // set up species buttons' behavior
    iterate(function (item) {
        item.RenderCoordinates(
            function (coordinates) {
                dna.SelectedSpecies = coordinates;
                iterate(function (item) { item.Deselect(); });
                item.Select();
            }
        );
    });
    
    // doomsday button click behavior
    document.getElementById("doomsday").addEventListener("mouseup", life.Apocalypse, false);
    
    // universe canvas click behavior
    document.getElementById("universe").addEventListener("mouseup", function (e) {

        var offset = $(this).offset(),
            x = e.clientX - offset.left,
            y = e.clientY - offset.top,
            scale = life.Scale();

        if (x % scale === 0) {
            x = x / scale;
        } else {
            x = (x - x % scale) / scale;
        }

        if (y % scale === 0) {
            y = y / scale;
        } else {
            y = (y - y % scale) / scale;
        }
        
        life.Incarnate(x, y, dna.SelectedSpecies);
    }, false);
}());