struct Test {
    int x = 5,
    byte y = 'a',
    bool z = true,
}

func main() -> int {
    Test[2][3] array = [
        [
            {}, 
            { x = 2, y = '@', z = false },
        ],
        [
            {}, 
            { x = 3000, z = not true or false and (false or true) },
        ],
        [
            { x = -10 - 2, y = 'F' },
            {},
        ],
    ];

    array[0][0].x--;
    array[1][0].y++;
    array[2][1].z = array[1][0].y < array[0][0].y;
    print array;
    ok;
}
