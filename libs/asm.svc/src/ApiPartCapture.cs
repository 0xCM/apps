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

        ApiCodeFiles CodeFiles => Wf.ApiCodeFiles();

        ApiCode ApiCode => Wf.ApiCode();

        public void Capture(IApiPack dst)
        {
            using var dispenser = Dispense.composite();
            Capture(ApiRuntimeCatalog, dispenser, true, dst);
        }

        public void Capture2(IApiPack dst)
        {
            using var dispenser = Dispense.composite();
            Capture2(ApiRuntimeCatalog, dispenser, true, dst);
        }

        public ReadOnlySeq<CollectedEncoding> Capture(IApiCatalog src, ICompositeDispenser dispenser, bool pll, IApiPack pack)
        {
            var dst = bag<CollectedEncoding>();
            iter(src.PartCatalogs(),
                part => Collected(part.PartId, ApiCode.collect(part, EventLog, dispenser), pack, dispenser, dst), pll);
            return dst.ToIndex().Sort();
        }

        public ReadOnlySeq<ApiHostCode> Capture2(IApiCatalog src, ICompositeDispenser dispenser, bool pll, IApiPack pack)
        {
            var dst = bag<ApiHostCode>();
            iter(src.PartCatalogs(),
                part => Collected2(part.PartId, ApiCode.collect2(part, EventLog, dispenser), pack, dispenser, dst), pll);
            return dst.ToIndex().Sort();
        }

        ReadOnlySeq<CollectedEncoding> Collected(PartId part, ReadOnlySeq<CollectedEncoding> src, IApiPack pack, ICompositeDispenser dispenser, ConcurrentBag<CollectedEncoding> dst)
        {
            var members = ApiCode.Emit(part, src, pack);
            var asm = EmitAsm(dispenser, part, src, pack.AsmPath(part));
            return src;
        }

        void Collected2(PartId part, ReadOnlySeq<ApiHostCode> src, IApiPack pack, ICompositeDispenser dispenser, ConcurrentBag<ApiHostCode> dst)
        {
            ApiCode.Emit(part, src, pack);
            EmitAsm(dispenser, src, pack);
        }

        public void Capture(ReadOnlySpan<IPart> src, ICompositeDispenser dst, bool pll)
        {
            var pack = CodeFiles.ApiPack(core.timestamp());
            iter(src, part => Capture(part, pack, dst), pll);
        }

        void Capture(IPart src, IApiPack pack, ICompositeDispenser dst)
        {
            var collected = ApiCode.Collect(src, dst, pack);
            var asm = EmitAsm(dst, src.Id, collected, pack.AsmPath(src.Id));
        }

        void EmitAsm(ICompositeDispenser symbols, ReadOnlySeq<ApiHostCode> src, IApiPack dst)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var host = ref src[i];
                var path = dst.AsmPath(host.Host);
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

        Index<AsmRoutine> EmitAsm(ICompositeDispenser symbols, PartId part, ReadOnlySeq<CollectedEncoding> src, FS.FilePath dst)
        {
            var buffer = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            var flow = EmittingFile(dst);
            var size = ByteSize.Zero;
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(buffer,i) = routine;
                var asm = routine.AsmRender(routine);
                size += (ulong)asm.Length;
                writer.AppendLine(asm);
            }
            EmittedFile(flow, AppMsg.EmittedBytes.Capture(size,dst));
            return buffer;
        }
    }
}