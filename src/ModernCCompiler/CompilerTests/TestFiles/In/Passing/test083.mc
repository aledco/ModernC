func main() -> int {
	int x = 10;
	if x < 5 {
		print 0;
		return 0;
	} elif x >= 5 and x < 10 {
		print 1;
		return 1;
	} else {
		print 2;
		return 2;
	}
}