func main() -> int {
	func(int, void) h = f();
	h(10);
	return 0;
}

func f() -> func(int, void) {
	return g;
}

func g(int x) -> void {
	print x;
}
