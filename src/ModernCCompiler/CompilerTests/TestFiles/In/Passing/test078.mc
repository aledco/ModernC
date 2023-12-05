int xdef = 10;
byte ydef = 'a';

struct Test {
    int x = xdef;
    byte y = ydef;
}

Test test = {};

int main() {
    println test.x;
    println test.y;
    return 0;
}