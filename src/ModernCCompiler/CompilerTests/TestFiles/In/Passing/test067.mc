Test test;

struct Test {
    int x = 5;
}

int main() {
    println test.x;
    test.x = 12;
    println test.x;
    return 0;
}