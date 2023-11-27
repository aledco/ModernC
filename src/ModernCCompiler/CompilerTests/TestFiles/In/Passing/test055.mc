int main() {
	for int i = 1; i <= 3; i++ {
		for int j = 1; j < 200; j++ {
			if j == 3 {
				break;
			}

			println i * j;
		}

		if i == 2 {
			continue;
		}
	}

	return 0;
}
