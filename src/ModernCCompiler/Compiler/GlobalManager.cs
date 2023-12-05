using Compiler.Models.NameResolution;

namespace Compiler
{
    /// <summary>
    /// Manages the compilers globals.
    /// </summary>
    public static class GlobalManager
    {
        /// <summary>
        /// Clears all globals.
        /// </summary>
        public static void Clear()
        {
            SymbolTable.Clear();
        }
    }
}
