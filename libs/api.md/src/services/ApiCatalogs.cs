//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    public class ApiCatalogs : WfSvc<ApiCatalogs>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        ApiHex ApiHex => Wf.ApiHex();

        public void Rebase(ApiMembers members, IApiPack dst)
        {
            var flow = Running("Rebasing members");
            Rebase(members, dst.Table<ApiCatalogEntry>());
            Ran(flow);
        }

        public Index<ApiCatalogEntry> Rebase(ApiMembers src, FS.FilePath dst)
        {
            var records = rebase(src.BaseAddress, src.View);
            TableEmit(records, dst);
            return records;
        }

        public Index<ApiCatalogEntry> LoadApiCatalog(FS.FilePath src)
        {
            var rows = list<ApiCatalogEntry>();
            using var reader = src.Utf8Reader();
            reader.ReadLine();
            var line = reader.ReadLine();
            while(line != null)
            {
                var outcome = parse(line, out ApiCatalogEntry row);
                if(outcome)
                    rows.Add(row);
                else
                {
                    Error(outcome.Message);
                    return array<ApiCatalogEntry>();
                }
                line = reader.ReadLine();
            }
            return rows.ToArray();
        }

        public Index<ApiCatalogEntry> Load(FS.FolderPath dir)
        {
            var files = dir.Files(FS.Csv).Where(f => f.FileName.StartsWith(ApiCatalogEntry.TableId)).OrderBy(f => f.Name).ToReadOnlySpan();
            var count = files.Length;
            var rows = sys.empty<ApiCatalogEntry>();
            if(count != 0)
            {
                ref readonly var current = ref skip(files,count - 1);
                var flow = Running(Msg.LoadingApiCatalog.Format(current));
                rows = LoadApiCatalog(current);
                Ran(flow, Msg.LoadedApiCatalog.Format(rows.Length, current));
            }

            return rows;
        }

        public static Index<ApiCatalogEntry> rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> src)
        {
            var dst = alloc<ApiCatalogEntry>(src.Length);
            rebase(@base, src, dst);
            return dst;
        }

        public static uint rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> members, Span<ApiCatalogEntry> dst)
        {
            var count = members.Length;
            var rebase = first(members).BaseAddress;
            for(uint seq=0; seq<count; seq++)
            {
                ref var record = ref seek(dst,seq);
                ref readonly var member = ref skip(members, seq);
                record.Sequence = seq;
                record.ProcessBase = @base;
                record.MemberBase = member.BaseAddress;
                record.MemberOffset = member.BaseAddress - @base;
                record.MemberRebase = (uint)(member.BaseAddress - rebase);
                record.MaxSize = seq < count - 1 ? (ulong)(skip(members, seq + 1).BaseAddress - record.MemberBase) : 0ul;
                record.HostName = member.Host.HostName;
                record.PartName = member.Host.Part.Format();
                record.OpUri = member.OpUri;
            }
            return (uint)count;
        }

        public Index<ApiMemberCode> Correlate()
            => Correlate(ApiRuntimeCatalog.PartCatalogs());

        public Index<ApiMemberCode> Correlate(FS.FilePath dst)
            => Correlate(ApiRuntimeCatalog.PartCatalogs(), dst);

        public Index<ApiMemberCode> Correlate(ReadOnlySpan<IApiPartCatalog> src)
            => Correlate(src, FS.FilePath.Empty);

        public Index<ApiMemberCode> Correlate(ReadOnlySpan<IApiPartCatalog> src, FS.FilePath path)
        {
            var flow = Running(Msg.CorrelatingParts.Format(src.Length));
            var count = src.Length;
            var code = list<ApiMemberCode>();
            var records = list<ApiCorrelationEntry>();
            for(var i=0; i<count; i++)
            {
                var part = skip(src,i);
                var inner = Running(Msg.CorrelatingOperations.Format(part.PartId.Format()));
                var hosts = part.ApiHosts.View;
                for(var j=0; j<hosts.Length; j++)
                {
                    ref readonly var srcHost = ref skip(hosts,j);
                    //var hexpath = Db.ParsedExtractPath(srcHost.HostUri);
                    var hexpath = FS.FilePath.Empty;
                    if(hexpath.Exists)
                    {
                        Require.invariant(ApiRuntimeCatalog.FindHost(srcHost.HostUri, out var host));
                        Correlate(ApiMd.HostCatalog(host), ApiHex.ReadBlocks(hexpath), code, records);
                    }
                }
                Ran(inner);
            }

            TableEmit(records.OrderBy(x => x.RuntimeAddress).Array(), path);

            Ran(flow);
            return code.ToArray();
        }

        int Correlate(ApiHostCatalog src, Index<ApiCodeBlock> blocks, List<ApiMemberCode> dst, List<ApiCorrelationEntry> entries)
        {
            var part = src.Host.PartId;
            var members = src.Members.OrderBy(x => x.Id).Array();
            var targets = blocks.Where(x => x.IsNonEmpty && x.OpId.IsNonEmpty).OrderBy(x => x.OpId).Array();
            var correlated = (
                from m in members
                join t in targets on m.Id equals t.OpId orderby m.Id
                select paired(m, t)).Array();

            var count = correlated.Length;
            if(count > 0)
            {
                var view = @readonly(correlated);
                var seq = Seq16x2.create(0, (byte)(part));
                for(var i=0u; i<count; i++)
                {
                    ref readonly var pair = ref skip(view,i);
                    ref readonly var right = ref pair.Right;
                    ref readonly var left = ref pair.Left;
                    var entry = new ApiCorrelationEntry();
                    entry.Key = seq++;
                    entry.CaptureAddress = right.BaseAddress;
                    entry.RuntimeAddress = left.BaseAddress;
                    entry.Id = right.OpUri;
                    entries.Add(entry);
                    dst.Add(new ApiMemberCode(left, right, i));
                }
            }
            return count;
        }

        static Outcome parse(string src, out ApiCatalogEntry dst)
        {
            const char Delimiter = FieldDelimiter;
            const byte FieldCount = ApiCatalogEntry.FieldCount;
            var fields = text.split(src, Delimiter);
            if(fields.Length != FieldCount)
            {
                dst = default;
                return (false, Msg.FieldCountMismatch.Format(fields.Length, FieldCount, text.delimit(@readonly(fields), Delimiter,0)));
            }

            var i = 0;
            DataParser.parse(skip(fields, i++), out dst.Sequence);
            DataParser.parse(skip(fields, i++), out dst.ProcessBase);
            DataParser.parse(skip(fields, i++), out dst.MemberBase);
            DataParser.parse(skip(fields, i++), out dst.MemberOffset);
            DataParser.parse(skip(fields, i++), out dst.MemberRebase);
            DataParser.parse(skip(fields, i++), out dst.MaxSize);
            DataParser.parse(skip(fields, i++), out dst.PartName);
            DataParser.parse(skip(fields, i++), out dst.HostName);
            DataParser.parse(skip(fields, i++), out dst.OpUri);
            return true;
        }
    }
}