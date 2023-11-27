int main() {
    int x = 0;

    while x < 10 {
        println x;
        if x == 5 { 
            break; 
        }

        x++;
    }

    return 0;
}