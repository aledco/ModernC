struct Test {
	int x,
	bool y = false,
	byte z,
}

func main() -> int {
	Test test = { x = 0, z = 0, };
	if test.y {
		test.x = 10;
		test.z = 'b';
	} elif not test.y {
		test.x = 20;
		test.z = 'z';
	}

	println test.x;
	println test.z;
	return 0;
}