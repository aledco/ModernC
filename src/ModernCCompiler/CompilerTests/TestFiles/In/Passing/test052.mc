func main() -> int {
    int x = 0;
    while x < 10 {
        if x == 5 or x == 7 {
            x++;
            continue;
        }

        println x;
        x++;
    }

    return 0;
}