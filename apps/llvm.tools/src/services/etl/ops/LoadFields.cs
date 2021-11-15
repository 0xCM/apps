//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using records;

    using static core;

    partial class LlvmRecordEtl
    {
        void LoadFields(ReadOnlySpan<TextLine> src, in LineInterval<Identifier> interval, ref int k, Span<RecordField> dst)
        {
            ref readonly var min = ref interval.MinLine;
            ref readonly var max = ref interval.MaxLine;
            var length = interval.LineCount;
            var offset = min - 1;
            for(var j=offset; j<length+offset; j++)
            {
                ref readonly var line = ref skip(src,j);
                var content = line.Content.Trim();
                ref var field = ref seek(dst, k++);
                field.RecordName = text.trim(interval.Id);
                if(text.index(content, Chars.Space, out var i0))
                {
                    field.DataType = text.trim(text.left(content,i0));
                    var namedValue = text.right(content,i0);
                    if(text.index(namedValue, Chars.Space, out var i1))
                    {
                        field.Name = text.trim(text.left(namedValue,i1));
                        if(text.index(namedValue, Chars.Eq, out var i2))
                        {
                            if(text.index(namedValue, Chars.Semicolon, out var i3))
                                field.Value = text.trim(text.inside(namedValue, i2, i3).Replace(Chars.Pipe,Chars.Caret));
                        }
                    }
                }
            }
        }

        public Index<RecordField> LoadFields(ReadOnlySpan<TextLine> records, LineMap<Identifier> map)
        {
            var result = Outcome.Success;
            var icount = map.IntervalCount;
            var lcount = map.LineCount;
            var intervals = map.Intervals;
            var buffer = alloc<RecordField>(lcount);
            var k = 0;
            for(var i=0u; i<icount; i++)
                LoadFields(records, skip(intervals,i), ref k, buffer);
            return buffer;
        }
    }
}