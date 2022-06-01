//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("mem/check")]
        void CheckMem()
        {


        }

        ApiCode ApiCode => Wf.ApiCode();

        ApiHex ApiHex => Service(Wf.ApiHex);

        void CheckHex()
        {
            var src = AppDb.ApiTargets().Dir("capture");
            CheckPackedHex(src);
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
                hex.Add(new (uri, ApiHexPacks.memory(file)));
            }
        }

        public static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
            => src + host.FileName(FS.PCsv);


        void PackHex(FS.FolderPath src, ApiHostUri host)
        {
            var counter = 0u;
            var memory = ApiHexPacks.memory(csv(src, host));
            var blocks = memory.Sort().View;
            var buffer = span<char>(Pow2.T16);
            var dir = AppDb.ApiTargets("capture.test").Dir(string.Format("{0}.{1}", host.Part.Format(), host.HostName));
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

        void CheckLookups()
        {
            using var members = ApiCode.Load(PartId.AsmCore);
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
        Outcome CheckLookups(ITextEmitter log)
        {
            var capacity = Pow2.T16;
            var blocks = ApiHex.ReadBlocks().View;
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

            var symbols = MemorySymbols.create(capacity);
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                symbols.Deposit(block.BaseAddress, block.Size, block.OpUri.Format());
            }

            log.AppendLine("Creating lookup");

            var lookup = symbols.ToLookup();
            var entries = slice(lookup.Symbols, 0,symbols.EntryCount);
            AppSvc.TableEmit(entries, AppDb.ApiTargets().Table<MemorySymbol>("api.addresses"));
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

        [CmdOp("asm/check/captured")]
        Outcome CheckCaptured2(CmdArgs args)
        {
            var result = Outcome.Success;
            var spec = EmptyString;
            if(args.Count != 0)
                spec = text.trim(arg(args,0).Value.Format());
            using var members = ApiCode.Load(spec);
            CheckSize(members);

            return result;
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

        [CmdOp("asm/check/capture-spec")]
        Outcome CheckCapturedSpec(CmdArgs args)
        {
            var result = Outcome.Success;
            var spec = EmptyString;
            if(args.Count != 0)
                spec = text.trim(arg(args,0).Value.Format());

            const string RenderPattern = "{0,-8} | {1, -8} | {2,-8} | {3,-5} | {4,-8} | {5,-8} | {6,-32} | {7}";
            using var members = ApiCode.Load(spec);
            var count = members.MemberCount;
            var target = MemoryAddress.Zero;
            var size = 0;
            var delta = 0;
            var blocksz = 0;
            var blockct = 0;
            var blockmem = 0u;
            for(var i=0; i<count; i++)
            {
                var code = members.Code(i);
                ref readonly var token = ref members.Token(i);
                delta = (int)(token.TargetAddress - (target + size));
                blocksz += (int)(token.TargetAddress - target);
                target = token.TargetAddress;
                size = code.Length;
                var flair = delta >= PageBlock.PageSize ? FlairKind.StatusData : FlairKind.Data;
                if(delta >= PageBlock.PageSize)
                {
                    flair = FlairKind.StatusData;
                    blocksz = 0;
                    blockmem = 0;
                    blockct++;
                }
                else
                {
                    blockmem++;
                    flair = FlairKind.Data;
                }

                Write(string.Format(RenderPattern, i, blockmem, target, size, delta, blocksz, token.Host, token.Sig), flair);
            }

            return result;
        }
    }
}