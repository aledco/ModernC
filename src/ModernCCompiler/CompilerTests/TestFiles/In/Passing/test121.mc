alias integer = int;

struct Test {
	integer x = 0,
	integer y = 1,
	integer z = 10,
}

alias TestAlias = Test;

TestAlias test = {};

func main() -> int {
	println test;
	ok;
}