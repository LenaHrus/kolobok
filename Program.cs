var width = 10;
var height = 10;

var map = new byte[width, height];
for (var i = 0; i < map.GetLength(0); i++)
{
    for (var j = 0; j < map.GetLength(1); j++)
    {
        map[i, j] = 0;
    }
}

void writeMap(byte[,] m) {
    for (var j = 0; j < m.GetLength(1); j++)
    {
        for (var i = 0; i < m.GetLength(0); i++)
        {
            var s = " ";
            if (m[i, j] == 1)
            {
                s = "F";
            } else if (m[i, j] == 2)
            {
                s = ".";
            }
            Console.Write(s);
        }
        Console.WriteLine();
    }
}

map[5, 7] = 1;
map[3, 2] = 1;
map[4, 5] = 1;
map[9, 0] = 1;
map[1, 8] = 1;
map[5, 1] = 1;
map[8, 6] = 1;
map[7, 3] = 1;
map[6, 0] = 1;
map[0, 8] = 1;
map[0, 0] = 2;
writeMap(map);


var x = 0;
var y = 0;
var a = 0;
var b = 0;
while (true) {
    Console.WriteLine("Управление - стрелками. Любая другая кнопка - выход.");
    Console.SetCursorPosition(0,0);
    var key = Console.ReadKey(true);
    var i = 0;
    switch (key.Key)
    {
        case ConsoleKey.DownArrow:
            i = 3;
            break;
        case ConsoleKey.UpArrow:
           i = 1;
            break;
        case ConsoleKey.RightArrow:
            i = 2;
            break;
        case ConsoleKey.LeftArrow:
            i = 4;
            break;
    }

    if (i == 0) {
        break;
    }
    
    if (i == 1) {
        a = x;
        b = y - 1;
    }
    if (i == 2) {
        a = x + 1;
        b = y;
    }
    if (i == 3) {
        a = x;
        b = y + 1;
    }
    if (i == 4) {
        a = x - 1;
        b = y;
    }

    if (a>=0 && b>=0 && a < width && b < height && map[a, b] == 0) {
        map[x, y] = 0;
        map[a, b] = 2;
        x = a;
        y = b;
        writeMap(map);
    }
    else {
        Console.WriteLine("Невозможно придти в эту точку - там дерево!");
    }
}

