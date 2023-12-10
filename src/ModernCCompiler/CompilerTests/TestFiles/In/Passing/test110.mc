func main() -> int {
	int[1] a1 = [1];
	int sum1 = sum(&a1);
	println sum1;

	int[2] a2 = [1, 2];
	int sum2 = sum(&a2);
	println sum2;

	int[3] a3 = [1, 2, 3];
	int sum3 = sum(&a3);
	println sum3;
	
	int[4] a4 = [1, 2, 3, 4];
	int sum4 = sum(&a4);
	println sum4;

	int[5] a5 = [1, 2, 3, 4, 5];
	int sum5 = sum(&a5);
	println sum5;

	ok;
}

func sum(int[size]* array) -> int {
	println size;
	int sum = 0;
	for int i = 0; i < size; i++ {
		sum += array[i];
	}

	return sum;
}