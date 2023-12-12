struct Test {
	byte[8][2] arrayOfStrs
}

func main() -> int {
	Test test = { 
		arrayOfStrs = [
			"string 1",
			"string 2",
		]
	};

	println test;
	ok;
}