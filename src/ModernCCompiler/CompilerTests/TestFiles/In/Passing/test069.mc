struct Test {
    int x = 0,
    func(void) increment,
}

func increment() -> void {
    test.x++;
}

Test test;

func main() -> int {
    test.increment = increment;
    for int i = 0; i < 69; i++ {
            test.increment();
    }

    print test.x;
    return 0;
}