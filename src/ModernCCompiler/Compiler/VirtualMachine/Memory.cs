namespace Compiler.VirtualMachine
{
    public class Memory
    {
        private int _capacity = 2048;
        private int[] _memory;

        public Memory() 
        {
            _memory = new int[_capacity];
        }

        public int this[int index]
        {
            get => _memory[index];
            set
            {
                if (index >= _capacity)
                {
                    _capacity *= 2;
                    Array.Resize(ref _memory, _capacity);
                }

                _memory[index] = value;
            }
        }
    }
}
