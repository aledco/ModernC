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
	test->double();
	Test* p1 = &test;
	Test** p2 = &p1;
	Test*** p3 = &p2;
	Test**** p4 = &p3;
	Test***** p5 = &p4;
	int sum = p5->sum();
	println sum;
	ok;
}
