namespace VirtualMachine
{
    public class Memory
    {
        private readonly static int _dataCapacity = 1000; // TODO add configuration to change this
        private readonly static int _stackCapacity = 1000;
        private readonly static int _heapCapacity = 0;
        private readonly int[] _memory;

        public Memory() 
        {
            _memory = new int[_dataCapacity + _stackCapacity + _heapCapacity];
        }

        public static int GetProgramStackPointer()
        {
            return _dataCapacity; // the stack comes after the data section of memory
        }

        public static int GetDataPointer()
        {
            return 0; // the data secction starts at the beggining of memory
        }

        public int this[int index]
        {
            get => _memory[index];
            set => _memory[index] = value;
        }
    }
}
