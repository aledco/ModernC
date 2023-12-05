int x = 0;

func main() -> int {
	println x;
	while x < 10 {
		x++;
	}

	int y = f();
	println x == y;
	println x;
	return 0;
}

func f() -> int {
	println x;
	x *= 2;
	return x;
}