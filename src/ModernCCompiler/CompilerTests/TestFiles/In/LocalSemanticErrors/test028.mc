func f() -> int* {
	int x = 0;
	return &x;
}

func main() -> int {
	return *f();
}