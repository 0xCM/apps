//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedPatterns
    {
        public static InstDefTraverser traverser()
            => new InstDefTraverser();

        public static InstDefTraversals traversals()
            => InstDefTraversals.init();

        public static InstDefTraverser traverser(InstDefTraversals traversals)
            => new InstDefTraverser(traversals);
    }
}