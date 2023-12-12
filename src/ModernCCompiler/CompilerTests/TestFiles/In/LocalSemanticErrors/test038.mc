func main() -> int {
	int[3] a = [1, 2, 3];
	f(&a);
	ok;
}

func f(int[size]* a) -> void {
	g(a);
}

func g(int[3]* b) -> void {
	for int i = 0; i < 3; i++ {
		println b[i];
	}
}