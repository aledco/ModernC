func main() -> int {
    int x = 0;
    do {
        if x == 5 or x == 7 {
            x++;
            continue;
        }

        println x;
        x++;
    } while x < 10;
    return 0;
}