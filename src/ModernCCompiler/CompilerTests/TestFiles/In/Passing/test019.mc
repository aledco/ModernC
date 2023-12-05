func main() -> int {
	bool x = true or true and true or true;
	bool y = false or not true;
	if y {
		print 1;
	} elif x {
		if y {
			print 1;
		} elif not x {
			print 2;
		} elif true or false {
			print 3;
		} else {
			print 0;
		}
	}

	return 0;
}