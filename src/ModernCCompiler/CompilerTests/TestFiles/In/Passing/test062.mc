int x = 0;

int main() {
	println x;
	while x < 10 {
		x++;
	}

	int y = f();
	println x == y;
	println x;
	return 0;
}

int f() {
	println x;
	x *= 2;
	return x;
}