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
            var src = CalcInstSegs();
            var maxcount = 0;
            var records = CalcLayoutRecords();
            foreach(var r in records)
            {
                var fields = r.Fields.Map(x => x.Format().PadRight(12));
                var count = fields.Length;
                if(count > maxcount)
                    maxcount = count;
                Write(string.Format("{0,-8} | {1,-18} | {2,-26} | {3,-3} | {4}", r.PatternId, r.Instruction, r.OpCode, count, fields.Concat(" ")));
            }
            // foreach(var pid in src.Keys)
            // {
            //     var segs = src[pid];
            //     var fmt = segs.Map(x => x.Format().PadRight(12));
            //     var count = fmt.Length;
            //     if(count > maxcount)
            //         maxcount = count;
            //     Write(string.Format("{0,-8} | {1,-3} | {2}", pid, fmt.Length, fmt.Concat(" ")));
            // }

            Write($"Max {maxcount}");
            // var inst = CalcInstSegs();
            // iter(inst, x => Write(x));
            return true;
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