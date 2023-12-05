struct Test {
    int x;
    byte y;
}

func main() -> int {
    Test test = { x = 5, y = 'd' };
    println test.x;
    println test.y;
    return 0;
}