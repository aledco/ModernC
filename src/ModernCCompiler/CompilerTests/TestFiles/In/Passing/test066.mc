struct Test {
    int x = 5;
}

int main() {
    Test test;
    println test.x;
    test.x = 12;
    println test.x;
    return 0;
}