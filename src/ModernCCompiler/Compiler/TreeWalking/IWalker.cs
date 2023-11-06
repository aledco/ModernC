using Compiler.Models.Tree;

namespace Compiler.TreeWalking
{
    public interface IWalker
    {
        void Walk(ProgramRoot program);
    }
}
