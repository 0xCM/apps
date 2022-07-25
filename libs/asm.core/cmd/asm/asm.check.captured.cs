//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCheckCmd
    {
        void CheckHex()
        {
            var src = AppDb.ApiTargets().Targets("capture");
            CheckPackedHex(src.Root);
        }

        void CheckPackedHex(FS.FolderPath src)
        {
            var ext = FS.ext(FS.ext("parsed"), FS.XPack);
            var files = src.Files(ext).ToReadOnlySpan();
            var count = files.Length;
            var hex = list<ApiHostHex>();
            for(var i=0; i<count; i++)
            {
                var file = skip(files,i);
                var elements = file.FileName.Format().Split(Chars.Dot).ToReadOnlySpan();
                if(elements.Length < 2)
                    continue;

                var part = skip(elements,0);
                var id = ApiParsers.part(part);
                if(id == 0)
                    continue;

                var uri = ApiHostUri.define(id, skip(elements,1));
                hex.Add(new (uri, ApiHex.memory(file)));
            }
        }

        public static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
            => src + host.FileName(FS.PCsv);

        void PackHex(FS.FolderPath src, ApiHostUri host)
        {
            var counter = 0u;
            var memory = ApiHex.memory(csv(src, host));
            var blocks = memory.Sort().View;
            var buffer = span<char>(Pow2.T16);
            var dir = AppDb.ApiTargets("capture.test").Targets(string.Format("{0}.{1}", host.Part.Format(), host.HostName)).Root;
            var count = blocks.Length;
            for(var i=0; i<count; i++)
            {
                var dst = dir + FS.file(string.Format("{0:D5}", i), FS.XArray);
                var length = Hex.hexarray(skip(blocks,i).View, buffer);
                var content = text.format(slice(buffer,0,length));
                using var writer = dst.AsciWriter();
                writer.WriteLine(content);
            }
        }

        void CheckLookups(IApiPack src)
        {
            using var members = ApiCode.LoadEncoded(src, PartId.AsmCore);
            for(var i=0; i<members.MemberCount; i++)
            {
                ref readonly var member = ref members.Member(i);
                ref readonly var token = ref members.Token(i);
                var encoding = members.Encoding(i);
                ref readonly var entry = ref member.EntryAddress;
                ref readonly var entryRb = ref member.EntryRebase;
                ref readonly var target = ref member.TargetAddress;
                ref readonly var targetRb = ref member.TargetRebase;
                ref readonly var uri = ref member.Uri;
            }
        }

        Outcome CheckLookups(IApiPack src, ITextEmitter log)
        {
            var capacity = Pow2.T16;
            var blocks = ApiCode.blocks(src).View;
            var count = blocks.Length;
            var result = Outcome.Success;
            if(count > capacity)
            {
                result = (false, "Insufficient cpacity");
                log.AppendLine(result.Message);
                return result;
            }

            var distinct = blocks.Map(b => b.BaseAddress).ToHashSet();
            if(distinct.Count != count)
            {
                result = (false, string.Format("There should be {0} distinct base addresses and yet there are {1}", count, distinct.Count));
                log.AppendLine(result.Message);
                return result;
            }

            var symbols = MemoryStores.create(capacity);
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                symbols.Deposit(block.BaseAddress, block.Size, block.OpUri.Format());
            }

            log.AppendLine("Creating lookup");

            var lookup = symbols.ToLookup();
            var entries = slice(lookup.Symbols, 0,symbols.EntryCount);
            TableEmit(entries, AppDb.ApiTargets().PrefixedTable<MemorySymbol>("api.addresses"));
            var found = 0;
            var hashes = entries.Map(x => x.HashCode).ToHashSet();
            if(hashes.Count != count)
                log.AppendLineFormat("There should be {0} distinct hash codes and yet there are {1}", count, hashes.Count);

            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                if(lookup.FindIndex(block.BaseAddress, out var index))
                    found++;
            }

            log.AppendLineFormat("Blocks: {0}", count);
            log.AppendLineFormat("Found: {0}", found);

            return true;
        }

        void CheckSize(EncodedMembers src)
        {
            var count = src.MemberCount;
            var rebase = MemoryAddress.Zero;
            var size = 0u;
            for(var i=0; i<count; i++)
            {
                var seg = src.Segment(i);
                rebase = rebase + seg.Size;
                size += seg.Size;
            }

            Require.equal((ByteSize)size, src.CodeSize);
        }

    }
}