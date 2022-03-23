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
        public class PatternTraverser
        {
            IntelXed Xed;

            ConcurrentBag<InstPatternSpec> _Patterns = new();

            ConcurrentDictionary<uint,InstDef> _Defs = new();

            ConcurrentDictionary<uint,OpSpec> _Ops = new();

            uint PatternSeq;

            IClass Class;

            Index<OpWidthInfo> Widths;

            Action<string> Printer;

            public Index<InstPatternSpec> Patterns()
                => _Patterns.ToArray().Sort();

            public Index<InstDef> Defs()
                => _Defs.Values.Array().Sort();

            public Index<OpSpec> Ops()
                => _Ops.Values.Array().Sort();

            public PatternTraverser(IntelXed xed)
            {
                static void print(string src)
                {

                }

                Xed = xed;
                Widths = Xed.Patterns.CalcOpWidths();
                Printer = print;
            }

            public PatternTraverser(IntelXed xed, Action<string> printer)
                : this(xed)
            {
                Printer = printer;
            }

            void Clear()
            {
                _Patterns.Clear();
                _Defs.Clear();
            }

            public void Traverse(bool pll = true)
            {
                Clear();
                var defs = Xed.Rules.CalcInstDefs();
                iter(defs, def => Traverse(def), pll);
            }

            void Print(in InstPatternSpec src)
            {
                if(src.Class != Class)
                {
                    Class = src.Class;
                    PatternSeq = 0;
                }
                Printer(EmptyString);
                Printer(string.Format("{0,-5} {1,-22} | {2}",
                    src.PatternId,
                    string.Format("{0} {1:D2}", XedRender.format(src.Class), PatternSeq++),
                    src.Body.Delimit(Chars.Space))
                    );
                Printer(RP.PageBreak160);
            }

            void Print(in OpSpec op)
                => Printer(string.Format("{0,-28} | {1} {2}",  op.Index,  XedRender.format(op.Name), op.Attribs.Delimit(Chars.Colon)));

            void Print(in XedFlagEffect src)
                => Printer(src.Format());

            public void Traverse(in InstDef def)
            {
                if(!_Defs.TryAdd(def.InstId, def))
                {
                    Errors.Throw(string.Format("Duplicate:{0}",def.Class));
                }

                TraverseEffects(def);

                var patterns = def.PatternSpecs;
                for(var j=0; j<patterns.Count; j++)
                {
                    ref readonly var pattern = ref patterns[j];
                    _Patterns.Add(pattern);
                    Print(pattern);

                    ref readonly var ops = ref pattern.Ops;
                    for(var k=0; k<ops.Count; k++)

                        Traverse(def, pattern, ops[k]);
                }
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                _Ops.TryAdd(op.OpId, op);
                switch(op.Kind)
                {
                    case OpKind.Agen:
                        TraverseAgen(def, pattern, op);
                    break;

                    case OpKind.Base:
                        TraverseBase(def, pattern, op);
                    break;

                    case OpKind.Disp:
                        TraverseDisp(def, pattern, op);
                    break;

                    case OpKind.Imm:
                        TraverseImm(def, pattern, op);
                    break;

                    case OpKind.Index:
                        TraverseIndex(def, pattern, op);
                    break;

                    case OpKind.Mem:
                        TraverseMem(def, pattern, op);
                    break;

                    case OpKind.Ptr:
                        TraversePtr(def, pattern, op);
                    break;

                    case OpKind.Reg:
                        TraverseReg(def, pattern, op);
                    break;

                    case OpKind.RelBr:
                        TraverseRelBr(def, pattern, op);
                    break;

                    case OpKind.Scale:
                        TraverseScale(def, pattern, op);
                    break;

                    case OpKind.Seg:
                        TraverseSeg(def, pattern, op);
                    break;
                }
            }

            [MethodImpl(Inline)]
            void TraverseEffects(in InstDef src)
            {
                for(var i=0; i<src.FlagEffects.Count; i++)
                    Traverse(src, src.FlagEffects[i]);
            }

            void Traverse(in InstDef def, in XedFlagEffect effect)
            {
                TraversingEffect(def,effect);
                Traversed(def, effect);
            }

            [MethodImpl(Inline)]
            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Index<OpAttrib> attribs)
            {
                for(var i=0; i<attribs.Count; i++)
                    Traverse(def, pattern, op, attribs[i]);
            }

            void TraverseReg(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingReg(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseMem(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingMem(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseAgen(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TarversingAgen(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseImm(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TarversingImm(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseDisp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingDisp(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseBase(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TarversingBase(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseIndex(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingIndex(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseScale(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TarversingScale(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraversePtr(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TarversingPtr(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseRelBr(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingRelBr(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void TraverseSeg(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                TraversingSeg(def,pattern,op);
                Traverse(def, pattern, op, op.Attribs);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpAction attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, ElementKind attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, MemoryScale attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpModifier attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, NontermKind attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpWidthCode attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, PointerWidthKind attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, XedRegId attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Visibility attrib)
            {
                Traversed(def, pattern, op, attrib);
            }

            void Traverse(in InstDef def, in InstPatternSpec pattern, in OpSpec op, in OpAttrib attrib)
            {
                switch(attrib.Class)
                {
                    case C.Action:
                        Traverse(def, pattern, op, attrib.AsAction());
                    break;
                    case C.OpWidth:
                        Traverse(def, pattern, op, attrib.AsOpWidth());
                    break;
                    case C.Visibility:
                        Traverse(def, pattern, op, attrib.AsVisibility());
                    break;
                    case C.PtrWidth:
                        Traverse(def, pattern, op, attrib.AsPtrWidth());
                    break;
                    case C.Nonterminal:
                        Traverse(def, pattern, op, attrib.AsNonTerm());
                    break;
                    case C.RegLiteral:
                        Traverse(def, pattern, op, attrib.AsRegLiteral());
                    break;
                    case C.Scale:
                        Traverse(def, pattern, op, attrib.AsScale());
                    break;
                    case C.ElementType:
                        Traverse(def, pattern, op, attrib.AsElementType());
                    break;
                    case C.Modifier:
                        Traverse(def, pattern, op, attrib.AsModifier());
                    break;
                    default:
                    break;
                }
            }

            protected virtual void TraversingEffect(in InstDef def, in XedFlagEffect effect)
            {
                Print(effect);
            }

            protected virtual void TraversingReg(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TraversingMem(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TarversingAgen(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TarversingImm(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TraversingDisp(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TarversingBase(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TraversingIndex(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TarversingScale(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TarversingPtr(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TraversingRelBr(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void TraversingSeg(in InstDef def, in InstPatternSpec pattern, in OpSpec op)
            {
                Print(op);
            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpModifier attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpAction attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, ElementKind attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, MemoryScale attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, NontermKind attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, OpWidthCode attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, PointerWidthKind attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, XedRegId attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in InstPatternSpec pattern, in OpSpec op, Visibility attrib)
            {

            }

            protected virtual void Traversed(in InstDef def, in XedFlagEffect effect)
            {

            }
        }
    }
}