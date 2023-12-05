func f(int x, int y, int z) -> int {
	return (x + y) * z;
}

func main() -> int {
	int x = 0;
	int y = 0;
	int z = 0;
	println f(x, y, z);
	
	for int i = -15; i <= 15; i++ {
		int x = i;
		int y = i + 2;
		int z = i + 1;
		println f(x, y, z);
	}

	println f(x, y, z);
	println f(f(1, 2, 3), f(-2, 2, 2), f(f(3, 2, -1), f(2, 2, 2), f(3, 3, 3))) * f(10, 40 / 4, 5 * 2);
	return 0;
}