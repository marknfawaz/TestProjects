using Antlr.Runtime;

namespace Adds.Antlr3.Runtime
{
    public class CustomRecognizer : BaseRecognizer
    {
        IIntStream _intStream;
        public override string SourceName => throw new System.NotImplementedException();

        public void CallProtectedApis()
        {
            base.PushFollow(new Antlr.Runtime.BitSet());
            base.PopFollow();
            base.Match(_intStream, 0, new Antlr.Runtime.BitSet());
            base.InitDFAs();
            base.DebugRecognitionException(new Antlr.Runtime.RecognitionException());
            base.DebugLocation(0, 0);
            base.DebugExitSubRule(0);
            base.DebugExitRule("", "");
            base.DebugExitDecision(0);
            base.DebugEnterSubRule(0);
            base.DebugEnterRule("", "");
            base.DebugEnterDecision(0, true);
            base.DebugEnterAlt(0);
        }
    }
}