//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames;

    using System;

    partial class LlvmDataProvider
    {
        public ReadOnlySpan<RecordField> SelectFields(string dsid, uint offset, uint length)
            => slice(SelectFields(dsid).View, offset,length);

        public Index<RecordField> SelectFields(string dsid)
        {
            return (Index<RecordField>)DataSets.GetOrAdd(dsid + ".fields", key => Load());

            Index<RecordField> Load()
            {
                var running = Wf.Running("Loading " + dsid);

                var src = LlvmPaths.Table(dsid);
                var count = FS.linecount(src);
                var result = Outcome.Success;
                var dst = alloc<RecordField>(count.Lines);
                var counter = 0u;
                using var reader = src.Utf8LineReader();
                var id = Identifier.Empty;
                var i = 0u;
                var j = 0u;
                while(reader.Next(out var line))
                {
                    result = parse(line, out var field);
                    if(result.Fail)
                    {
                        Wf.Error(result.Message);
                        break;
                    }
                    dst[counter++] = field;
                }
                Wf.Ran(running);
                return dst;
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

        static Outcome parse(in TextLine src, out RecordField dst)
        {
            var result = Outcome.Success;
            dst = default;
            var parts = src.Split(Z0.Chars.Pipe).Map(x => x.Trim());
            var count = parts.Length;
            if(count < 4)
                return (false, Tables.FieldCountMismatch.Format(4, count));

            dst.RecordName = skip(parts,0);
            dst.DataType = skip(parts,1);
            dst.Name = skip(parts,2);
            dst.Value = skip(parts,3);
            return result;
        }
    }
}