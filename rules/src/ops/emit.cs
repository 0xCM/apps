//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Rules
    {
        public static void emit(ReadOnlySpan<IProduction> src, FS.FilePath dst)
        {
            var count = src.Length;
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i).Format());
        }
    }
}