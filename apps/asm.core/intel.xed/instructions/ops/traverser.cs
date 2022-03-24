//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedPatterns
    {
        public static InstTraverser traverser()
            => new InstTraverser();

        public static InstTraversals traversals()
            => InstTraversals.init();

        public static InstTraverser traverser(InstTraversals traversals)
            => new InstTraverser(traversals);
    }
}