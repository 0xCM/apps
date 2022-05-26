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
        Outcome CheckMem()
        {
            var dst = text.emitter();
            var result = CheckLookups(dst);
            return result;
        }

        ApiHex ApiHex => Service(Wf.ApiHex);



        void CheckHex()
        {
            var src = AppDb.ApiTargets().Dir("capture");
            CheckPackedHex(src);
        }

        void CheckPackedHex(FS.FolderPath src)
        {
            var result = Outcome.Success;
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
                Write(uri);

                var blocks = ApiHex.memory(file);
                hex.Add((uri, blocks));
            }
        }

        public static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
            => src + host.FileName(FS.PCsv);

        DbSources CaptureSources()
            => AppDb.ApiTargets("capture").ToSource();

        void ListDescriptors()
        {
            // var descriptors = ApiCode.descriptors(Wf);
            // Wf.Row($"Loaded {descriptors.Count} descriptors");
        }


        void PackHex()
        {

        }
        void PackHex(FS.FolderPath src, ApiHostUri host)
        {
            var counter = 0u;
            var memory = ApiHex.memory(csv(src, host));
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
    }
}