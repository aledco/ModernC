using Mono.Options;

namespace Compiler.Config
{
    /// <summary>
    /// Stores the global configuration initialized by command line arguments.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Gets or sets the file name of the source code to compile.
        /// </summary>
        public static string FileName { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets the output file name to store compiled code. Defaults to a.out.
        /// </summary>
        public static string OutputFileName { get; private set; } = "a.out";

        /// <summary>
        /// Gets or sets the compilation mode. Defaults to compile.
        /// </summary>
        public static Mode Mode { get; private set; } = Mode.Compile;

        /// <summary>
        /// Initializes the configuration.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void Initialize(string[] args)
        {
            var showHelp = false;
            var p = new OptionSet()
            {
                {
                    "r|run",
                    "execute the code.",
                    v =>
                    {
                        if (v != null)
                        {
                            Mode = Mode.Execute;
                        }
                    }
                },
                {
                    "o|out=",
                    "specify and output file",
                    v => OutputFileName = v
                },
                {
                    "h|help",
                    "show the help message.",
                    v => showHelp = v != null
                }
            };

            try
            {
                var extra = p.Parse(args);
                if (showHelp)
                {
                    Console.WriteLine("mcc [filename] [-r|--run] [-o|--out file]");
                    Environment.Exit(0);
                }

                if (extra.Count > 0)
                {
                    FileName = extra[0];
                }
                else
                {
                    Mode = Mode.Interpret;
                }
            }
            catch (OptionException e)
            {
                Console.Write("mcc: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `mcc --help' for more information.");
                return;
            }
        }
    }
}
