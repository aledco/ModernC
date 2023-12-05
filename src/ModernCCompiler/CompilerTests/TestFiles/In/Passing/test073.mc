struct Test {
	int x;
	bool y;
}

Test globalTest = {
	x = 0,
	y = true,
};

int main() {
	if globalTest.y {
		globalTest.x = 15;
	} else {
		globalTest.x = 20;
	}

	println globalTest.x;
	return 0;
}
