int main() {
	bool x = false;
	bool y = (true or false) and x;
	if y {
		print 1;
	} else {
		print 0;
	}

	return 0;
}