func main() -> int {
    func(int)* fptr = &f;
    int x = (*fptr)();
    print x;
    return 0;
}

func f() -> int {
    return 12;
}