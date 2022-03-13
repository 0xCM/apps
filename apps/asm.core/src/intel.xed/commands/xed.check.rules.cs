//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var path = AppDb.Log("xed.rules.tables.dec", FileKind.Txt);
            var emitting = EmittingFile(path);
            using var dst = path.AsciWriter();
            var src = Xed.Rules.CalcDecTables();
            var sigs = src.Keys.ToArray().Sort();
            var count = sigs.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(src[skip(sigs,i)].Format());
            EmittedFile(emitting, sigs.Length);
            return true;
        }
    }
}