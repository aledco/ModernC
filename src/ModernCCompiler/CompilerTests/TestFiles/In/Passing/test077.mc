int xDefault = 10;
byte yDefault = 'a';

struct Test {
    int x = xDefault;
    byte y = yDefault;
}

func main() -> int {
    Test test = {};
    println test.x;
    println test.y;
    return 0;
}