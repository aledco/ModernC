struct Test {
    int x,
    int y
}

func main() -> int {
    Test test = { y = 0, x = 0 };
    for int i = 0; i < 20; i++ {
        if i % 2 == 0 {
            test.x++;
        } elif i % 2 == 1 {
            test.y += 2;
        }
    }

    print test;
    return 0;
}