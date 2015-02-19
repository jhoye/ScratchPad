var sudoku = (function () {
    
    var app = {},
        grid = [],
        iterateGrid = function (functionName) {
            
            var x, y;
            
            for (y = 0; y < 9; y++) {
                for (x = 0; x < 9; x++) {
                    grid[y][x][functionName]();
                }
            }
        },
        getGrid = function () {
            return grid;
        },
        setGrid = function (obj) {
            grid = obj;
        },
        getCell = function (x, y) {
            return grid[y][x];
        },
        leftOf = function (cell) {
            return getCell((cell.X - 1 < 0 ? 8 : cell.X - 1), cell.Y);
        },
        above = function (cell) {
            return getCell(cell.X, (cell.Y - 1 < 0 ? 8 : cell.Y - 1));
        },
        rightOf = function (cell) {
            return getCell((cell.X + 1 > 8 ? 0 : cell.X + 1), cell.Y);
        },
        below = function (cell) {
            return getCell(cell.X, (cell.Y + 1 > 8 ? 0 : cell.Y + 1));
        },
        getSquare = function (cell) {
            
            var xi, yi,
                x = (cell.X - cell.X % 3),
                y = (cell.Y - cell.Y % 3),
                square = [];
            
            for (xi = 0; xi < 3; xi++) {
                for (yi = 0; yi < 3; yi++) {
                    square.push(getCell(x + xi, y + yi));
                }
            }
            
            return square;
        },
        getRow = function (cell) {
            
            var x,
                row = [];
            
            for (x = 0; x < 9; x++) {
                row.push(getCell(x, cell.Y));
            }
            
            return row;
        }
        getColumn = function (cell) {
            
            var y,
                column = [];
            
            for (y = 0; y < 9; y++) {
                column.push(getCell(cell.X, y));
            }
            
            return column;
        },
        areCellsValid = function (cells) {
            
            var value, values = [];
            
            for (i = 0; i < 9; i++)
            {
                value = cells[i].GetValue();
                
                if (value !== 0 && values.indexOf(value) !== -1) {
                    return false;
                }
                
                values.push(value);
            }
            
            return true;
        },
        removeInvalidValues = function(possibleValues, cells) {
            
            var i, index;
            
            for (i = 0; i < 9; i++)
            {
                index = possibleValues.indexOf(cells[i].GetValue());
                
                if (index !== -1) {
                    possibleValues[index] = 0;
                }
            }
            
            return possibleValues;
        };
    
    app.AddToGrid = function (row) {
        grid.push(row);
    };
    
    app.NewCell = function (x, y, select, getValue, addSquareError, addRowError, addColumnError, removeSquareError, removeRowError, removeColumnError, buildHint, removeHint, lockValue, unlockValue)
    {
        return {
            X: x,
            Y: y,
            Select: select,
            GetValue: getValue,
            AddSquareError: addSquareError,
            AddRowError: addRowError,
            AddColumnError: addColumnError,
            RemoveSquareError: removeSquareError,
            RemoveRowError: removeRowError,
            RemoveColumnError: removeColumnError,
            BuildHint: buildHint,
            RemoveHint: removeHint,
            LockValue: lockValue,
            UnlockValue: unlockValue
        };
    };
    
    app.MoveCursorLeftOf = function (cell) {
        return leftOf(cell).Select();
    };
    
    app.MoveCursorAbove = function (cell) {
        return above(cell).Select();
    };
    
    app.MoveCursorRightOf = function (cell) {
        return rightOf(cell).Select();
    };
    
    app.MoveCursorBelow = function (cell) {
        return below(cell).Select();
    };
        
    app.Validate = function (cell) {
        
        var i,
            square = getSquare(cell),
            row = getRow(cell),
            column = getColumn(cell),
            isSquareValid = areCellsValid(square),
            isRowValid = areCellsValid(row),
            isColumnValid = areCellsValid(column);
            
        for (i = 0; i < 9; i++) {
            
            if (isSquareValid) {
                square[i].RemoveSquareError();
            } else {
                square[i].AddSquareError();
            }
            
            if (isRowValid) {
                row[i].RemoveRowError();
            } else {
                row[i].AddRowError();
            }
            
            if (isColumnValid) {
                column[i].RemoveColumnError();
            } else {
                column[i].AddColumnError();
            }
        }
    }
    
    app.GetPossibleValues = function (x, y) {
            
        var cell = getCell(x, y),
            possibleValues = [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ];
            
        possibleValues = removeInvalidValues(possibleValues, getSquare(cell));
        possibleValues = removeInvalidValues(possibleValues, getRow(cell));
        possibleValues = removeInvalidValues(possibleValues, getColumn(cell));
        
        return possibleValues;
    };
    
    app.BuildHints = function () {
        iterateGrid("BuildHint");
    };
    
    app.RemoveHints = function () {
        iterateGrid("RemoveHint");
    };
    
    app.LockValues = function () {
        iterateGrid("LockValue");
    };
    
    app.UnlockValues = function () {
        iterateGrid("UnlockValue");
    };
    
    return app;

}());