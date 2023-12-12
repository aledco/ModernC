struct Test {
    byte[] str
}

func main() -> int {
    Test test = { str = "stringaling" };
    print test;
    ok;
}