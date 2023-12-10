func main() -> int {
	int[3] a = [1, 2, 3];
	double(&a);
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

func double(int[3]* array) -> void {
	for int i = 0; i < 3; i++ {
		array[i] *= 2;
	}
}