bool cond = true;

func main() -> int {
    int x;
    if cond {
        x = f();
    } else {
        x = g();
    }

    print x;
    return 0;
}

func f() -> int {
    return -1;
}

func g() -> int {
    return 1;
}