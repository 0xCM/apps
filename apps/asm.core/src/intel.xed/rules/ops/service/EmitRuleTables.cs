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
        internal static string format(in RuleTable src)
        {
            var dst = text.buffer();
            if(src.ReturnType.IsNonEmpty)
                dst.AppendLineFormat("{0} {1}()", src.ReturnType, src.Name);
            else
                dst.AppendLineFormat("{0}()", src.Name);
            var expressions = src.Expressions.View();
            var count = expressions.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
                dst.IndentLine(4, skip(expressions, i).Format());
            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

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