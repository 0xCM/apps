//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/patterns")]
        Outcome CheckPatterns(CmdArgs args)
        {
            var result = Outcome.Success;
            var descriptions = Xed.Rules.LoadPatternInfo();
            var path = AppDb.XedPath("xed.rules.patterns.checks", FileKind.Csv);
            var emitting = EmittingFile(path);
            var patterns = Xed.Rules.CalcPatterns();
            var count = Require.equal(patterns.Length,descriptions.Length);
            using var writer = path.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var info = ref descriptions[i];
                var expr = info.BodyExpr;
                var parts = text.split(text.despace(text.trim(expr)), Chars.Space);
                var pad = -32;
                var sep = " | ";
                writer.WriteLine("{0,-16} | {1,-12} | {2}", info.Class, AsmOcValue.format(XedRules.ocvalue(pattern.Tokens)), XedRender.format(info.OpCodeKind));
                writer.WriteLine(expr);
                writer.WriteLine(text.delimit(parts, sep, pad));
                writer.WriteLine(text.delimit(pattern.Tokens, sep, pad));
                var tokens = pattern.Tokens;
                writer.WriteLine(text.delimit(tokens, sep, pad));
                var expanded = text.delimit(tokens.Map(x => XedRender.format(x))," ");
                writer.WriteLine(expanded);
                writer.WriteLine(RP.PageBreak1024);
            }

            EmittedFile(emitting,count);

            return result;
        }
    }
}