//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Metadata;

    using static Root;
    using static core;
    using static CliRows;

    partial class CliReader
    {
        public uint Rows(ReadOnlySpan<FieldDefinitionHandle> src, Span<FieldDefRow> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                 Row(skip(src,i), ref seek(dst,i));
            return count;
        }

        public ReadOnlySpan<FieldDefRow> Rows(ReadOnlySpan<FieldDefinitionHandle> src)
        {
            var count = (uint)src.Length;
            var dst = span<FieldDefRow>(count);
            Rows(src,dst);
            return dst;
        }
    }
}