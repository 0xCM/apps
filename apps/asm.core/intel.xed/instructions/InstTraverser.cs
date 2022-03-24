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
        public class InstTraverser
        {
            InstTraversals Traversals;

            public InstTraverser()
            {
                Traversals = InstTraversals.init();
            }

            public InstTraverser(InstTraversals traversals)
            {
                Traversals = traversals;
            }

            public void TraversePatterns(Index<InstPattern> patterns, bool pll = true)
            {
                iter(patterns, pattern => TraversePattern(pattern), pll);
            }

            public void TraversePattern(InstPattern pattern)
            {
                TraversingPattern(pattern);
                Traversals.Traversing(pattern);

                TraverseOps(pattern, pattern.OpSpecs);

                TraversedPattern(pattern);
                Traversals.Traversed(pattern);
            }

            void TraverseOps(InstPattern pattern, Index<OpSpec> ops)
            {
                TraversingOps(pattern, ops);
                for(var k=0; k<ops.Count; k++)
                    TraverseOp(pattern, ops[k]);
                TraversedOps(pattern, ops);
            }

            [MethodImpl(Inline)]
            void TraverseOpAttribs(InstPattern pattern, in OpSpec op, Index<OpAttrib> attribs)
            {
                TraversingOpAttribs(pattern, op, attribs);
                for(var i=0; i<attribs.Count; i++)
                    TraverseOpAttrib(pattern, op, attribs[i]);
                TraversedOpAttribs(pattern, op, attribs);
            }

            void TraverseRegOp(InstPattern pattern, in OpSpec op)
            {
                TraversingRegOp(pattern,op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedRegOp(pattern,op);
            }

            void TraverseMemOp(InstPattern pattern, in OpSpec op)
            {
                TraversingMemOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedMemOp(pattern, op);
            }

            void TraverseAgenOp(InstPattern pattern, in OpSpec op)
            {
                TraversingAgenOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedAgenOp(pattern, op);
            }

            void TraverseImmOp(InstPattern pattern, in OpSpec op)
            {
                TarversingImmOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedImmOp(pattern, op);
            }

            void TraverseDispOp(InstPattern pattern, in OpSpec op)
            {
                TraversingDispOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedDispOp(pattern, op);
            }

            void TraverseBaseOp(InstPattern pattern, in OpSpec op)
            {
                TraversingBaseOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedBaseOp(pattern, op);
            }

            void TraverseIndexOp(InstPattern pattern, in OpSpec op)
            {
                TraversingIndexOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedIndexOp(pattern, op);
            }

            void TraverseScaleOp(InstPattern pattern, in OpSpec op)
            {
                TraversingScaleOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedScaleOp(pattern, op);
            }

            void TraversePtrOp(InstPattern pattern, in OpSpec op)
            {
                TraversingPtrOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedPtrOp(pattern, op);
            }

            void TraverseRelBrOp(InstPattern pattern, in OpSpec op)
            {
                TraversingRelBrOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedRelBrOp(pattern, op);
            }

            void TraverseSegOp(InstPattern pattern, in OpSpec op)
            {
                TraversingSegOp(pattern, op);
                TraverseOpAttribs(pattern, op, op.Attribs);
                TraversedSegOp(pattern, op);
            }

            void TraverseOp(InstPattern pattern, in OpSpec op)
            {
                TraversingOp(pattern, op);
                Traversals.Traversing(pattern, op);
                switch(op.Kind)
                {
                    case OpKind.Agen:
                        TraverseAgenOp(pattern, op);
                    break;

                    case OpKind.Base:
                        TraverseBaseOp(pattern, op);
                    break;

                    case OpKind.Disp:
                        TraverseDispOp(pattern, op);
                    break;

                    case OpKind.Imm:
                        TraverseImmOp(pattern, op);
                    break;

                    case OpKind.Index:
                        TraverseIndexOp(pattern, op);
                    break;

                    case OpKind.Mem:
                        TraverseMemOp(pattern, op);
                    break;

                    case OpKind.Ptr:
                        TraversePtrOp(pattern, op);
                    break;

                    case OpKind.Reg:
                        TraverseRegOp(pattern, op);
                    break;

                    case OpKind.RelBr:
                        TraverseRelBrOp(pattern, op);
                    break;

                    case OpKind.Scale:
                        TraverseScaleOp(pattern, op);
                    break;

                    case OpKind.Seg:
                        TraverseSegOp(pattern, op);
                    break;
                }
                TraversedOp(pattern, op);
                Traversals.Traversed(pattern, op);
            }

            void TraverseOpAttrib(InstPattern pattern, in OpSpec op, in OpAttrib attrib)
            {
                TraversingOpAttrib(pattern, op, attrib);
                Traversals.Traversing(pattern, op, attrib);

                switch(attrib.Class)
                {
                    case C.Action:
                        TraverseOpAction(pattern, op, attrib.AsAction());
                    break;
                    case C.OpWidth:
                        TraverseOpWidthAttrib(pattern, op, attrib.AsOpWidth());
                    break;
                    case C.Visibility:
                        TraverseOpVisibility(pattern, op, attrib.AsVisibility());
                    break;
                    case C.PtrWidth:
                        TraverseOpPtrWidth(pattern, op, attrib.AsPtrWidth());
                    break;
                    case C.Nonterminal:
                        TraverseOpNonterminal(pattern, op, attrib.AsNonTerm());
                    break;
                    case C.RegLiteral:
                        TraverseOpReg(pattern, op, attrib.AsRegLiteral());
                    break;
                    case C.Scale:
                        TraverseOpScale(pattern, op, attrib.AsScale());
                    break;
                    case C.Modifier:
                        TraverseOpModifier(pattern, op, attrib.AsModifier());
                    break;
                    case C.ElementType:
                        TraverseOpElementType(pattern, op, attrib.AsElementType());
                    break;
                    default:
                        Errors.Throw(string.Format("Unhandled atribute class:{0}", attrib.Class));
                    break;
                }

                TraversedOpAttrib(pattern, op, attrib);
                Traversals.Traversed(pattern, op, attrib);
            }


            void TraverseOpAction(InstPattern pattern, in OpSpec op, OpAction attrib)
            {
                TraversedOpAction(pattern, op, attrib);
            }

            void TraverseOpElementType(InstPattern pattern, in OpSpec op, ElementType attrib)
            {
                TraversedOpElementType(pattern, op, attrib);
            }

            void TraverseOpScale(InstPattern pattern, in OpSpec op, MemoryScale attrib)
            {
                TraversedOpScale(pattern, op, attrib);
            }

            void TraverseOpModifier(InstPattern pattern, in OpSpec op, OpModifier attrib)
            {
                TraversedOpModifier(pattern, op, attrib);
            }

            void TraverseOpNonterminal(InstPattern pattern, in OpSpec op, Nonterminal attrib)
            {
                TraversedOpNonterminal(pattern, op, attrib);
            }

            void TraverseOpPtrWidth(InstPattern pattern, in OpSpec op, PointerWidthKind attrib)
            {
                TraversedOpPtrWidth(pattern, op, attrib);
            }

            void TraverseOpReg(InstPattern pattern, in OpSpec op, XedRegId attrib)
            {
                TraversedOpReg(pattern, op, attrib);
            }

            void TraverseOpVisibility(InstPattern pattern, in OpSpec op, Visibility attrib)
            {
                TraversedOpVisibility(pattern, op, attrib);
            }

            void TraverseOpWidthAttrib(InstPattern pattern, in OpSpec op, OpWidth attrib)
            {
                TraversedOpWidth(pattern, op, attrib);
            }

            protected virtual void TraversingOps(InstPattern pattern, Index<OpSpec> ops) {}

            protected virtual void TraversedOps(InstPattern pattern, Index<OpSpec> ops) {}

            protected virtual void TraversingOpAttribs(InstPattern pattern, in OpSpec op, Index<OpAttrib> attribs) {}

            protected virtual void TraversedOpAttribs(InstPattern pattern, in OpSpec op, Index<OpAttrib> attribs) {}

            protected virtual void TraversingOpAttrib(InstPattern pattern, in OpSpec op, in OpAttrib attrib) { }

            protected virtual void TraversedOpAttrib(InstPattern pattern, in OpSpec op, in OpAttrib attrib) { }

            protected virtual void TraversingPattern(InstPattern spec) { }

            protected virtual void TraversedPattern(InstPattern spec) { }

            protected virtual void TraversingOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingRegOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedRegOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingMemOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedMemOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingAgenOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedAgenOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TarversingImmOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedImmOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingDispOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedDispOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingBaseOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedBaseOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingIndexOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedIndexOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingScaleOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedScaleOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingPtrOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedPtrOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingRelBrOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversingSegOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedRelBrOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedSegOp(InstPattern pattern, in OpSpec op) { }

            protected virtual void TraversedOpModifier(InstPattern pattern, in OpSpec op, OpModifier attrib) { }

            protected virtual void TraversedOpAction(InstPattern pattern, in OpSpec op, OpAction attrib) { }

            protected virtual void TraversedOpElementType(InstPattern pattern, in OpSpec op, ElementKind attrib) { }

            protected virtual void TraversedOpScale(InstPattern pattern, in OpSpec op, MemoryScale attrib) { }

            protected virtual void TraversedOpNonterminal(InstPattern pattern, in OpSpec op, Nonterminal attrib) { }

            protected virtual void TraversedOpPtrWidth(InstPattern pattern, in OpSpec op, PointerWidthKind attrib) { }

            protected virtual void TraversedOpReg(InstPattern pattern, in OpSpec op, XedRegId attrib) { }

            protected virtual void TraversedOpVisibility(InstPattern pattern, in OpSpec op, Visibility attrib) { }

            protected virtual void TraversedOpWidth(InstPattern pattern, in OpSpec op, OpWidth attrib) { }
        }
    }
}