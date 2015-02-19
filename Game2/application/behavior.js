(function () {
    
    /*
        $.cookie("grid", grid);
        $.removeCookie("grid");
        $.cookie("grid");
    */
    
    var chkShowHints = $("#chkShowHints"),
        toggleHints = function () {
            if (chkShowHints.is(":checked")) {
                sudoku.BuildHints();
            } else {
                sudoku.RemoveHints();
            }
        },
        tr, td, html = '';
    
    chkShowHints.click(toggleHints);
    
    $("#chkLockValues").click(function () {
        
        if ($(this).is(":checked")) {
            sudoku.LockValues();
        } else {
            sudoku.UnlockValues();
        }
    });
    
    for (tr = 0; tr < 9; tr++) {
        html += '<tr>';
        for(td = 0; td < 9; td++) {
            html += '<td><input type="text" maxlength="1" /></td>';
        }
        html += '</tr>';
    }
    
    $("tbody").append(html);
    
    $("tr").each(function (y) {
        
        var row = [];
        
        $(this).find('input[type="text"]').each(function (x) {
            
            var input = $(this),
                cell = sudoku.NewCell(
                    //x, y
                    x, y,
                    // select
                    function () {
                        input.select();
                    },
                    // getValue
                    function () {
                        return new Number(input.val()).valueOf();
                    },
                    // addSquareError
                    function () {
                        input.addClass("invalid-square");
                    },
                    // addRowError
                    function () {
                        input.addClass("invalid-row");
                    },
                    // addColumnError
                    function () {
                        input.addClass("invalid-column");
                    },
                    // removeSquareError
                    function () {
                        input.removeClass("invalid-square");
                    },
                    // removeRowError
                    function () {
                        input.removeClass("invalid-row");
                    },
                    // removeColumnError
                    function () {
                        input.removeClass("invalid-column");
                    },
                    // buildHint
                    function () {
                        
                        var i,
                            possibleValues,
                            html = '';
                        
                        if (input.val() === "") {
                            
                            possibleValues = sudoku.GetPossibleValues(x, y);
                            
                            for (i = 0; i < 9; i++) {
                                html += '<small>' + (possibleValues[i] === 0 ? '&nbsp;' : possibleValues[i]) + '</small>'
                            }
                            
                            input.next("div.hint").remove();
                            input.after('<div class="hint"><span>' + html + '</span></div>');
                        }
                    },
                    // removeHint
                    function () {
                        input.next("div.hint").remove();
                    },
                    // lockValue
                    function () {
                        if (input.val() !== "") {
                            input.attr("readonly", "readonly").addClass("locked");
                        }
                    },
                    // unlockValue
                    function () {
                        input.removeAttr("readonly").removeClass("locked");
                    });
            
            input
                .focus(function () {
                    input.next("div.hint").hide();
                })
                .blur(function () {
                    if (input.val() === "") {
                        input.next("div.hint").show();
                    }
                })
                .numeric()
                .keydown(function (e) {
                    if (e.which === 48) { // 0
                        e.preventDefault();
                    }
                })
                .keyup(function (e) {
                    switch (e.which) {
                        case 37: // left
                            sudoku.MoveCursorLeftOf(cell);
                            break;
                        case 38: // up
                            sudoku.MoveCursorAbove(cell);
                            break;
                        case 39: // right
                            sudoku.MoveCursorRightOf(cell);
                            break;
                        case 40: // down
                            sudoku.MoveCursorBelow(cell);
                            break;
                        case 49: // 1
                        case 50: // 2
                        case 51: // 3
                        case 52: // 4
                        case 53: // 5
                        case 54: // 6
                        case 55: // 7
                        case 56: // 8
                        case 57: // 9
                        case 8: // delete
                            sudoku.Validate(cell);
                            toggleHints();
                            break;
                    }
                });
            
            row.push(cell);
        });
        
        sudoku.AddToGrid(row);
    });
    
}());