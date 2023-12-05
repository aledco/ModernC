func main() -> int {
	int x = 0;
	{
		int x = 1;
		print x;
	}

	print x;
	return x;
}