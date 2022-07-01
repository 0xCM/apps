//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmLineMaps : WfSvc<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths => Wf.LlvmPaths();

        LlvmDataCalcs DataCalcs => Wf.LlvmDataCalcs();

        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        public void EmitLineMaps()
            => EmitLineMaps(data("lines",() => DataProvider.RecordLines(LlvmTargetName.x86)));

        void EmitLineMaps(Index<TextLine> src)
        {
            exec(true,
                () => EmitLineMap(src, DataCalcs.CalcClassRelations(src)),
                () => EmitLineMap(src, DataCalcs.CalcDefRelations(src))
                );
        }

        public static LineMap<Identifier> calc<T>(string name, Index<TextLine> lines, Index<T> relations)
            where T : struct, ILineRelations<T>
        {
            const uint BufferLength = 256;
            var result = Outcome.Success;
            var linecount = lines.Length;
            var count = relations.Length;
            var buffer = span<TextLine>(BufferLength);
            var intervals = list<LineInterval<Identifier>>();
            for(var i=0;i<count; i++)
            {
                ref readonly var relation = ref relations[i];
                var k=0;
                buffer.Clear();
                var index = relation.SourceLine.Value;
                for(var j=index; j<linecount && k<BufferLength; j++)
                {
                    ref readonly var line = ref lines[j];
                    if(SQ.index(line.Content, Chars.RBrace) != 0)
                        seek(buffer,k++) = line;
                    else
                        break;
                }

                if(k>0)
                    intervals.Add(Lines.interval(relation.Name, first(buffer).LineNumber, skip(buffer,k-1).LineNumber));
            }

            return Lines.map(intervals.ToArray());
        }

        void EmitLineMap(Index<TextLine> lines, Index<DefRelations> relations)
            => EmitLineMap(relations, lines, LlvmDatasets.dataset(LlvmTargetName.x86).Defs);

        void EmitLineMap(Index<TextLine> lines, Index<ClassRelations> relations)
            => EmitLineMap(relations, lines, LlvmDatasets.dataset(LlvmTargetName.x86).Classes);

        public LineMap<Identifier> EmitLineMap<T>(Index<T> src, Index<TextLine> records, string name)
            where T : struct, ILineRelations<T>
        {
            // const uint BufferLength = 256;
            // var result = Outcome.Success;
            // var linecount = records.Length;
            // var count = src.Length;
            // var buffer = span<TextLine>(BufferLength);
            // var intervals = list<LineInterval<Identifier>>();
            // for(var i=0;i<count; i++)
            // {
            //     ref readonly var relation = ref skip(src,i);
            //     var k=0;
            //     buffer.Clear();
            //     var index = relation.SourceLine.Value;
            //     for(var j=index; j<linecount && k<BufferLength; j++)
            //     {
            //         ref readonly var line = ref skip(records,j);
            //         if(SQ.index(line.Content, Chars.RBrace) != 0)
            //             seek(buffer,k++) = line;
            //         else
            //             break;
            //     }

            //     if(k>0)
            //         intervals.Add(Lines.interval(relation.Name, first(buffer).LineNumber, skip(buffer,k-1).LineNumber));
            // }

            // var map = Lines.map(intervals.ToArray());
            var map = calc(name, records, src);
            var dst = LlvmPaths.ImportMap(name);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<map.IntervalCount; i++)
                writer.WriteLine(map[i].Format());
            EmittedFile(emitting, map.IntervalCount);
            return map;
        }
    }
}