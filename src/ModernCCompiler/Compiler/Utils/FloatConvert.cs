namespace Compiler.Utils
{
    public static class FloatConvert
    {
        public static int ToInt(float value) 
        { 
            return BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
        }

        public static float ToFloat(int value)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
        }
    }
}
