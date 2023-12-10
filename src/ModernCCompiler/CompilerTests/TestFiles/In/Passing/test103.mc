struct Test {
	int[3] data,
	func(Test*, void) decrementAll = decrementAll,
	func(Test*, int) product = product,
}

func decrementAll(Test* self) -> void {
	for int i = 0; i < 3; i++ {
		self.data[i]--;
	}
}

func product(Test* self) -> int {
	int product = 1;
	for int i = 0; i < 3; i++ {
		product *= self.data[i];
	}

	return product;
}

func main() -> int {
	Test test = { data = [-1, 0, -2] };

	println test->product();
	do {
		test->decrementAll();
		println test->product();
	} while (test->product() > -15);
	
	return 0;
}