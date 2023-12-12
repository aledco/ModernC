alias integer = int;

struct Test {
	integer x = 0,
	integer y = 1,
	integer z = 10,
}

alias TestAlias = Test;

func main() -> int {
	TestAlias test = {};
	println test;
	ok;
}