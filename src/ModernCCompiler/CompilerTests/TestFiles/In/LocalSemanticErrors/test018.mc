struct Test {
	int x = 0;
}

func main() -> int {
	Test test;
	f(test);
	return 0;
}

func f(Test test) -> void {
	print test.x;
}