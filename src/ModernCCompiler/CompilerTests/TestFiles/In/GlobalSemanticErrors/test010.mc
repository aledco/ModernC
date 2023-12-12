alias integer = int;

alias TestAlias = Test;

struct Test {
	integer x = 0,
	integer y = 1,
	integer z = 10,
}

func main() -> int {
	TestAlias test = {};
	println test;
	ok;
}