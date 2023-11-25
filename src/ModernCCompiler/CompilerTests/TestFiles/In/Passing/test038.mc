int main() {
	int x = 0;
	for int i = 0; i < 5; i++ {
		x += i;
	}

	print x;

	for int i = 1; i < 5; i++ {
		x *= i / i;
	}

	for int i = 1; i < 5; i++ {
		x /= i / i;
	}

	for int i = 0; i < 5; i++ {
		x -= i;
	}

	print x;

	return 0;
}