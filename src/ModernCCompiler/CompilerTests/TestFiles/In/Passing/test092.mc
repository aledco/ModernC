struct Test {
     int x = 0
}

func main() -> int {
    Test test = {};
    Test* ptr = &test;
    ptr.x = -10;
    println ptr.x;
    ok;
}