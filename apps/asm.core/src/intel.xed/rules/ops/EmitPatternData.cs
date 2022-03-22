//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        void EmitPatternData(Index<InstPattern> src)
            => exec(PllExec,
                () => EmitPatternInfo(src),
                () => EmitPatternDetails(src),
                () => EmitPatternOps(src),
                () => EmitOpCodes(src)
                );

        void EmitPatternInfo(Index<InstPattern> src)
            => TableEmit(XedPatterns.describe(src).View, InstPatternInfo.RenderWidths, XedPaths.Table<InstPatternInfo>());

        void EmitPatternDetails(Index<InstPattern> src)
            => EmitPatternDetails(src, XedPaths.DocTarget(XedDocKind.PatternDetail));

        void EmitPatternOps(Index<InstPattern> src)
            => TableEmit(src.SelectMany(x => x.OpInfo).Sort().View, OpInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));


        void EmitOpCodes(Index<InstPattern> src)
        {
            const string RenderPattern = "{0,-10} | {1,-20} | {2,-16} | {3}";
            var opcodes = CalcOpCodes(src);
            var dst = XedPaths.Targets() + FS.file("xed.opcodes", FS.Csv);
            var emitting = EmittingFile(dst);
            var lookup = src.Map(x => (x.PatternId, x)).ToDictionary();
            using var writer = dst.AsciWriter();
            var count = opcodes.Count;
            writer.AppendLineFormat(RenderPattern, "PatternId", "OpCode", "Class", "Pattern");
            for(var i=0; i<count; i++)
            {
                ref readonly var opcode = ref opcodes[i];
                var pattern = lookup[opcode.PatternId];
                writer.AppendLineFormat(RenderPattern, opcode.PatternId, opcode.Format(), pattern.Class, pattern.BodyExpr);
            }

            EmittedFile(emitting,count);
        }
    }
}