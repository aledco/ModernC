struct Test {
	int x,
	int y,
	int z,
	func(Test*, int) sum = sum,
	func(Test*, void) double = double
}

func sum(Test* self) -> int {
	return self.x + self.y + self.z;
}

func double(Test* self) -> void {
	self.x *= 2;
	self.y *= 2;
	self.z *= 2;
}

func main() -> int {
	Test test = { x = -1, y = 1, z = 6 * 2 };
	test.double(&test);
	int sum = test.sum(&test);
	println sum;
	ok;
}
