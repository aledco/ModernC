using Compiler.Input;
using Mono.Options;

namespace Compiler.CommandLine
{
    public class Args
    {
        public string FileName { get; private set; }
        public string OutputFileName { get; private set; }
        public Mode Mode { get; private set; }

        public Args(string[] args)
        {
            FileName = string.Empty;
            OutputFileName = "a.out";
            Mode = Mode.Compile;
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

        public IReader GetReader()
        {
            return Mode switch
            {
                Mode.Interpret => new ConsoleReader(),
                Mode.Compile or Mode.Execute => new FileReader(FileName),
                _ => throw new NotImplementedException()
            };
        }
    }
}
