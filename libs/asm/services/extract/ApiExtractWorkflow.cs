//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Diagnostics.Tracing;

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

        static void render(EventWrittenEventArgs src, ITextBuffer dst)
        {
            dst.AppendLine(src.EventName);
            dst.AppendLine(RP.PageBreak80);
            var count = src.Payload.Count;
            for (int i = 0; i<count; i++)
            {
                var name = string.Format("{0,-32}:",src.PayloadNames[i]);
                var payload = string.Format("{0}",src.Payload[i]);
                var message = string.Concat(name,payload);
                dst.AppendLine(message);
            }
        }

        static async void emit(EventWrittenEventArgs src, StreamWriter dst)
        {
            var buffer = text.buffer();
            render(src,buffer);
            await dst.WriteLineAsync(buffer.Emit());
        }

        void Capture()
        {
            using var dst = Db.AppLog("clr-events", FS.Log).Writer();
            void receive(in EventWrittenEventArgs src)
            {
                emit(src,dst);
            }

            using var listener = ClrEventListener.create(receive);
            // var settings = ApiExtractSettings.init(Db.CapturePackRoot(), now());
            // Wf.ApiExtractWorkflow().Run(settings);
        }

        public ResolvedParts Run(in ApiExtractSettings settings)
        {
            var pdb = false;
            var packs = Wf.ApiPacks();
            var ts = core.timestamp();
            var pack = ApiCode.ApiPack(settings.ExtractRoot, ts);
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
            var counts = Lines.count(files);
            iter(counts, c => Wf.Data(c.Format()));
            Ran(counting, string.Format("Counted lines in {0} files", files.Length));
            return counts;
        }
    }
}