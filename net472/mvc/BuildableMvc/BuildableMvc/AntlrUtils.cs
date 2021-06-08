using Antlr.Runtime;
using Antlr.Runtime.Misc;
using Antlr.Runtime.Tree;

namespace BuildableMvc
{
    public class AntlrUtils
    {
        public void Initialize()
        {
            var commonToken = new CommonToken();
            var commonTree = new CommonTree();
            var listStack = new ListStack<string>();
        }
    }
}