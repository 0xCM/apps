//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class CodeBanks : AppService<CodeBanks>
    {
        ApiDataPaths DataPaths => Service(Wf.ApiDataPaths);

        public ConstLookup<string,AsmCodeBlocks> DistillBlocks(ReadOnlySpan<ObjDumpRow> src, AsmDispenser dispenser)
        {
            var count = src.Length;
            var collector = new AsmBlockCollector();
            var collected = dict<string, AsmCodeBlocks>();
            var docid = first(src).DocId;
            var docname = first(src).Source.Path.FileName.Format();
            var length = 0u;
            var offset = 0u;
            for(var i=0u; i<count; i++)
            {
                if(skip(src,i).DocId != docid)
                {
                    collected.Add(docname, Collect(docname,slice(src, offset, length), dispenser));
                    offset = i;
                    length = 0;
                    docname = skip(src,i).Source.Path.FileName.Format();
                    docid = skip(src,i).DocId;
                }

                length++;
            }

            if(length != 0)
            {
                collected.Add(docname, Collect(docname,slice(src, offset,length), dispenser));
            }

            return collected;
        }

        public void Emit(ConstLookup<string,AsmCodeBlocks> src, FS.FolderPath dir)
        {
            var names = src.Keys;
            var count = names.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(names,i);
                var dst = dir + FS.file(string.Format("{0}.code", name), FS.Csv);
                Emit(src[name],dst);
            }
        }

        AsmCodeBlocks Collect(string origin, ReadOnlySpan<ObjDumpRow> src, AsmDispenser dispenser)
        {
            var collector = new AsmBlockCollector();
            var count = src.Length;
            for(var i=0; i<count; i++)
                collector.Include(src[i]);
            return dispenser.CodeBlocks(origin, collector.Emit());
        }

        void Emit(in AsmCodeBlocks src, FS.FilePath dst)
        {
            var buffer = alloc<AsmCodeRecord>(src.LineCount);
            var k=0u;
            var distinct = hashset<Hex64>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var count = block.LineCount;
                for(var j=0; j<count; j++, k++)
                {
                    ref readonly var code = ref block[j];
                    ref var record = ref seek(buffer,k);
                    record.Origin = src.Origin;
                    record.Id = AsmBytes.identify(code.IP, code.Encoding);
                    record.BlockBase = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Encoded = code.Encoded;
                    record.Size = code.Encoded.Size;
                    record.Asm = code.Asm;

                    if(!distinct.Add(record.Id))
                    {
                        Warn(string.Format("Duplicate identifier:{0}", record.Id));
                    }
                }
            }


            TableEmit(@readonly(buffer), AsmCodeRecord.RenderWidths, dst);
        }

        public EncodingBank Encoding()
        {
            var result = LoadCollected(out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return EncodingBank.load(index,code);
        }

        public EncodingBank Encoding(string spec)
        {
            var result = Outcome.Success;
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    return Encoding(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    return Encoding(ApiParsers.part(spec));
            }
            else
            {
                return Encoding();
            }
        }

        public EncodingBank Encoding(PartId src)
        {
            var result = LoadCollected(src, out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return EncodingBank.load(index,code);
        }

        public EncodingBank Encoding(ApiHostUri src)
        {
            var result = LoadCollected(src, out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return EncodingBank.load(index,code);
        }

        Outcome LoadCollected(PartId src, out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(src,FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(src,FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadCollected(out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadCollected(ApiHostUri src, out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(src, FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(src, FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadIndex(FS.FilePath src, out Index<EncodedMemberInfo> dst)
        {
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            dst = alloc<EncodedMemberInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i + 1];
                result = parse(line, out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        Outcome LoadData(FS.FilePath path, out BinaryCode dst)
        {
            var result = Outcome.Success;
            var cells = path.ReadLines().SelectMany(x => text.split(x,Chars.Space));
            var count = cells.Count;
            var data = alloc<byte>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref cells[i];
                result = HexParser.parse8u(cell, out seek(data,i));
                if(result.Fail)
                    break;
            }
            if(result)
                dst = data;
            else
                dst = BinaryCode.Empty;
            return result;
        }

        static Outcome parse(string src, out EncodedMemberInfo dst)
        {
            const byte FieldCount = EncodedMemberInfo.FieldCount;
            dst = default;
            var cells = text.split(src, Chars.Pipe);
            var count = cells.Length;
            if(count != FieldCount)
                return (false, AppMsg.CsvDataMismatch.Format(FieldCount,count, src));

            var result = Outcome.Success;
            var i=0;
            result = DataParser.parse(skip(cells,i++), out dst.Id);
            result = DataParser.parse(skip(cells,i++), out dst.EntryAddress);
            result = DataParser.parse(skip(cells,i++), out dst.EntryRebase);
            result = DataParser.parse(skip(cells,i++), out dst.TargetAddress);
            result = DataParser.parse(skip(cells,i++), out dst.TargetRebase);
            result = DataParser.parse(skip(cells,i++), out dst.StubAsm);
            result = Disp32.parse(skip(cells,i++), out dst.Disp);
            result = DataParser.parse(skip(cells,i++), out dst.CodeSize);
            dst.Host = text.trim(skip(cells,i++));
            dst.Sig = text.trim(skip(cells,i++));
            dst.Uri = text.trim(skip(cells,i++));
            return result;
        }
    }
}