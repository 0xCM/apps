//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class ApiCapture : WfSvc<ApiCapture>
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiPacks ApiPacks => Wf.ApiPacks();

        Runtime Runtime => Wf.Runtime();

        ApiMd ApiMd => Wf.ApiMd();

        public static ReadOnlySeq<ApiCatalogEntry> catalog(ApiMembers members)
        {
            var buffer = sys.alloc<ApiCatalogEntry>(members.Count);
            var @base = members.BaseAddress;
            var rebase = members[0].BaseAddress;
            for(var i=0u; i<members.Count; i++)
            {
                ref readonly var member = ref members[i];
                ref var record = ref seek(buffer,i);
                record.Sequence = i;
                record.ProcessBase = @base;
                record.MemberBase = member.BaseAddress;
                record.MemberOffset = member.BaseAddress - @base;
                record.MemberRebase = (uint)(member.BaseAddress - rebase);
                record.HostName = member.Host.HostName;
                record.PartName = member.Host.Part.Format();
                record.OpUri = member.OpUri;
            }

            return buffer;
        }

        public void Run(IApiPack dst)
        {
            var parts = ApiPartCapture.create(Wf);
            using var dispenser = Dispense.composite();
            var hosts = parts.Capture(dst, dispenser);
            var members = ApiQuery.members(hosts.SelectMany(x => x.Resolved.Members).Where(x => x != null).Array());
            var rebased = catalog(members);
            TableEmit(rebased, dst.Table<ApiCatalogEntry>(), UTF8);
            ApiMd.EmitDatasets(dst);
            CliEmitter.Emit(CliEmitOptions.@default(), dst);
            Runtime.EmitContext(dst);
            ApiPacks.Link(dst);
        }

        ClrEventListener OpenEventLog(Timestamp ts)
            => ClrEventListener.create(AppDb.App().Path($"clr.events.{ts}", FileKind.Log));

        void EmitAsm(ICompositeDispenser symbols, PartId part, ReadOnlySeq<CollectedEncoding> src, IApiPack dst)
        {
            var buffer = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(buffer,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            FileEmit(emitter.Emit(), src.Count, dst.AsmExtractPath(part));
        }
    }
}