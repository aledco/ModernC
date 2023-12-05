struct Test {
	int x = 0;
}

func main() -> int {
	Test test = f();
	print test.x;
	return 0;
}

func f() -> Test {
	Test test;
	test.x = 10;
	return test;
}