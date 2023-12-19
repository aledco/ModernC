struct InnerTest {
    int n = 100,
    bool g = not true
}

struct Test {
    int x = 0,
    byte y = '?',
    InnerTest innerTest
}

func main() -> int {
    Test test = { innerTest = {}};
    println test;
    return 0;
}