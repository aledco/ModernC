func main() -> int {
	int[2][2] a1 = [[1, 2], [3, 4]];
	int sum1 = f(&a1);
	println sum1;

	int[2][3] a2 = [[1, 2], [3, 4], [5, 6]];
	int sum2 = f(&a2);
	println sum2;

	return 0;
}

func f(int[2][s]* a) -> int {
	int sum = 0;
	for int i = 0; i < s; i++ {
		for int j = 0; j < 2; j++ {
			sum += a[i][j];
		}
	}

	return sum;
}