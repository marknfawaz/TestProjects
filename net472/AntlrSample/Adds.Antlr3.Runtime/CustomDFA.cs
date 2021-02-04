using Antlr.Runtime;

namespace Adds.Antlr3.Runtime
{
    public class CustomDFA : DFA
    {
        public void CallProtectedApis()
        {
            base.DebugRecognitionException(new RecognitionException(""));
        }
    }
}