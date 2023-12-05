struct Test1 {
    int x;
    Test2 test;
}

struct Test2 {
    float y;
    Test3 test;
    byte z;
}

struct Test3 {
    Test1 test;
}

func main() -> int {
    return 0;
}