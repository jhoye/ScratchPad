(function () {

    var species = "block",
        doomsday = $("#doomsday"),
        universe = $("#universe"),
        sprites = $("#sprites");

    $(".buttons a").click(function () {
        $(this).siblings("a.selected").removeClass("selected");
        species = $(this).attr("class");
        $(this).addClass("selected");
    });

    doomsday.click(life.Apocalypse);

    universe.click(function (e) {

        var offset = $(this).offset(),
            x = e.clientX - offset.left,
            y = e.clientY - offset.top,
            dna = [],
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

        switch (species) {
        case "block":
            dna = [
                {x: 0, y: 0},
                {x: 0, y: 1},
                {x: 1, y: 0},
                {x: 1, y: 1}];
            break;

        case "beehive":
            dna = [
                {x: 0, y: 1},
                {x: 1, y: 0},
                {x: 1, y: 2},
                {x: 2, y: 0},
                {x: 2, y: 2},
                {x: 3, y: 1}];
            break;

        case "loaf":
            dna = [
                {x: 0, y: 1},
                {x: 1, y: 0},
                {x: 1, y: 2},
                {x: 2, y: 0},
                {x: 2, y: 3},
                {x: 3, y: 1},
                {x: 3, y: 2}];
            break;

        case "boat":
            dna = [
                {x: 0, y: 0},
                {x: 0, y: 1},
                {x: 1, y: 0},
                {x: 1, y: 2},
                {x: 2, y: 1}];
            break;

        case "blinker":
            dna = [
                {x: 1, y: 0},
                {x: 1, y: 1},
                {x: 1, y: 2}];
            break;

        case "toad":
            dna = [
                {x: 0, y: 1},
                {x: 1, y: 0},
                {x: 1, y: 1},
                {x: 2, y: 0},
                {x: 2, y: 1},
                {x: 3, y: 0}];
            break;

        case "beacon":
            dna = [
                {x: 0, y: 0},
                {x: 1, y: 0},
                {x: 0, y: 1},
                {x: 2, y: 3},
                {x: 3, y: 2},
                {x: 3, y: 3}];
            break;

        case "pulsar":
            dna = [
                {x: 0, y: 2},
                {x: 0, y: 3},
                {x: 0, y: 4},
                {x: 0, y: 8},
                {x: 0, y: 9},
                {x: 0, y: 10},
                {x: 5, y: 2},
                {x: 5, y: 3},
                {x: 5, y: 4},
                {x: 5, y: 8},
                {x: 5, y: 9},
                {x: 5, y: 10},
                {x: 7, y: 2},
                {x: 7, y: 3},
                {x: 7, y: 4},
                {x: 7, y: 8},
                {x: 7, y: 9},
                {x: 7, y: 10},
                {x: 12, y: 2},
                {x: 12, y: 3},
                {x: 12, y: 4},
                {x: 12, y: 8},
                {x: 12, y: 9},
                {x: 12, y: 10},
                {x: 2, y: 0},
                {x: 3, y: 0},
                {x: 4, y: 0},
                {x: 8, y: 0},
                {x: 9, y: 0},
                {x: 10, y: 0},
                {x: 2, y: 5},
                {x: 3, y: 5},
                {x: 4, y: 5},
                {x: 8, y: 5},
                {x: 9, y: 5},
                {x: 10, y: 5},
                {x: 2, y: 7},
                {x: 3, y: 7},
                {x: 4, y: 7},
                {x: 8, y: 7},
                {x: 9, y: 7},
                {x: 10, y: 7},
                {x: 2, y: 12},
                {x: 3, y: 12},
                {x: 4, y: 12},
                {x: 8, y: 12},
                {x: 9, y: 12},
                {x: 10, y: 12}];
            break;

        case "glider1":
            dna = [
                {x: 0, y: 1},
                {x: 1, y: 2},
                {x: 2, y: 0},
                {x: 2, y: 1},
                {x: 2, y: 2}];
            break;

        case "glider2":
            dna = [
                {x:0 , y:0},
                {x:0 , y:1},
                {x:0 , y:2},
                {x:1 , y:0},
                {x:2 , y:1}];
            break;

        case "glider3":
            dna = [
                {x:0 , y:0},
                {x:0 , y:1},
                {x:0 , y:2},
                {x:1 , y:2},
                {x:2 , y:1}];
            break;

        case "glider4":
            dna = [
                {x:0 , y:1},
                {x:1 , y:0},
                {x:2 , y:0},
                {x:2 , y:1},
                {x:2 , y:2}];
            break;

        case "lwss1":
            dna = [
                {x: 0, y: 0},
                {x: 0, y: 2},
                {x: 1, y: 3},
                {x: 2, y: 3},
                {x: 3, y: 0},
                {x: 3, y: 3},
                {x: 4, y: 1},
                {x: 4, y: 2},
                {x: 4, y: 3}];
            break;

        case "lwss2":
            dna = [
                {x: 0, y: 1},
                {x: 0, y: 2},
                {x: 0, y: 3},
                {x: 1, y: 0},
                {x: 1, y: 3},
                {x: 2, y: 3},
                {x: 3, y: 3},
                {x: 4, y: 0},
                {x: 4, y: 2}];
            break;

        case "lwss3":
            dna = [
                {x: 0, y: 1},
                {x: 0, y: 2},
                {x: 0, y: 3},
                {x: 0, y: 4},
                {x: 1, y: 0},
                {x: 1, y: 4},
                {x: 2, y: 4},
                {x: 3, y: 0},
                {x: 3, y: 3}];
            break;

        case "lwss4":
            dna = [
                {x: 0, y: 0},
                {x: 0, y: 1},
                {x: 0, y: 2},
                {x: 0, y: 3},
                {x: 1, y: 0},
                {x: 1, y: 4},
                {x: 2, y: 0},
                {x: 3, y: 1},
                {x: 3, y: 4}];
            break;

        case "fpentomino":
            dna = [
                {x: 0, y: 1},
                {x: 1, y: 0},
                {x: 1, y: 1},
                {x: 1, y: 2},
                {x: 2, y: 0}];
            break;

        case "diehard":
            dna = [
                {x: 0, y: 1},
                {x: 1, y: 1},
                {x: 1, y: 2},
                {x: 5, y: 2},
                {x: 6, y: 0},
                {x: 6, y: 2},
                {x: 7, y: 2}];
            break;

        case "acorn":
            dna = [
                {x: 0, y: 2},
                {x: 1, y: 0},
                {x: 1, y: 2},
                {x: 3, y: 1},
                {x: 4, y: 2},
                {x: 5, y: 2},
                {x: 6, y: 2}];
            break;

        case "glidergun":
            dna = [
                {x: 0, y: 4},
                {x: 0, y: 5},
                {x: 1, y: 4},
                {x: 1, y: 5},
                {x: 10, y: 4},
                {x: 10, y: 5},
                {x: 10, y: 6},
                {x: 11, y: 3},
                {x: 11, y: 7},
                {x: 12, y: 2},
                {x: 12, y: 8},
                {x: 13, y: 2},
                {x: 13, y: 8},
                {x: 14, y: 5},
                {x: 15, y: 3},
                {x: 15, y: 7},
                {x: 16, y: 4},
                {x: 16, y: 5},
                {x: 16, y: 6},
                {x: 17, y: 5},
                {x: 20, y: 2},
                {x: 20, y: 3},
                {x: 20, y: 4},
                {x: 21, y: 2},
                {x: 21, y: 3},
                {x: 21, y: 4},
                {x: 22, y: 1},
                {x: 22, y: 5},
                {x: 24, y: 0},
                {x: 24, y: 1},
                {x: 24, y: 5},
                {x: 24, y: 6},
                {x: 34, y: 2},
                {x: 34, y: 3},
                {x: 35, y: 2},
                {x: 35, y: 3}];
            break;

        case "infinite1":
            dna = [
                {x: 0, y: 5},
                {x: 2, y: 4},
                {x: 2, y: 5},
                {x: 4, y: 1},
                {x: 4, y: 2},
                {x: 4, y: 3},
                {x: 6, y: 0},
                {x: 6, y: 1},
                {x: 6, y: 2},
                {x: 7, y: 1}];
            break;

        case "infinite2":
            dna = [
                {x: 0, y: 0},
                {x: 0, y: 1},
                {x: 0, y: 4},
                {x: 1, y: 0},
                {x: 1, y: 3},
                {x: 2, y: 1},
                {x: 2, y: 3},
                {x: 2, y: 4},
                {x: 3, y: 2},
                {x: 4, y: 0},
                {x: 4, y: 2},
                {x: 4, y: 3},
                {x: 4, y: 4}];
            break;

        case "infinite3":
            dna = [
                {x: 0, y: 0},
                {x: 1, y: 0},
                {x: 2, y: 0},
                {x: 3, y: 0},
                {x: 4, y: 0},
                {x: 5, y: 0},
                {x: 6, y: 0},
                {x: 7, y: 0},
                {x: 9, y: 0},
                {x: 10, y: 0},
                {x: 11, y: 0},
                {x: 12, y: 0},
                {x: 13, y: 0},
                {x: 17, y: 0},
                {x: 18, y: 0},
                {x: 19, y: 0},
                {x: 26, y: 0},
                {x: 27, y: 0},
                {x: 28, y: 0},
                {x: 29, y: 0},
                {x: 30, y: 0},
                {x: 31, y: 0},
                {x: 32, y: 0},
                {x: 34, y: 0},
                {x: 35, y: 0},
                {x: 36, y: 0},
                {x: 37, y: 0},
                {x: 38, y: 0}];
            break;

        default:
            return;
        }

        life.Incarnate(x, y, dna);
    });
}());