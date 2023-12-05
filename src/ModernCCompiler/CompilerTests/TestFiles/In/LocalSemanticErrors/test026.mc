func main() -> int {
	int x = 0;
	while x < 10 {
		x++;
		print x;
		if x == 9 {
			return x;
		}
	}
}