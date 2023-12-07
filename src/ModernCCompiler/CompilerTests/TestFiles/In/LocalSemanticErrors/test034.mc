struct Test1 {
	int x,
}

struct Test2 {
	int x,
	func(Test1*, int) f = f,
}

func f(Test1* t) -> int {
	return t.x;
}

func main() -> int {
	Test1 t1 = { x = -1 };
	Test2 t2 = { x = 4 };
	print t2->f();
	return 0;
}