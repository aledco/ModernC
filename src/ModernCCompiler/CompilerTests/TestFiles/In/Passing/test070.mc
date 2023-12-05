struct Test {
    int x;
    byte y;
}

int main() {
    Test test = { x = 5, y = 'd' };
    println test.x;
    println test.y;
    return 0;
}