//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class XedRules
    {
        Index<RuleTable> EmitEncRuleTables()
        {
            var src = CalcEncRuleTables();
            EmitEncRuleTables(src);
            return src;
        }

        Index<RuleTable> EmitDecRuleTables()
        {
            var src = CalcDecRuleTables();
            EmitDecRuleTables(src);
            return src;
        }

        Index<RuleTable> EmitEncDecRuleTables()
        {
            var src = CalcEncDecRuleTables();
            EmitEncDecRuleTables(src);
            return src;
        }

        FS.FilePath EmitEncRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncRuleTable));

        FS.FilePath EmitDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.DecRuleTable));

        FS.FilePath EmitEncDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncDecRuleTable));

        FS.FilePath EmitRuleTables(ReadOnlySpan<RuleTable> src, FS.FilePath dst)
        {
            var count = src.Length;
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i).Format());
            EmittedFile(emitting,count);
            return dst;
        }
    }
}