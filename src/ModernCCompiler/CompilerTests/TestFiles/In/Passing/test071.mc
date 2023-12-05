struct Test {
	int x = 10;
	bool y = true;
	byte z = '!';
}

int main() {
	Test test = {};
	println test.x;
	println test.y;
	println test.z;
	return 0;
}