namespace Compiler.Context.VirtualMachine
{
    /// <summary>
    /// The assign registers and offsets context.
    /// </summary>
    public class AssignContext
    {
        /// <summary>
        /// The registers in use.
        /// </summary>
        private readonly HashSet<int> _regsInUse = new();

        /// <summary>
        /// The register pool.
        /// </summary>
        private readonly HashSet<int> _regPool = new();

        /// <summary>
        /// Gets an available register.
        /// </summary>
        /// <returns>A register.</returns>
        public string GetRegister()
        {
            int reg = 1;
            while (_regsInUse.Contains(reg))
            {
                reg++;
            }

            _regsInUse.Add(reg);
            _regPool.Add(reg);
            return $"r{reg}";
        }

        /// <summary>
        /// Drops a register from the registers in use.
        /// </summary>
        /// <param name="register">The register.</param>
        public void DropRegister(string register)
        {
            var r = int.Parse(register.Replace("r", ""));
            _regsInUse.Remove(r);
        }

        /// <summary>
        /// Clears the registers.
        /// </summary>
        public void Clear()
        {
            _regsInUse.Clear();
        }
        
        /// <summary>
        /// Gets the register pool.
        /// </summary>
        /// <returns>The register pool.</returns>
        public List<string> GetRegisterPool()
        {
            return _regPool
                .OrderBy(x => x)
                .Select(x => $"r{x}")
                .ToList();
        }
    }
}
