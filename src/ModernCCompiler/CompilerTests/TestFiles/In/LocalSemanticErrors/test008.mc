func main() -> int {
	func(int, int) g = f;
	g();
	return 0;
}

func f() -> int {
	print 0;
	return 0;
}