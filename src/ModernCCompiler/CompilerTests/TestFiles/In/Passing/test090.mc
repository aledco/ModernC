struct Test {
    int x = -1
}

func main() -> int {
    Test test = {};
    Test* ptr = &test;
    print ptr.x;
    return 0;
}