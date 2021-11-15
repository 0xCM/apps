//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;
    using static Msg;

    [ApiHost]
    public class AsmEtl : AppService<AsmEtl>
    {
        public ReadOnlySpan<TextLine> EmitThumbprints(SortedSpan<AsmEncodingInfo> src, FS.FilePath dst)
        {
            var count = src.Length;
            var emitting = EmittingFile(dst);
            var lines = span<TextLine>(count);
            using var writer = dst.Writer();
            for(var i=0u; i<count; i++)
            {
                var content = AsmRender.thumbprint(src[i]);
                writer.WriteLine(content);
                seek(lines,i) = (i,content);
            }
            EmittedFile(emitting, count);
            return lines;
        }

        public void EmitThumbprints(SortedSpan<ProcessAsmRecord> src, FS.FilePath dst)
            => EmitThumbprints(asm.encodings(src), dst);

        public SortedSpan<AsmThumbprint> EmitThumbprints(ReadOnlySpan<HostAsmRecord> src, FS.FilePath dst)
        {
            var distinct = asm.thumbprints(src);
            asm.emit(distinct, dst);
            return distinct;
        }

        public ReadOnlySpan<AsmDataBlock> DistillBlocks(ReadOnlySpan<HostAsmRecord> records)
        {
            var count = records.Length;
            var buffer = alloc<AsmDataBlock>(count);
            ref var dst = ref first(buffer);
            var block = MemoryAddress.Zero;
            var skipping = false;
            var key = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(records,i);
                ref readonly var BlockAddress = ref record.BlockAddress;
                ref readonly var Expression = ref record.Expression;
                var newblock = (block != BlockAddress);
                if(!newblock && skipping)
                    continue;

                if(newblock)
                {
                    block = BlockAddress;
                    skipping = false;
                }

                if(Expression.IsInvalid)
                {
                    skipping = true;
                    continue;
                }

                ref var target = ref seek(dst, key++);
                target.Key = key;
                target.BlockAddress = BlockAddress;
                target.IP = record.IP;
                target.BlockOffset = record.BlockOffset;
                target.Expression = Expression.Format();
                target.Encoded = record.Encoded.Format();
                target.Bitstring = record.Bitstring.Format();
                target.Sig = record.Sig.Format();
                target.OpCode = record.OpCode.Format();
            }

            return slice(@readonly(buffer), 0, key);
        }

        public void EmitBlocks(ReadOnlySpan<AsmDataBlock> src, FS.FilePath dst)
        {
            TableEmit(src, AsmDataBlock.RenderWidths, TextEncodingKind.Asci, dst);
        }

        public Index<HostAsmRecord> LoadHostAsmRows(FS.FolderPath src, bool pll = true, bool sort = true)
        {
            var files = src.Files(FS.Csv, true);
            var flow = Running(LoadingStatements.Format(src));
            var counter = 0u;
            var dst = bag<HostAsmRecord>();
            if(pll)
            {
                Status(LoadingDocs.Format(files.Length));
                var docs = TextGrids.load(files);
                Status(ParsingDocs.Format(docs.Length));
                var results = AsmParser.rows(docs, dst);
                foreach(var result in results)
                    result.OnSuccess(count => counter+=count).OnFailure(msg => Error(msg));
            }
            else
            {
                foreach(var file in files)
                {
                    var result = TextGrids.load(file, out var grid);
                    if(result.Fail)
                    {
                        Error(result.Message);
                        continue;
                    }

                    var parsed = AsmParser.rows(grid, dst);
                    if(parsed.Fail)
                        Error(FileParseError.Format(file, result.Message));
                    else
                        counter += parsed.Data;
                }
            }

            Ran(flow, ParsedStatements.Format(counter));

            var records = dst.ToArray();
            if(sort)
                Array.Sort(records);
            return records;
        }
    }
}