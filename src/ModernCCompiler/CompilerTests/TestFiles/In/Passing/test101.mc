func main() -> int {
	int[3] a = [1, 2, 3];
	int sum = sum(&a);
	println sum;
	ok;
}

func sum(int[3]* array) -> int {
	int sum = 0;
	for int i = 0; i < 3; i++ {
		sum += array[i];
	}

	return sum;
}