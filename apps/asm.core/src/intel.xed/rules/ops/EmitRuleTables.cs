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
        void EmitEncRuleTables()
        {
            var src = CalcEncRuleTables();
            EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncRuleTable));
            ExpandMacros(src);
            EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncRuleTableExp));
        }

        void EmitDecRuleTables()
        {
            var src = CalcDecRuleTables();
            EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.DecRuleTable));
            ExpandMacros(src);
            EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.DecRuleTableExp));
        }

        void EmitEncDecRuleTables()
        {
            var src = CalcEncDecRuleTables();
            EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncDecRuleTable));
            ExpandMacros(src);
            EmitRuleTables(src, XedPaths.DocTarget(XedDocKind.EncDecRuleTableExp));
        }

        FS.FilePath EmitRuleTables(ReadOnlySpan<RuleTermTable> src, FS.FilePath dst)
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