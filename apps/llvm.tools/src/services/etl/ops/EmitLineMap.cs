//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    using SQ = SymbolicQuery;

    partial class LlvmRecordEtl
    {
        public LineMap<Identifier> EmitLineMap<T>(ReadOnlySpan<T> relations, ReadOnlySpan<TextLine> records, string dstid)
            where T : struct, ILineRelations<T>
        {
            const uint BufferLength = 256;
            var result = Outcome.Success;
            var linecount = records.Length;
            var count = relations.Length;
            var buffer = span<TextLine>(BufferLength);
            var intervals = list<LineInterval<Identifier>>();
            for(var i=0;i<count; i++)
            {
                ref readonly var relation = ref skip(relations,i);
                var k=0;
                buffer.Clear();
                var index = relation.SourceLine.Value;
                for(var j=index; j<linecount && k<BufferLength; j++)
                {
                    ref readonly var line = ref skip(records,j);
                    ref readonly var content = ref line.Content;
                    if(SQ.index(content, Chars.RBrace) != 0)
                        seek(buffer,k++) = line;
                    else
                        break;
                }

                if(k>0)
                {
                    ref readonly var l0 = ref first(buffer);
                    ref readonly var l1 = ref skip(buffer,k-1);
                    intervals.Add(LineMaps.interval(relation.Name, l0.LineNumber, l1.LineNumber));
                }
            }

            var map = LineMaps.map(intervals.ToArray());
            var dst = LlvmPaths.ImportMap(dstid);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var _intervals = map.Intervals;
            for(var i=0; i<_intervals.Length; i++)
                writer.WriteLine(skip(_intervals,i).Format());

            EmittedFile(emitting, _intervals.Length);
            return map;
        }
    }
}