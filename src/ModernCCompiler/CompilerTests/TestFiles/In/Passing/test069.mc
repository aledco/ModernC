struct Test {
    int x = 0;
    func(void) increment;
}

void increment() {
    test.x++;
}

Test test;

int main() {
    test.increment = increment;
    for int i = 0; i < 69; i++ {
            test.increment();
    }

    print test.x;
    return 0;
}