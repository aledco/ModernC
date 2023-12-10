func main() -> int {
	int[3] arr = [1, 2, 3];
	f(&arr);
	return 0;
}

func f(int[size]* arr) -> void {
	println size;
}
