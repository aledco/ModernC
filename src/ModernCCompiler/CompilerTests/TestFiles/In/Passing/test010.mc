func main() -> int {
	func(int) g = f;
	print g();
	return 0;
}

func f() -> int {
	return 10;
}