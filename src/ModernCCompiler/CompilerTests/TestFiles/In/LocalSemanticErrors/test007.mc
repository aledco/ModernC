func main() -> int {
	func(int) g = f;
	return g();
}

func f(int x) -> int {
	print x;
	return 0;
}