func main() -> int {
	func(int) g = f;
	int x = g();
	print x;
	return 0;
}

func f() -> void {
	print 'a';
} 