alias tuple = int[2];

func main() -> int {
	tuple args = [0, 1];
	int ret = f(&args);
	println ret;
	ok;
}

func f(tuple* args) -> int {
	return args[0] + 2*args[1]; 
}