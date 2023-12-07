Test test;

func main() -> int {
    printTest();

    if test.b1 {
        test.x *= 10;
        test.y = -test.y;
    } elif test.b2 {
        test.x /= 10;
    }

    printTest();
    return 0;
}

func printTest() -> void {
    println test.x;
    println test.y;
}

struct Test {
    int x = 5,
    float y = -2.2,
    bool b1 = true,
    bool b2 = false,
}