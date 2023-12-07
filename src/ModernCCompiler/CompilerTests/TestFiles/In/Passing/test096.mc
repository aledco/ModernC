struct Test {
	int x,
	int y,
	int z,
	func(Test*, int) sum = sum,
}

func sum(Test* self) -> int {
	return self.x + self.y + self.z;
}

func main() -> int {
	Test test = { x = -1, y = 1, z = 6 * 2 };
	int sum = test->sum();
	println sum;
	ok;
}
