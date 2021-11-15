//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using static core;

    public class ApiExtractWorkflow : AppService<ApiExtractWorkflow>
    {
        int MemberDecodedCount;

        int MemberParsedCount;

        int HostResolvedCount;

        int PartResolvedCount;

        ApiExtractChannel EventChannel;

        public ApiExtractWorkflow()
        {
            MemberDecodedCount = 0;
            MemberParsedCount = 0;
            HostResolvedCount = 0;
            PartResolvedCount = 0;
            EventChannel = new();
            EventChannel.Enlist(this);
        }

        internal void Deposit(PartResolvedEvent e)
        {
            inc(ref PartResolvedCount);
        }

        internal void Deposit(HostResolvedEvent e)
        {

            inc(ref HostResolvedCount);
        }

        internal void Deposit(MemberParsedEvent e)
        {
            inc(ref MemberParsedCount);
        }

        internal void Deposit(MemberDecodedEvent e)
        {
            inc(ref MemberDecodedCount);
        }

        internal void Deposit(ExtractErrorEvent e)
        {
            Wf.Error(e);
        }

        public ApiCollection Run(in ApiExtractSettings settings)
        {
            var pdb = false;
            var packs = Wf.ApiPacks();
            var pack = packs.Create(settings);
            var collection = Run(pack);
            packs.CreateLink(settings.Timestamp);
            if(pdb)
                IndexPdbSymbols(collection.ResolvedParts, pack.Root + FS.file("symbols", FS.Log));
            return collection;
        }

        public ApiCollection Run(CmdArgs args)
        {
            return Run(ApiExtractSettings.init(Db.CapturePackRoot(), now()));
        }

        void IndexPdbSymbols(ReadOnlySpan<ResolvedPart> parts, FS.FilePath dst)
        {
            var count = parts.Length;
            var emitting = Wf.EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                counter += IndexPdbMethods(skip(parts,i),writer);
            Wf.EmittedFile(emitting, counter);
        }

        uint IndexPdbMethods(ResolvedPart src, StreamWriter dst)
        {
            var modules = Wf.AppModules();
            var hosts = src.Hosts.View;
            using var symbols = modules.SymbolSource(src.Location);
            var reader = Wf.PdbReader(symbols);
            var flow = Wf.Running(string.Format("Indexing symbols for {0} from {1}", symbols.PePath, symbols.PdbPath));
            var counter = 0u;
            var buffer = list<PdbModel.Method>();
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var methods = host.Methods.View;
                for(var j=0; j<methods.Length; j++)
                {
                    ref readonly var method = ref skip(methods,j);
                    var pdbMethod = reader.Method(method.Method.MetadataToken);
                    if(pdbMethod)
                    {
                        var data = pdbMethod.Payload;
                        dst.WriteLine(data.Token.Format());
                        buffer.Add(data);
                        counter++;
                    }
                }
            }
            Wf.Ran(flow);
            return counter;
        }

        public ApiCollection Run(IApiPack dst)
        {
            var flow = Wf.Running();
            var collected = Wf.ApiExtractor().Run(EventChannel, dst);
            Wf.Ran(flow);
            return collected;
        }

        public Index<LineCount> CountLines()
        {
            var service = Wf.ApiPacks();
            var pack = service.Current();
            var files = pack.Files(FS.Csv).View;
            var counting = Wf.Running(string.Format("Counting lines in {0} files from {1}", files.Length, pack.Root));
            var counts = FS.linecounts(files);
            iter(counts, c => Wf.Row(c.Format()));
            Wf.Ran(counting, string.Format("Counted lines in {0} files", files.Length));
            return counts;
        }
    }
}