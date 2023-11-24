int main() {
	func(void, int) h = f();
	h(10);
	return 0;
}

func(void, int) f() {
	return g;
}

void g(int x) {
	print x;
}
