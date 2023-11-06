using Compiler.Models.Tree;

namespace Compiler.TreeWalking
{
    internal interface IWalker
    {
        void Walk(ProgramRoot program);
    }
}
