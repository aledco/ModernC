struct Test {
    int x = 5,
    byte y = 'a',
    bool z = true,
}

func main() -> int {
    Test[3] array = [{}, {}, {}];
    array[0].x--;
    array[1].y++;
    array[2].z = array[1].y < array[0].y;
    print array;
    ok;
}
