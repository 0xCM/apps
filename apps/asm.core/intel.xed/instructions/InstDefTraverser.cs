//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;

    using C = XedRules.OpClass;

    partial class XedPatterns
    {
        public class InstDefTraverser
        {
            InstDefTraversals Traversals;

            public InstDefTraverser()
            {
                Traversals = InstDefTraversals.init();
            }

            public InstDefTraverser(InstDefTraversals traversals)
            {
                Traversals = traversals;
            }

            public void TraverseDefs(Index<InstDef> defs, bool pll = true)
            {
                iter(defs, def => TraverseDef(def), pll);
            }

            public void TraverseDef(in InstDef def)
            {
                TraversingDef(def);
                Traversals.Traversing(def);

                TraverseEffects(def);
                TraversePatterns(def, def.PatternSpecs);

                TraversedDef(def);
                Traversals.Traversed(def);
            }

            void TraversePatterns(in InstDef def, Index<InstPatternSpec> patterns)
            {
                TraversingPatterns(def, patterns);
                for(var j=0; j<patterns.Count; j++)
                    TraversePattern(def, patterns[j]);
                TraversedPatterns(def, patterns);
            }

            void TraverseOps(in InstDef def, in InstPatternSpec pattern, Index<OpSpec> ops)
            {
                TraversingOps(def, pattern, ops);
                for(var k=0; k<ops.Count; k++)
                    TraverseOp(def, pattern, ops[k]);
                TraversedOps(def, pattern, ops);
            }

            void TraversePattern(in InstDef def, in InstPatternSpec pattern)
            {
                TraversingPattern(def, pattern);
                Traversals.Traversing(def, pattern);

                TraverseOps(def, pattern, pattern.Ops);

                TraversedPattern(def, pattern);
                Traversals.Traversed(def, pattern);
            }

            void TraverseOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingOp(def,pattern,op);
                Traversals.Traversing(def, pattern, op);
                switch(op.Kind)
                {
                    case OpKind.Agen:
                        TraverseAgenOp(def, pattern, op);
                    break;

                    case OpKind.Base:
                        TraverseBaseOp(def, pattern, op);
                    break;

                    case OpKind.Disp:
                        TraverseDispOp(def, pattern, op);
                    break;

                    case OpKind.Imm:
                        TraverseImmOp(def, pattern, op);
                    break;

                    case OpKind.Index:
                        TraverseIndexOp(def, pattern, op);
                    break;

                    case OpKind.Mem:
                        TraverseMemOp(def, pattern, op);
                    break;

                    case OpKind.Ptr:
                        TraversePtrOp(def, pattern, op);
                    break;

                    case OpKind.Reg:
                        TraverseRegOp(def, pattern, op);
                    break;

                    case OpKind.RelBr:
                        TraverseRelBrOp(def, pattern, op);
                    break;

                    case OpKind.Scale:
                        TraverseScaleOp(def, pattern, op);
                    break;

                    case OpKind.Seg:
                        TraverseSegOp(def, pattern, op);
                    break;
                }
                TraversedOp(def,pattern,op);
                Traversals.Traversed(def, pattern, op);
            }

            [MethodImpl(Inline)]
            void TraverseEffects(in InstDef src)
            {
                for(var i=0; i<src.FlagEffects.Count; i++)
                    TraverseEffect(src, src.FlagEffects[i]);
            }

            [MethodImpl(Inline)]
            void TraverseEffect(in InstDef def, in XedFlagEffect effect)
            {
                TraversingEffect(def, effect);
                Traversals.Traversing(def, effect);

                TraversedEffect(def, effect);
                Traversals.Traversed(def, effect);
            }

            [MethodImpl(Inline)]
            void TraverseOpAttribs(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Index<OpAttrib> attribs)
            {
                TraversingOpAttribs(def, pattern, op, attribs);
                for(var i=0; i<attribs.Count; i++)
                    TraverseOpAttrib(def, pattern, op, attribs[i]);
                TraversedOpAttribs(def, pattern, op, attribs);
            }

            void TraverseRegOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingRegOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedRegOp(def,pattern,op);
            }

            void TraverseMemOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingMemOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedMemOp(def, pattern, op);
            }

            void TraverseAgenOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingAgenOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedAgenOp(def,pattern,op);
            }

            void TraverseImmOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TarversingImmOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedImmOp(def,pattern,op);
            }

            void TraverseDispOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingDispOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedDispOp(def,pattern,op);
            }

            void TraverseBaseOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingBaseOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedBaseOp(def,pattern,op);
            }

            void TraverseIndexOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingIndexOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedIndexOp(def,pattern,op);
            }

            void TraverseScaleOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingScaleOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedScaleOp(def,pattern,op);
            }

            void TraversePtrOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingPtrOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedPtrOp(def,pattern,op);
            }

            void TraverseRelBrOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingRelBrOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedRelBrOp(def,pattern,op);
            }

            void TraverseSegOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingSegOp(def,pattern,op);
                TraverseOpAttribs(def, pattern, op, op.Attribs);
                TraversedSegOp(def,pattern,op);
            }

            void TraverseOpAction(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpAction attrib)
            {
                TraversedOpAction(def, pattern, op, attrib);
            }

            void TraverseOpElementType(in InstDef def, in InstPatternSpec pattern, in OpSpec op, ElementType attrib)
            {
                TraversedOpElementType(def, pattern, op, attrib);
            }

            void TraverseOpScale(in InstDef def, in InstPatternSpec pattern, in OpSpec op, MemoryScale attrib)
            {
                TraversedOpScale(def, pattern, op, attrib);
            }

            void TraverseOpModifier(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpModifier attrib)
            {
                TraversedOpModifier(def, pattern, op, attrib);
            }

            void TraverseOpNonterminal(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Nonterminal attrib)
            {
                TraversedOpNonterminal(def, pattern, op, attrib);
            }

            void TraverseOpPtrWidth(in InstDef def, in InstPatternSpec pattern, in OpSpec op, PointerWidthKind attrib)
            {
                TraversedOpPtrWidth(def, pattern, op, attrib);
            }

            void TraverseOpReg(in InstDef def, in InstPatternSpec pattern, in OpSpec op, XedRegId attrib)
            {
                TraversedOpReg(def, pattern, op, attrib);
            }

            void TraverseOpVisibility(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Visibility attrib)
            {
                TraversedOpVisibility(def, pattern, op, attrib);
            }

            void TraverseOpWidthAttrib(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpWidth attrib)
            {
                TraversedOpWidth(def, pattern, op, attrib);
            }

            void TraverseOpAttrib(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib)
            {
                TraversingOpAttrib(def, pattern, op, attrib);
                Traversals.Traversing(def,pattern,op, attrib);

                switch(attrib.Class)
                {
                    case C.Action:
                        TraverseOpAction(def, pattern, op, attrib.AsAction());
                    break;
                    case C.OpWidth:
                        TraverseOpWidthAttrib(def, pattern, op, attrib.AsOpWidth());
                    break;
                    case C.Visibility:
                        TraverseOpVisibility(def, pattern, op, attrib.AsVisibility());
                    break;
                    case C.PtrWidth:
                        TraverseOpPtrWidth(def, pattern, op, attrib.AsPtrWidth());
                    break;
                    case C.Nonterminal:
                        TraverseOpNonterminal(def, pattern, op, attrib.AsNonTerm());
                    break;
                    case C.RegLiteral:
                        TraverseOpReg(def, pattern, op, attrib.AsRegLiteral());
                    break;
                    case C.Scale:
                        TraverseOpScale(def, pattern, op, attrib.AsScale());
                    break;
                    case C.Modifier:
                        TraverseOpModifier(def, pattern, op, attrib.AsModifier());
                    break;
                    case C.ElementType:
                        TraverseOpElementType(def, pattern, op, attrib.AsElementType());
                    break;
                    default:
                        Errors.Throw(string.Format("Unhandled atribute class:{0}", attrib.Class));
                    break;
                }

                TraversedOpAttrib(def, pattern, op, attrib);
                Traversals.Traversed(def,pattern,op, attrib);
            }

            protected virtual void TraversingDef(in InstDef def) { }

            protected virtual void TraversedDef(in InstDef def) { }

            protected virtual void TraversingOps(in InstDef def, in InstPatternSpec pattern, Index<OpSpec> ops) {}

            protected virtual void TraversedOps(in InstDef def, in InstPatternSpec pattern, Index<OpSpec> ops) {}

            protected virtual void TraversingOpAttribs(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Index<OpAttrib> attribs) {}

            protected virtual void TraversedOpAttribs(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Index<OpAttrib> attribs) {}

            protected virtual void TraversingOpAttrib(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib) { }

            protected virtual void TraversedOpAttrib(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib) { }

            protected virtual void TraversingPatterns(in InstDef def, Index<InstPatternSpec> patterns) { }

            protected virtual void TraversedPatterns(in InstDef def, Index<InstPatternSpec> patterns) { }

            protected virtual void TraversingPattern(in InstDef def, in InstPatternSpec pattern) { }

            protected virtual void TraversedPattern(in InstDef def, in InstPatternSpec pattern) { }

            protected virtual void TraversingOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingEffect(in InstDef def, in XedFlagEffect effect) {}

            protected virtual void TraversedEffect(in InstDef def, in XedFlagEffect effect) { }

            protected virtual void TraversingRegOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedRegOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingMemOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedMemOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingAgenOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedAgenOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TarversingImmOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedImmOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingDispOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedDispOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingBaseOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedBaseOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingIndexOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedIndexOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingScaleOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedScaleOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingPtrOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedPtrOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingRelBrOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversingSegOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedRelBrOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedSegOp(in InstDef def, in InstPatternSpec pattern, in OpSpec op) { }

            protected virtual void TraversedOpModifier(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpModifier attrib) { }

            protected virtual void TraversedOpAction(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpAction attrib) { }

            protected virtual void TraversedOpElementType(in InstDef def, in InstPatternSpec pattern, in OpSpec op, ElementKind attrib) { }

            protected virtual void TraversedOpScale(in InstDef def, in InstPatternSpec pattern, in OpSpec op, MemoryScale attrib) { }

            protected virtual void TraversedOpNonterminal(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Nonterminal attrib) { }

            protected virtual void TraversedOpPtrWidth(in InstDef def, in InstPatternSpec pattern, in OpSpec op, PointerWidthKind attrib) { }

            protected virtual void TraversedOpReg(in InstDef def, in InstPatternSpec pattern, in OpSpec op, XedRegId attrib) { }

            protected virtual void TraversedOpVisibility(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Visibility attrib) { }

            protected virtual void TraversedOpWidth(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpWidth attrib) { }
        }
    }
}