int xDefault = 10;
byte yDefault = 'a';

struct Test {
    int x = xDefault;
    byte y = yDefault;
}

int main() {
    Test test = {};
    println test.x;
    println test.y;
    return 0;
}