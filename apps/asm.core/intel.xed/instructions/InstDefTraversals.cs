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
        public class InstDefTraversals
        {
            public static InstDefTraversals init()
                => new InstDefTraversals();

            public delegate void DefTraversal(in InstDef def);

            public delegate void EffectTraversal(in InstDef def, in XedFlagEffect effect);

            public delegate void PatternTraversal(in InstDef def, in InstPatternSpec pattern);

            public delegate void OpTraversal(in InstDef def, in InstPatternSpec pattern, in OpSpec op);

            public delegate void OpAttribTraversal(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib);

            DefTraversal PreDef;

            DefTraversal PostDef;

            EffectTraversal PreEffect;

            EffectTraversal PostEffect;

            PatternTraversal PrePattern;

            PatternTraversal PostPattern;

            OpTraversal PostOp;

            OpTraversal PreOp;

            OpAttribTraversal PostOpAttrib;

            OpAttribTraversal PreOpAttrib;

            InstDefTraversals()
            {
                PreDef = OnDefTraversal;
                PostDef = OnDefTraversal;

                PreEffect = OnEffectTraversal;
                PostEffect = OnEffectTraversal;

                PrePattern = OnPatternTraversal;
                PostPattern = OnPatternTraversal;

                PreOp = OnOpTraversal;
                PostOp = OnOpTraversal;

                PreOpAttrib = OnOpAttribTraversal;
                PostOpAttrib = OnOpAttribTraversal;
            }

            [MethodImpl(Inline)]
            internal void Traversing(in InstDef def)
                => PreDef(def);

            [MethodImpl(Inline)]
            internal void Traversed(in InstDef def)
                => PostDef(def);

            [MethodImpl(Inline)]
            internal void Traversing(in InstDef def, XedFlagEffect effect)
                => PreEffect(def,effect);

            [MethodImpl(Inline)]
            internal void Traversed(in InstDef def, XedFlagEffect effect)
                => PostEffect(def,effect);

            [MethodImpl(Inline)]
            internal void Traversing(in InstDef def, in InstPatternSpec pattern)
                => PrePattern(def,pattern);

            [MethodImpl(Inline)]
            internal void Traversed(in InstDef def, in InstPatternSpec pattern)
                => PostPattern(def,pattern);

            [MethodImpl(Inline)]
            internal void Traversing(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
                => PreOp(def,pattern,op);

            [MethodImpl(Inline)]
            internal void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
                => PostOp(def,pattern,op);

            [MethodImpl(Inline)]
            internal void Traversing(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib)
                => PreOpAttrib(def, pattern, op, attrib);

            [MethodImpl(Inline)]
            internal void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib)
                => PostOpAttrib(def, pattern, op, attrib);

            [MethodImpl(Inline)]
            public InstDefTraversals WithPreHandler(DefTraversal handler)
            {
                PreDef = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPreHandler(EffectTraversal handler)
            {
                PreEffect = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPreHandler(PatternTraversal handler)
            {
                PrePattern = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPreHandler(OpTraversal handler)
            {
                PreOp = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPreHandler(OpAttribTraversal handler)
            {
                PreOpAttrib = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPostHandler(DefTraversal handler)
            {
                PostDef = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPostHandler(EffectTraversal handler)
            {
                PostEffect = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPostHandler(PatternTraversal handler)
            {
                PostPattern = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPostHandler(OpTraversal handler)
            {
                PostOp = handler;
                return this;
            }

            [MethodImpl(Inline)]
            public InstDefTraversals WithPostHandler(OpAttribTraversal handler)
            {
                PostOpAttrib = handler;
                return this;
            }


            [MethodImpl(Inline)]
            static void OnDefTraversal(in InstDef def) {}

            [MethodImpl(Inline)]
            static void OnEffectTraversal(in InstDef def, in XedFlagEffect effect) {}

            [MethodImpl(Inline)]
            static void OnPatternTraversal(in InstDef def, in InstPatternSpec pattern) {}

            [MethodImpl(Inline)]
            static void OnOpTraversal(in InstDef def, in InstPatternSpec pattern, in OpSpec op) {}

            [MethodImpl(Inline)]
            static void OnOpAttribTraversal(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib) {}
        }
    }
}