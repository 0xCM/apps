//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public class InstTraversals
        {
            public static InstTraversals init()
                => new InstTraversals();

            public delegate void PatternTraversal(InstPattern pattern);

            public delegate void OpTraversal(InstPattern pattern, in PatternOp op);

            public delegate void OpAttribTraversal(InstPattern pattern, in PatternOp op, in OpAttrib attrib);

            PatternTraversal PrePattern;

            PatternTraversal PostPattern;

            OpTraversal PostOp;

            OpTraversal PreOp;

            OpAttribTraversal PostOpAttrib;

            OpAttribTraversal PreOpAttrib;

            InstTraversals()
            {
                PrePattern = OnPatternTraversal;
                PostPattern = OnPatternTraversal;

                PreOp = OnOpTraversal;
                PostOp = OnOpTraversal;

                PreOpAttrib = OnOpAttribTraversal;
                PostOpAttrib = OnOpAttribTraversal;
            }

            [MethodImpl(Inline)]
            internal void Traversing(InstPattern pattern)
                => PrePattern(pattern);

            [MethodImpl(Inline)]
            internal void Traversed(InstPattern pattern)
                => PostPattern(pattern);

            [MethodImpl(Inline)]
            internal void Traversing(InstPattern pattern, in PatternOp op)
                => PreOp(pattern, op);

            [MethodImpl(Inline)]
            internal void Traversed(InstPattern pattern, in PatternOp op)
                => PostOp(pattern, op);

            [MethodImpl(Inline)]
            internal void Traversing(InstPattern pattern, in PatternOp op, in OpAttrib attrib)
                => PreOpAttrib(pattern, op, attrib);

            [MethodImpl(Inline)]
            internal void Traversed(InstPattern pattern, in PatternOp op, in OpAttrib attrib)
                => PostOpAttrib(pattern, op, attrib);

            [MethodImpl(Inline)]
            public InstTraversals WithPreHandler(PatternTraversal handler)
            {
                PrePattern = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstTraversals WithPostHandler(PatternTraversal handler)
            {
                PostPattern = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstTraversals WithPreHandler(OpTraversal handler)
            {
                PreOp = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstTraversals WithPreHandler(OpAttribTraversal handler)
            {
                PreOpAttrib = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstTraversals WithPostHandler(OpTraversal handler)
            {
                PostOp = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstTraversals WithPostHandler(OpAttribTraversal handler)
            {
                PostOpAttrib = handler;
                return this;
            }

            [MethodImpl(Inline)]
            static void OnPatternTraversal(InstPattern pattern) {}

            [MethodImpl(Inline)]
            static void OnOpTraversal(InstPattern pattern, in PatternOp op) {}

            [MethodImpl(Inline)]
            static void OnOpAttribTraversal(InstPattern pattern, in PatternOp op, in OpAttrib attrib) {}
        }
    }
}