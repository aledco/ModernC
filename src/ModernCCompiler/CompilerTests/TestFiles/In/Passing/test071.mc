struct Test {
	int x = 10,
	bool y = true,
	byte z = '!',
}

func main() -> int {
	Test test = {};
	println test.x;
	println test.y;
	println test.z;
	return 0;
}