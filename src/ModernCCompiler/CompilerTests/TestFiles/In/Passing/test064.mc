bool cond = true;

int main() {
    int x;
    if cond {
        x = f();
    } else {
        x = g();
    }

    print x;
    return 0;
}

int f() {
    return -1;
}

int g() {
    return 1;
}