using Compiler.Models.NameResolution;


namespace Compiler.Utils
{
    public static class Globals
    {
        public static void Clear()
        {
            SymbolTable.Clear();
        }
    }
}
