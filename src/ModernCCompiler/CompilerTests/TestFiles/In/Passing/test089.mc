struct Test {
	int x,
	int* p
}

func main() -> int {
	int x = 10;
	Test test = { x = x, p = &x };
	println test.x;
	println *test.p;
	return 0;
}
