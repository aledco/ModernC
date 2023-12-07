func main() -> int {
    byte x = 'g';
    byte* p = &x;
    println *p;
    f(p);
    println *p;
    return 0;
}

func f(byte* ptr) -> void {
    println *ptr;
    *ptr = 'f';
}