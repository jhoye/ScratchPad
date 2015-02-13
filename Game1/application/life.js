var life = (function () {

    var app = {},
        universe = {
            plane: null,
            width: 0,
            height: 0
        },
        grid = [],
        table = {
            cycle: null,
            beings: null,
            births: null,
            deaths: null,
            isLiving: null
        },
        scale = 1,
        cycle = 0,
        beings = 0,
        births = 0,
        deaths = 0,
        isLiving = false,
        interval = null;

    app.Trace = function () {
        table.cycle.text(cycle);
        table.beings.text(beings);
        table.births.text(births);
        table.deaths.text(deaths);
        table.isLiving.text(isLiving ? "yes" : "no");
    };

    app.Scale = function () {

        return scale;
    };

    app.Iterate = function (f) {

        var x, y;

        for (x = 0; x <= universe.width; x = x + 1) {

            if (typeof grid[x] === "undefined") {
                grid[x] = [];
            }

            for (y = 0; y <= universe.height; y = y + 1) {
                f(x, y);
            }
        }
    };

    app.GetNeighbor = function (x, y) {

        if (x < 0) {
            x = universe.width;
        }

        if (x > universe.width) {
            x = 0;
        }

        if (y < 0) {
            y = universe.height;
        }

        if (y > universe.height) {
            y = 0;
        }

        return grid[x][y];
    };

    app.GetNeighbors = function (x, y) {

        var n = 0;

        n += app.GetNeighbor(x + 1, y).is ? 1 : 0;
        n += app.GetNeighbor(x + 1, y + 1).is ? 1 : 0;
        n += app.GetNeighbor(x + 1, y - 1).is ? 1 : 0;
        n += app.GetNeighbor(x, y + 1).is ? 1 : 0;
        n += app.GetNeighbor(x, y - 1).is ? 1 : 0;
        n += app.GetNeighbor(x - 1, y).is ? 1 : 0;
        n += app.GetNeighbor(x - 1, y + 1).is ? 1 : 0;
        n += app.GetNeighbor(x - 1, y - 1).is ? 1 : 0;

        grid[x][y].neighbors = n;
    };

    app.Evolve = function (x, y) {

        var g = grid[x][y],
            n = g.neighbors;

        universe.plane.fillStyle = g.is ? "#000" : "#fff";

        universe.plane.fillRect(x * scale, y * scale, scale, scale);

        if (g.is) {

            // with two or three neighbors survives
            // with four or more neighbors dies from overpopulation
            // with one neighbor or none dies from isolation
            g.is = n === 2 || n === 3;
            deaths += (n >= 4 || n <= 1) ? 1 : 0;

        } else {

            // empty cell with exactly three neighbors is born
            g.is = n === 3;
            births += (n === 3) ? 1 : 0;
        }

        beings += g.is ? 1 : 0;
    };

    app.Live = function () {

        var i = interval.val();

        beings = 0;
        births = 0;
        deaths = 0;

        app.Iterate(app.GetNeighbors);

        app.Iterate(app.Evolve);

        if (deaths > 0 || births > 0) {
            isLiving = true;
            cycle = cycle + 1;
        } else {
            isLiving = false;
        }

        app.Trace();

        if (isLiving) {
            window.setTimeout(app.Live, i);
        }
    };

    app.Incarnate = function (x, y, dna) {

        var i;

        for (i = 0; i < dna.length; i = i + 1) {
            app.GetNeighbor(x + dna[i].x, y + dna[i].y).is = true;
        }

        if (!isLiving) {
            app.Live();
        }
    };
    
    app.Apocalypse = function () {
        
        app.Iterate(function (x, y) {
            
            var g = grid[x][y];
            
            g.is = false;
            g.neigbors = 0;
        });

        cycle = 0;
        beings = 0;
        births = 0;
        deaths = 0;
        isLiving = false;

        app.Trace();
    };

    app.Create = function () {

        var canvas = document.getElementById("universe"),
            width,
            height,
            x,
            y;

        width = new Number(canvas.getAttribute("width")).valueOf();
        height = new Number(canvas.getAttribute("height")).valueOf();
        scale = width / 100;

        universe.plane = canvas.getContext("2d");
        universe.width = width / scale - 1;
        universe.height = height / scale - 1;

        interval = $("#interval");

        app.Iterate(function (x, y) {
            grid[x][y] = {
                is: false,
                neighbors: 0
            };
        });

        table.cycle = $("#tdCycle");
        table.beings = $("#tdBeings");
        table.births = $("#tdBirths");
        table.deaths = $("#tdDeaths");
        table.isLiving = $("#tdIsLiving");

        app.Live();
    };

    return app;

}());