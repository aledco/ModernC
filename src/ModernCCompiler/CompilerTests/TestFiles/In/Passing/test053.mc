int main() {
    int x = 0;

    do {
        println x;
        if x == 5 { 
            break; 
        }

        x++;
    }
    while x < 10;
    return 0;
}