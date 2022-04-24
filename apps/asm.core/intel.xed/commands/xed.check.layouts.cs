//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/layouts")]
        Outcome CheckLayouts(CmdArgs args)
        {
            var inst = CalcInstSegs();
            iter(inst, x => Write(x));
            return true;
        }

        Index<InstSeg> CalcInstSegs()
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var layouts = Xed.Rules.CalcInstLayouts(patterns);
            var literals = hashset<InstSeg>();
            var symbolics = hashset<InstSeg>();
            var combined = hashset<InstSeg>();
            for(var i=0; i<layouts.Count; i++)
            {
                ref readonly var layout = ref layouts[i];
                ref readonly var fields = ref layout.Fields;
                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var field = ref fields[j];
                    if(field.IsSeg)
                    {
                        ref readonly var seg = ref field.AsSeg();
                        combined.Add(seg);
                        if(seg.IsLiteral)
                            literals.Add(seg);
                        else
                            symbolics.Add(seg);
                    }
                }
            }

            var symbolic = symbolics.Array().Sort();
            var literal = literals.Array().Sort();
            var result = combined.Array().Sort();
            return result;
        }

        void CheckNonTerms2()
        {
            //var dst = Nonterminals.create();
            var src = Symbols.index<RuleName>();
            var kinds = src.Kinds;
            var dst = FunctionSet.init(kinds);
            var buffer = alloc<RuleName>(FunctionSet.MaxCount);
            var count = dst.Members(buffer);
            for(var i=0; i<kinds.Length; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                if(kind != 0)
                    Require.invariant(dst.Contains(kind));
            }

            var smaller = slice(kinds,100,150);
            dst = smaller;
            for(var i=0; i<FunctionSet.MaxCount; i++)
            {
                var min = skip(smaller,0);
                var max = skip(smaller,smaller.Length - 1);
                var kind = (RuleName)i;
                if(kind != 0)
                {
                    if(kind >= min & kind<= max)
                        Require.invariant(dst.Contains(kind));
                    else
                        Require.invariant(!dst.Contains(kind));
                }
            }
        }

        [CmdOp("gen/bits/patterns")]
        Outcome GenBitfield(CmdArgs args)
        {
            var modrm = BitfieldPatterns.infer(ModRm.BitPattern);
            Write(modrm.Descriptor);

            var rex = BitfieldPatterns.infer(RexPrefix.BitPattern);
            Write(rex.Descriptor);

            var vexC4 = BitfieldPatterns.infer(VexPrefixC4.BitPattern);
            Write(vexC4.Descriptor);

            var vexC5 = BitfieldPatterns.infer(VexPrefixC5.BitPattern);
            Write(vexC5.Descriptor);

            var sib = BitfieldPatterns.infer(Sib.BitPattern);
            Write(sib.Descriptor);

            byte data = 0b10_110_011;
            Write(BitfieldPatterns.bitstring(sib, data));
            return true;
        }
    }
}