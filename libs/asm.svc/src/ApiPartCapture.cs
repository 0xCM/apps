//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    class ApiPartCapture : WfSvc<ApiPartCapture>, IPartCapture
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeFiles CodeFiles => Wf.ApiCodeFiles();

        ApiCode ApiCode => Wf.ApiCode();

        public void Capture(Timestamp ts)
        {
            using var dispenser = Dispense.composite();
            Capture(ts,ApiRuntimeCatalog, dispenser, true);
        }

        public Timestamp Capture()
        {
            var ts = core.timestamp();
            Capture(ts);
            return ts;
        }

        public Index<CollectedEncoding> Capture(Timestamp ts, IApiCatalog src, ICompositeDispenser dispenser, bool pll)
        {
            var pack = CodeFiles.ApiPack(ts);
            var dst = bag<CollectedEncoding>();
            iter(src.PartCatalogs(),
                part => Collected(part.PartId, ApiCode.collect(part, EventLog, dispenser), pack, dispenser, dst), pll);
            return dst.ToIndex().Sort();
        }

        Index<CollectedEncoding> Collected(PartId part, Index<CollectedEncoding> src, IApiPack pack, ICompositeDispenser dispenser, ConcurrentBag<CollectedEncoding> dst)
        {
            var members = ApiCode.Emit(part, src, pack);
            var asm = EmitAsm(dispenser, part, src, pack.AsmPath(part));
            return src;
        }

        public void Capture(ReadOnlySpan<IPart> src, ICompositeDispenser dst, bool pll)
        {
            var pack = CodeFiles.ApiPack(core.timestamp());
            iter(src, part => Capture(part, pack, dst), pll);
        }

        void Capture(IPart src, IApiPack pack, ICompositeDispenser dst)
        {
            var collected = ApiCode.Collect(src, dst, pack).Sort();
            var asm = EmitAsm(dst, src.Id, collected, pack.AsmPath(src.Id));
        }

        Index<AsmRoutine> EmitAsm(ICompositeDispenser symbols, PartId part, Index<CollectedEncoding> src, FS.FilePath dst)
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
            EmittedFile(flow, $"Emitted {size} bytes to {dst.ToUri()}");
            //FileEmit(emitter.Emit(), src.Count, dst);
            return buffer;
        }
    }
}