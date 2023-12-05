func main() -> int {
    println factorial(5);
    return 0;
}

func factorial(int n) -> int {
    if n <= 1 {
        return 1;
    }

    return n * factorial(n - 1);
}