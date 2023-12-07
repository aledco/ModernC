struct Test {
    int x = -1
}

func main() -> int {
    Test test = {};
    Test* ptr = &test;
    println ptr.x;
    ok;
}