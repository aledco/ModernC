struct Test {
	int x = 0;
}

int main() {
	Test test = f();
	print test.x;
	return 0;
}

Test f() {
	Test test;
	test.x = 10;
	return test;
}