func main() -> int {
	int x = 12;
	int* p1 = &x;
	int** p2 = &p1;
	int*** p3 = &p2;
	int**** p4 = &p3;
	****p4++;
	print ****p4;
	return 0;
}