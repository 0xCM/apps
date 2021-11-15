//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public class ApiHexPacks : AppService<ApiHexPacks>
    {
        public Lookup<FS.FilePath,MemoryBlocks> LoadParsed(FS.FolderPath src)
            => Load(src.Files(".parsed", FS.XPack, true));

        public MemoryBlocks LoadBlocks(FS.FolderPath root)
        {
            var entries = LoadParsed(root).Entries;
            var count = entries.Length;
            var buffer = list<MemoryBlock>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                ref readonly var pack = ref entry.Value;
                var blocks = pack.View;
                for(var j=0; j<blocks.Length; j++)
                {
                    ref readonly var block = ref skip(blocks,j);
                    buffer.Add(block);
                }
            }

            buffer.Sort();
            return new MemoryBlocks(buffer.ToArray());
        }

        public Lookup<FS.FilePath,MemoryBlocks> Load(FS.Files src)
        {
            var flow = Running(string.Format("Loading {0} packs", src.Length));
            var lookup = new Lookup<FS.FilePath,MemoryBlocks>();
            var errors = new Lookup<FS.FilePath,Outcome>();
            iter(src, path => load(path, lookup, errors), true);
            var result = lookup.Seal();
            var count = result.EntryCount;
            var entries = result.Entries;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var path = entry.Key;
                var blocks = entry.Value.View;
                var blockCount = (uint)blocks.Length;
                var host = path.FileName.Format().Remove(".extracts.parsed.xpack").Replace(".","/");
                Write(string.Format("Loaded {0} blocks from {1}", blockCount, path.ToUri()));
                counter += blockCount;
            }

            Ran(flow, string.Format("Loaded {0} total blocks", counter));

            return result;
        }

        [Op]
        public Index<HexPacked> Pack(SortedIndex<ApiCodeBlock> src, bool validate = false)
        {
            const ushort BufferLength = 48400;

            var blocks = src.View;
            var count = blocks.Length;
            var packs = alloc<HexPacked>(count);
            var chars = alloc<char>(BufferLength);
            ref var dst = ref first(packs);
            var size = MemoryStore.pack(blocks, packs, chars);
            if(validate)
            {
                var buffer = span<HexDigitValue>(BufferLength);
                var flow = Running("Validating pack");
                for(var i=0; i<count; i++)
                {
                    buffer.Clear();
                    ref readonly var pack = ref skip(dst,i);
                    var outcome = Hex.digits(pack.Data,buffer);
                    if(!outcome)
                    {
                        Error("Reconstitution failed");
                        break;
                    }
                }
                Ran(flow,$"Validated {count} packs");
            }

            return packs;
        }

        [Op]
        public Index<HexPacked> Emit(SortedIndex<ApiCodeBlock> src, FS.FilePath? dst = null, bool validate = false)
        {
            var _dst = dst ?? Db.DbTableRoot() + FS.file("apihex", FS.ext("xpack"));
            var result = Pack(src, validate);
            var packed = result.View;
            var emitting = EmittingFile(_dst);
            using var writer = _dst.Writer();
            var count = packed.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(packed,i).Format());
            EmittedFile(emitting, count);
            return result;
        }

        [Op]
        public ByteSize Emit(in MemoryBlocks src, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            var total = MemoryStore.emit(src, writer);
            EmittedFile(flow, (uint)total);
            return total;
        }

        [Op]
        public ByteSize Emit(in MemoryBlock src, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            var total = MemoryStore.emit(MemoryStore.pack(src), writer);
            EmittedFile(flow, (uint)total);
            return total;
        }

        static void load(FS.FilePath src, Lookup<FS.FilePath,MemoryBlocks> success, Lookup<FS.FilePath,Outcome> fail)
        {
            var result = ApiHex.load(src, out var pack);
            if(result.Fail)
                fail.Add(src, result);
            else
                success.Add(src, pack);
        }
    }
}