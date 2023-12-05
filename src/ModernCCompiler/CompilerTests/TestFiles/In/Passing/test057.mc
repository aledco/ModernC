func main() -> int {
    int x = f()();
    print x;
    return 0;
}

func f() -> func(int)  {
    return g;
}

func g() -> int {
    return 10;
}