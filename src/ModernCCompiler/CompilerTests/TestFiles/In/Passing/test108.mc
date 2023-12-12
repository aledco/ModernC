func main() -> int {
	byte[2][2][2][2] array = [
		[
			[
				['a', 'b'],
				['c', 'd'],
			],
			[
				['e', 'f'],
				['g', 'h']
			],
		],
		[
			[
				['i', 'j'],
				['k', 'l'],
			],
			[
				['m', 'n'],
				['o', 'p']
			],
		]
	];

	println array;
	allToUpper(&array);
	println array;
	ok;
}

func allToUpper(byte[2][2][2][2]* array) -> void {
	for int i = 0; i < 2; i++ {
		for int j = 0; j < 2; j++ {
			for int k = 0; k < 2; k++ {
				for int l = 0; l < 2; l++ {
					array[i][j][k][l] = toUpper(array[i][j][k][l]);
				}
			}
		}
	}
}

func toUpper(byte b) -> byte {
	return b - 32;
}