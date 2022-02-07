//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
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
                if(table.ReturnType.IsNonEmpty)
                    writer.WriteLine(string.Format("{0} {1}()", table.ReturnType, table.Name));
                else
                    writer.WriteLine(string.Format("{0}()", table.Name));
                writer.WriteLine("{");
                foreach(var expr in table.Expressions)
                    writer.WriteLine(string.Format("    {0}", expr.Format()));
                writer.WriteLine("}");
                writer.WriteLine();
            }
            EmittedFile(emitting,count);
            return dst;
        }
    }
}