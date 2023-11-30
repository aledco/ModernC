int main() {
    int x = f()();
    print x;
    return 0;
}

func(int) f() {
    return g;
}

int g() {
    return 10;
}