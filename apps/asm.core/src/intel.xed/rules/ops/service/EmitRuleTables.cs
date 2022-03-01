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
        FS.FilePath EmitRuleTables(ReadOnlySpan<RuleTable> src, FS.FilePath dst)
        {
            var count = src.Length;
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref skip(src,i);
                writer.WriteLine(table.Format());
            }
            EmittedFile(emitting,count);
            return dst;
        }
    }
}