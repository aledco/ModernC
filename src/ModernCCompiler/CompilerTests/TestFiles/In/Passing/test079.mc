struct Test1 {
	Test2 t2;
}

struct Test2 {
	Test3 t3;
}

struct Test3 {
	Test4 t4;
}

struct Test4 {
	int x;
	int y;
	int z;
}

Test1 globalTest = { 
	t2 = { 
		t3 = { 
			t4 = { 
				x = 1, 
				y = 2, 
				z = 3 
			} 
		}
	}
};

int main() {
	Test1 localTest = { 
		t2 = { 
			t3 = { 
				t4 = { 
					x = -10, 
					y = -20, 
					z = -30 
				} 
			}
		}
	};

	localTest.t2.t3.t4.x = -12;
	localTest.t2.t3.t4.y = -22;
	globalTest.t2.t3.t4.z = 3000;

	println globalTest;
	println localTest;
	return 0;
}
