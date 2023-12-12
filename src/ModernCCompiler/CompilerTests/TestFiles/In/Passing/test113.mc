func main() -> int {
	byte[] array = ['a', 'b', 'c', 'd'];
	printArray(&array);
	ok;
}

func printArray(byte[size]* array) -> void {
	println size;
	for int i = 0; i < size; i++ {
		println array[i];
	}
}