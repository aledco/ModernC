struct Test {
	byte x;
	int iter;
}

func main() -> int {
	for int i = 0; i < 3; i++ {
		Test test = { iter = i, x = read };
		print test.iter;
		println test.x;
	}

	return 0;
}