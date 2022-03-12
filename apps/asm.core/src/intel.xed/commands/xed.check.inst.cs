//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/inst")]
        Outcome CheckInstDefs(CmdArgs args)
        {
            var parsers = XedParsers.Service;
            var dst = AppDb.Log("xed.inst.body", FileKind.Txt);
            using var writer = dst.AsciWriter();
            var emitting = EmittingFile(dst);
            var result = Outcome.Success;
            var patterns = Xed.Rules.LoadPatternInfo();
            var count = patterns.Count;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var source = ref pattern.BodyExpr;
                writer.AppendLineFormat("Source -> {0}", source);
                result = parsers.Parse(source, out InstPatternBody body);
                if(result.Fail)
                    break;

                XedRender.render(body,buffer);
                var target = buffer.Emit();
                writer.AppendLineFormat("Target <- {0}", target);
                writer.AppendLine();

                if(source != target)
                    Warn("'{0}' != '{1}'", source, target);
            }

            EmittedFile(emitting, count);

            return result;
        }

    }
}