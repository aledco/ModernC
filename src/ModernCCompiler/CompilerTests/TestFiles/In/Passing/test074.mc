struct Test {
    int x;
    bool y;
    byte z = '$';
    float a = -1.1;
}

func main() -> int {
    Test test = { x = 10, y = true, a = -4.4 };
    println test;
    return 0;
}