struct Test {
	int x,
	int y,
	int z
}

func main() -> int {
	Test test = { x = -1, y = 1, z = 6 * 2 };
	int sum = f(&test);
	println sum;
	ok;
}

func f(Test* test) -> int {
	return test.x + test.y + test.z;
}