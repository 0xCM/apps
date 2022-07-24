//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    class ApiPartCapture : WfSvc<ApiPartCapture>
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCode ApiCode => Wf.ApiCode();

        void RedirectEmissions(IApiPack dst)
            => Wf.RedirectEmissions(Loggers.emission(ExecutingPart.Component, dst.Path("capture.emissions", FileKind.Csv)));

        public static Index<ApiCatalogEntry> rebase(ApiMembers src)
            => rebase(src.BaseAddress, src.View);

        public static Index<ApiCatalogEntry> rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> src)
        {
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var member = ref skip(src,i);
                if(member == null)
                    @throw($"The {i}'th element from the input sequence is null");
            }

            var dst = alloc<ApiCatalogEntry>(src.Length);
            rebase(@base, src, dst);
            return dst;
        }

        public static uint rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> members, Span<ApiCatalogEntry> dst)
        {
            var count = members.Length;
            if(count == 0)
                return 0;

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

        public CollectedHosts Capture(IApiPack dst)
        {
            RedirectEmissions(dst);
            using var dispenser = Dispense.composite();
            return Capture(ApiRuntimeCatalog, dispenser, true, dst);
        }

        public CollectedHosts Capture(IApiPack dst, ICompositeDispenser dispenser)
        {
            RedirectEmissions(dst);
            return Capture(ApiRuntimeCatalog, dispenser, true, dst);
        }

        public CollectedHosts Capture(IApiCatalog src, ICompositeDispenser dispenser, bool pll, IApiPack dst)
        {
            var buffer = bag<CollectedHost>();
            iter(src.PartCatalogs(),
                part => {
                    var code = ApiCode.collect(part, EventLog, dispenser);
                    ApiCode.Emit(part.PartId, code, dst);
                    EmitAsm(dispenser, code, dst);
                },
            pll);

            return buffer.ToIndex().Sort();
        }

        void EmitAsm(ICompositeDispenser symbols, ReadOnlySeq<CollectedHost> src, IApiPack dst)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var host = ref src[i];
                var path = dst.AsmExtractPath(host.Host);
                var flow = EmittingFile(path);
                var size = ByteSize.Zero;
                using var writer = path.AsciWriter();
                for(var j=0; j<host.Blocks.Count; j++)
                {
                    ref readonly var blocks = ref host.Blocks[j];
                    var routine = AsmDecoder.Decode(blocks);
                    var asm = routine.AsmRender(routine);
                    size += (ulong)asm.Length;
                    writer.AppendLine(asm);
                }
                EmittedFile(flow, AppMsg.EmittedBytes.Capture(size,path));
            }
        }
    }
}