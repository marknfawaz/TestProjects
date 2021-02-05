using Antlr.Runtime;
using Antlr.Runtime.Misc;
using Antlr.Runtime.Tree;

namespace Adds.Antlr3.Runtime
{
    public class AddsAntlr3Runtime
    {
        private Antlr.Runtime.Tree.ITreeAdaptor _treeAdaptor;
        private Antlr.Runtime.IToken _token;
        private Antlr.Runtime.Parser _parser;
        private Antlr.Runtime.Lexer _lexer;
        private Antlr.Runtime.ITokenStream _tokenStream;
        private Antlr.Runtime.IIntStream _intStream;
        private Antlr.Runtime.ICharStream _charStream;
        private Antlr.Runtime.DFA _dfa;

        public AddsAntlr3Runtime()
        {
            _treeAdaptor = new CommonTreeAdaptor();
            _treeAdaptor.SetTokenBoundaries(new object(), _token, _token);
            _treeAdaptor.RulePostProcessing(new object());
            _treeAdaptor.Nil();
            _treeAdaptor.AddChild(new object(), new object());
            _treeAdaptor.Create(_token);

            _parser.TraceIn("", 0);
            _parser.TraceOut("", 0);

            _lexer.TraceOut("", 0);
            _lexer.TraceIn("", 0);
            _lexer.Recover(new Antlr.Runtime.RecognitionException(""));
            _lexer.MatchAny();
            _lexer.Match("");
            _lexer.Match(0);

            _tokenStream.LT(0);
            _tokenStream.Get(0);
            _intStream.LA(0);
            _intStream.Consume();
            _charStream.LT(0);
            _dfa.Predict(_intStream);
            _dfa.Error(new Antlr.Runtime.NoViableAltException(""));
        }
    }
}
