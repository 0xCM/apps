//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedRules;
    using static XedModels;

    using C = XedRules.RuleOpClass;

    class XedInstTraverser
    {
        IntelXed Xed;

        ConcurrentBag<InstPattern> Collected;

        Index<OpWidth> Widths;

        Action<string> Printer;

        public Index<InstPattern> Patterns()
            => Collected.ToArray().Sort();


        public XedInstTraverser(IntelXed xed)
        {
            static void print(string src)
            {

            }

            Xed = xed;
            Collected = new();
            Widths = Xed.Rules.LoadOperandWidths();
            Printer = print;
        }

        public XedInstTraverser(IntelXed xed, Action<string> printer)
            : this(xed)
        {
            Printer = printer;
        }

        public void Traverse()
        {
            Collected.Clear();
            var defs = Xed.Rules.CalcInstDefs();
            iter(defs, def => Traverse(def), false);
        }

        void Print(in InstPatternSpec src)
        {
            Printer(string.Format("{0,-18} {1}", XedRender.format(src.Mnemonic), src.Expression));
            Printer(RP.PageBreak80);
        }

        public void Traverse(in InstDef def)
        {
            var patterns = def.PatternSpecs;
            Xed.Rules.ExpandMacros(patterns);
            for(var j=0; j<patterns.Count; j++)
            {
                ref readonly var pattern = ref patterns[j];
                Collected.Add(new InstPattern(def,pattern));
                Print(pattern);

                ref readonly var ops = ref pattern.Operands;
                for(var k=0; k<ops.Count; k++)
                    Traverse(def, pattern, ops[k]);
            }
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            switch(op.Kind)
            {
                case RuleOpKind.Agen:
                    TraverseAgen(def, pattern, op);
                break;

                case RuleOpKind.Base:
                    TraverseBase(def, pattern, op);
                break;

                case RuleOpKind.Disp:
                    TraverseDisp(def, pattern, op);
                break;

                case RuleOpKind.Imm:
                    TraverseImm(def, pattern, op);
                break;

                case RuleOpKind.Index:
                    TraverseIndex(def, pattern, op);
                break;

                case RuleOpKind.Mem:
                    TraverseMem(def, pattern, op);
                break;

                case RuleOpKind.Ptr:
                    TraversePtr(def, pattern, op);
                break;

                case RuleOpKind.Reg:
                    TraverseReg(def, pattern, op);
                break;

                case RuleOpKind.RelBr:
                    TraverseRelBr(def, pattern, op);
                break;

                case RuleOpKind.Scale:
                    TraverseScale(def, pattern, op);
                break;

                case RuleOpKind.Seg:
                    TraverseSeg(def, pattern, op);
                break;
            }
        }

        [MethodImpl(Inline)]
        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, Index<RuleOpAttrib> attribs)
        {
            for(var i=0; i<attribs.Count; i++)
                Traverse(def, pattern, op, attribs[i]);
        }

        void TraverseReg(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TraversingReg(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseMem(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TraversingMem(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseAgen(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TarversingAgen(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseImm(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TarversingImm(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseDisp(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TraversingDisp(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseBase(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TarversingBase(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseIndex(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TraversingIndex(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseScale(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TarversingScale(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraversePtr(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TarversingPtr(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseRelBr(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TraversingRelBr(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void TraverseSeg(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            TraversingSeg(def,pattern,op);
            Traverse(def, pattern, op, op.Attribs);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, OperandAction attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, ElementKind attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, EncodingGroup attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, MemoryScale attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, RuleOpModifier attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, Nonterminal attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, OperandWidthCode attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, PointerWidthKind attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, XedRegId attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, OpVisibility attrib)
        {
            Traversed(def, pattern, op, attrib);
        }

        void Traverse(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, in RuleOpAttrib attrib)
        {
            switch(attrib.Kind)
            {
                case C.Action:
                    Traverse(def, pattern, op, attrib.AsAction());
                break;
                case C.ElementType:
                    Traverse(def, pattern, op, attrib.AsElementType());
                break;
                case C.EncGroup:
                    Traverse(def, pattern, op, attrib.AsEncodingGroup());
                break;
                case C.Modifier:
                    Traverse(def, pattern, op, attrib.AsModifier());
                break;
                case C.Nonterminal:
                    Traverse(def, pattern, op, attrib.AsNonTerm());
                break;
                case C.OpWidth:
                    Traverse(def, pattern, op, attrib.AsOpWidth());
                break;
                case C.PtrWidth:
                    Traverse(def, pattern, op, attrib.AsPtrWidth());
                break;
                case C.RegLiteral:
                    Traverse(def, pattern, op, attrib.AsRegLiteral());
                break;
                case C.Scale:
                    Traverse(def, pattern, op, attrib.AsScale());
                break;
                case C.Visibility:
                    Traverse(def, pattern, op, attrib.AsVisiblity());
                break;
                default:
                break;
            }
        }

        void Print(in RuleOpSpec op)
        {
            Printer(string.Format("{0,-5} {1,-5} {2}",  op.Index,  XedRender.format(op.Name), op.Attribs.Delimit(Chars.Colon)));
        }
        protected virtual void TraversingReg(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TraversingMem(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TarversingAgen(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TarversingImm(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);

        }

        protected virtual void TraversingDisp(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TarversingBase(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TraversingIndex(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TarversingScale(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TarversingPtr(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TraversingRelBr(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void TraversingSeg(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op)
        {
            Print(op);
        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, RuleOpModifier attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, OperandAction attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, ElementKind attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, EncodingGroup attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, MemoryScale attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, Nonterminal attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, OperandWidthCode attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, PointerWidthKind attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, XedRegId attrib)
        {

        }

        protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in RuleOpSpec op, OpVisibility attrib)
        {

        }
    }
}