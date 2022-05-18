//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static CsLang;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/check")]
        Outcome XedCheck(CmdArgs args)
        {
            const string CommentPattern = "Specifies the maximum value of a {0}-bit number, {1:#,#}";
            const string NamePattern = "Max{0}u";
            var max = 0ul;
            var emitter = CsLang.emitter();
            var offset = 0u;
            emitter.OpenNamespace(offset, "Z0");
            offset+=4;
            emitter.OpenStruct(offset, "Limit");
            offset+=4;
            for(var i=1; i<=64; i++)
            {
                emitter.SummaryComment(offset, string.Format(CommentPattern, i, max));
                max = Numbers.max((byte)i);
                if(i <= 8)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (byte)max);
                else if(i <= 16)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ushort)max);
                else if(i <= 32)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (uint)max);
                else if(i <= 64)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ulong)max);
                emitter.AppendLine();
                //emitter.IndentLine(offset, string.Format("public const ulong {0} = {1};", name, max));

            }
            offset-=4;
            emitter.CloseStruct(offset);
            offset-=4;
            emitter.CloseNamespace(offset);

            AppSvc.FileEmit(emitter.Emit(), AppDb.CgStage().Path("limit", FileKind.Cs));

            return true;
        }

        [CmdOp("xed/bf/check")]
        Outcome CheckBitfields(CmdArgs args)
        {
            var bitfield = RuleBits.create();
            Write(bitfield.Dataset.Intervals.Format());
            return true;
        }

        [CmdOp("xed/rules/bits")]
        Outcome EmitAnalysis(CmdArgs args)
        {
            var bitfield = RuleBits.create();
            var dst = text.emitter();
            dst.AppendLine(bitfield.RowHeader());
            bitfield.Format(CellTables,dst);
            AppSvc.FileEmit(dst.Emit(), 23, XedPaths.RuleTargets().Path("xed.rules.bits", FileKind.Csv));

            var bits = bitfield.Bits(CellTables);
            for(var i=0; i<bits.Count; i++)
            {
                ref readonly var field = ref bits[i];
                Write(bitfield.Format(field));
            }

            return true;
        }
    }
}