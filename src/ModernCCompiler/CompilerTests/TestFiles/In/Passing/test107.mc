byte[3][3][3] alpha = [
	[
		['a', 'b', 'c'],
		['d', 'e', 'f'],
		['g', 'h', 'i']
	],
	[
		['j', 'k', 'l'],
		['m', 'n', 'o'],
		['p', 'q', 'r']
	],
	[
		['s', 't', 'u'],
		['v', 'w', 'x'],
		['y', 'z', '!']
	]
];

func main() -> int {
	println alpha;
	print '\n';

	print alpha[0][0][0];
	print alpha[1][1][1];
	print alpha[2][1][0];
	print alpha[0][1][2];
	print alpha[1][2][1];
	println alpha[2][2][2]; // anvfq!
	print '\n';
	
	rotate(&alpha);
	println alpha;
	ok;
}

func rotate(byte[3][3][3]* array) -> void {
	for int i = 0; i < 3; i++ {
		for int j = 0; j < 3; j++ {
			for int k = 0; k < 3; k++ {
				if array[i][j][k] == '!' {
					continue;
				} elif array[i][j][k] == 'z' {
					array[i][j][k] = 'A';
				} else {
					array[i][j][k]++;
				}			
			}
		}
	}
}