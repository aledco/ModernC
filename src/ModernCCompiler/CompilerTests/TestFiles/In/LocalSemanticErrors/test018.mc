struct Test {
	int x = 0;
}

int main() {
	Test test;
	f(test);
	return 0;
}

void f(Test test) {
	print test.x;
}