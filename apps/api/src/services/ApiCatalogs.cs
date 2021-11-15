//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using static Root;
    using static core;

    [ApiHost]
    public class ApiCatalogs : AppService<ApiCatalogs>
    {
        ApiQuery Query;

        ApiRuntime Runtime;

        protected override void OnInit()
        {
            Query = Wf.ApiQuery();
            Runtime = Wf.ApiRuntime();
        }

        public ReadOnlySpan<SymLiteralRow> EmitApiClasses()
            => EmitApiClasses(Db.IndexTable("api.classes"));

        public ReadOnlySpan<SymLiteralRow> EmitApiClasses(FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<SymLiteralRow>(dst);
            var literals = Query.ApiClassLiterals();
            var count = Tables.emit(literals, dst);
            Wf.EmittedTable(flow, count);
            return literals;
        }

        public ReadOnlySpan<ApiCatalogEntry> EmitApiCatalog(ApiMembers src, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<ApiCatalogEntry>(dst);
            var records = rebase(src.BaseAddress, src.View);
            var count = Tables.emit<ApiCatalogEntry>(records.View, dst);
            Wf.EmittedTable<ApiCatalogEntry>(flow, count, dst);
            return records;
        }

        public ReadOnlySpan<ApiCatalogEntry> LoadApiCatalog(FS.FilePath src)
        {
            var rows = list<ApiCatalogEntry>();
            using var reader = src.Utf8Reader();
            reader.ReadLine();
            var line = reader.ReadLine();
            while(line != null)
            {
                var outcome = parse(line, out var row);
                if(outcome)
                    rows.Add(row);
                else
                {
                    Wf.Error(outcome.Message);
                    return array<ApiCatalogEntry>();
                }
                line = reader.ReadLine();
            }
            return rows.ViewDeposited();
        }

        public ReadOnlySpan<ApiCatalogEntry> LoadApiCatalog(FS.FolderPath dir)
        {
            var files = dir.Files(FS.Csv).Where(f => f.FileName.StartsWith(ApiCatalogEntry.TableId)).OrderBy(f => f.Name).ToReadOnlySpan();
            var count = files.Length;
            var rows = default(ReadOnlySpan<ApiCatalogEntry>);
            if(count != 0)
            {
                ref readonly var current = ref skip(files,count - 1);
                var flow = Wf.Running(Msg.LoadingApiCatalog.Format(current));
                rows = LoadApiCatalog(current);
                Wf.Ran(flow, Msg.LoadedApiCatalog.Format(rows.Length, current));
            }

            return rows;
        }

        public ReadOnlySpan<ApiCatalogEntry> LoadApiCatalog()
            => LoadApiCatalog(Db.CaptureContextRoot());

        [Op]
        public static Index<ApiCatalogEntry> rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> members)
        {
            var dst = alloc<ApiCatalogEntry>(members.Length);
            rebase(@base, members, dst);
            return dst;
        }

        [Op]
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

        public ReadOnlySpan<ApiMemberCode> Correlate()
            => Correlate(Wf.ApiCatalog.PartCatalogs());

        public ReadOnlySpan<ApiMemberCode> Correlate(FS.FilePath dst)
            => Correlate(Wf.ApiCatalog.PartCatalogs(), dst);

        public ReadOnlySpan<ApiMemberCode> Correlate(ReadOnlySpan<IApiPartCatalog> src)
            => Correlate(src,Db.IndexTable<ApiCorrelationEntry>());

        public ReadOnlySpan<ApiMemberCode> Correlate(ReadOnlySpan<IApiPartCatalog> src, FS.FilePath path)
        {
            var flow = Wf.Running(Msg.CorrelatingParts.Format(src.Length));
            var hex = Wf.ApiHex();
            var count = src.Length;
            var dst = list<ApiMemberCode>();
            var records = list<ApiCorrelationEntry>();
            for(var i=0; i<count; i++)
            {
                var part = skip(src,i);
                var inner = Wf.Running(Msg.CorrelatingOperations.Format(part.PartId.Format()));
                var hosts = part.ApiHosts.View;
                var kHost = hosts.Length;
                for(var j=0; j<kHost; j++)
                {
                    ref readonly var srcHost = ref skip(hosts,j);
                    var hexpath = Db.ParsedExtractPath(srcHost.HostUri);
                    if(hexpath.Exists)
                    {
                        var blocks = hex.ReadBlocks(hexpath);
                        Require.invariant(Wf.ApiCatalog.FindHost(srcHost.HostUri, out var host));
                        var catalog = Runtime.HostCatalog(host);
                        Correlate(catalog, blocks, dst, records);
                    }
                }
                Wf.Ran(inner);
            }

            var emitting = Wf.EmittingTable<ApiCorrelationEntry>(path);
            var output = @readonly(records.OrderBy(x => x.RuntimeAddress).Array());
            Tables.emit(output, path);
            Wf.EmittedTable(emitting, output.Length);

            Wf.Ran(flow);
            return dst.ToArray();
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
                return (false, Msg.FieldCountMismatch.Format(fields.Length, FieldCount, text.delimit(fields, Delimiter)));
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