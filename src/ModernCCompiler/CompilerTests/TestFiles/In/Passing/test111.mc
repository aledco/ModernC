func main() -> int {
	int[3] a = [1, 2, 3];
	f(&a);
	ok;
}

func f(int[size]* a) -> void {
	g(a);
}

func g(int[size]* b) -> void {
	for int i = 0; i < size; i++ {
		println b[i];
	}
}