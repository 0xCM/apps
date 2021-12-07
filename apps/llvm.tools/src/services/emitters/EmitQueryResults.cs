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
        public uint EmitQueryResults<T>(Label query, ReadOnlySpan<T> results)
        {
            var count = (uint)results.Length;
            var file = FS.file(text.replace(query.Format(), Chars.FSlash, Chars.Dot),FS.Txt);
            var dst = LlvmPaths.Queries() + file;
            var emitting = EmittingFile(dst);
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(string.Format("{0,-6} {1}",i, skip(results,i)));
            EmittedFile(emitting,count);
            return count;
        }
    }
}