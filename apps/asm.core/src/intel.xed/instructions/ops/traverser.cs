//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedPatterns
    {
        public static PatternTraverser traverser(IWfRuntime wf)
            => new PatternTraverser(wf.IntelXed());

        public static PatternTraverser  traverser(IWfRuntime wf, Action<string> printer)
            => new PatternTraverser(wf.IntelXed(),printer);
    }
}