//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataEmitter
    {
        public uint EmitQueryResults<T>(string query, ReadOnlySpan<T> results)
            => EmitQueryResults(query, string.Empty, results);

        public uint EmitQueryResults<T>(string query, string args, ReadOnlySpan<T> src)
        {
            var count = (uint)src.Length;
            var discriminator = text.empty(args) ? string.Empty : "-" + args;
            var file = FS.file(text.replace(query, Chars.FSlash, Chars.Dot) + discriminator,FS.Txt);
            var dst = LlvmPaths.QueryResult(file);
            var emitting = EmittingFile(dst);
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i));
            EmittedFile(emitting,count);
            return count;
        }

        public uint EmitQueryTable<T>(string query, string args, ReadOnlySpan<T> results)
            where T : struct
        {
            var count = (uint)results.Length;
            var tag = text.empty(args) ? string.Empty : "-" + args;
            var dst = LlvmPaths.QueryTable<T>(tag);
            return TableEmit(results, dst);
        }
    }
}