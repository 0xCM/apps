//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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

        ApiCodeFiles ApiCode => Wf.ApiCodeFiles();

        internal void Deposit(PartResolvedEvent e)
            => inc(ref PartResolvedCount);

        internal void Deposit(HostResolvedEvent e)
            => inc(ref HostResolvedCount);

        internal void Deposit(MemberParsedEvent e)
            => inc(ref MemberParsedCount);

        internal void Deposit(MemberDecodedEvent e)
            => inc(ref MemberDecodedCount);

        internal void Deposit(ExtractErrorEvent e)
            => Wf.Error(e);

        public ResolvedParts Run(in ApiExtractSettings settings)
        {
            var pdb = false;
            var packs = Wf.ApiPacks();
            var pack = ApiCode.Package(settings);
            var collection = Run(pack);
            packs.CreateLink(settings.Timestamp);
            if(pdb)
                Wf.PdbSvc().IndexPdbSymbols(collection.View, pack.Root + FS.file("symbols", FS.Log));
            return collection;
        }

        public ResolvedParts Run(IApiPack dst)
        {
            var flow = Wf.Running(string.Format("Packing api to {0}", dst.Root));
            var collected = Wf.ApiExtractor().Run(EventChannel, dst);
            Wf.Ran(flow);
            return collected;
        }

        public Index<LineCount> CountLines()
        {
            var service = Wf.ApiPacks();
            var pack = service.Current();
            var files = pack.Files(FS.Csv).View;
            var counting = Running(string.Format("Counting lines in {0} files from {1}", files.Length, pack.Root));
            var counts = Lines.linecounts(files);
            iter(counts, c => Wf.Row(c.Format()));
            Ran(counting, string.Format("Counted lines in {0} files", files.Length));
            return counts;
        }
    }
}