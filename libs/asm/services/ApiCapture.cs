//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public interface IPartCapture
    {
        void Capture(ReadOnlySpan<IPart> src, ICompositeDispenser dst, bool pll);
    }

    class ApiPartCapture : WfSvc<ApiPartCapture>, IPartCapture
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeFiles CodeFiles => Wf.ApiCodeFiles();

        ApiCode ApiCode => Wf.ApiCode();

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
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(buffer,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            FileEmit(emitter.Emit(), src.Count, dst);
            return buffer;
        }
    }

    public class ApiCapture : WfSvc<ApiCapture>
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeFiles CodeFiles => Wf.ApiCodeFiles();

        ApiCode ApiCode => Wf.ApiCode();

        ApiMd ApiMd => Wf.ApiMetadata();

        public void Run()
        {
            var capture = ApiPartCapture.create(Wf);
            using var dst = Dispense.composite();
            var parts = ApiMd.Parts;
            capture.Capture(parts, dst, true);
            // var pack = CodeFiles.ApiPack(core.timestamp());
            // iter(ApiMd.Parts, part => Run(part, pack, dst), true);
        }

        public void Run(PartId id)
        {
            if(ApiRuntimeCatalog.FindPart(id, out var src))
            {
                using var symbols = Dispense.composite();
                Run(symbols, src);
            }
        }

        public void Run(CmdArgs args)
        {
            if(args.Count != 0)
            {
                var spec = text.trim(CmdScript.arg(args,0).Value.Format());
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    Run(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    Run(ApiParsers.part(spec));
            }
            else
                Run();
        }

        // void Run(IPart part, IApiPack pack, ICompositeDispenser dst)
        // {
        //     var collected = ApiCode.Collect(part, dst, pack).Sort();
        //     var asm = EmitAsm(dst, part.Id, collected, pack.AsmPath(part.Id));
        // }

        public void Run(ApiHostUri src)
        {
            using var symbols = Dispense.composite();
            Run(symbols, src);
        }

        void Run(ICompositeDispenser symbols, ApiHostUri src)
        {
            var collected = ApiCode.Collect(src);
            var size = ApiCode.EmitHex(collected, CodeFiles.HexPath(src));
            var csv = ApiCode.EmitCsv(collected, CodeFiles.CsvPath(src));
            var asm = EmitAsm(symbols, src, collected);
        }

        void Run(ICompositeDispenser symbols, IPart src)
        {
            var collected = ApiCode.Collect(symbols,src).Sort();
            var size = ApiCode.EmitHex(collected, CodeFiles.HexPath(src.Id));
            var csv = ApiCode.EmitCsv(collected, CodeFiles.CsvPath(src.Id));
            var asm = EmitAsm(symbols, src.Id, collected);
        }

        // Index<AsmRoutine> EmitAsm(ICompositeDispenser symbols, PartId part, Index<CollectedEncoding> src, FS.FilePath dst)
        // {
        //     var buffer = alloc<AsmRoutine>(src.Count);
        //     var emitter = text.emitter();
        //     for(var i=0; i<src.Count; i++)
        //     {
        //         var routine = AsmDecoder.Decode(src[i]);
        //         seek(buffer,i) = routine;
        //         emitter.AppendLine(routine.AsmRender(routine));
        //     }

        //     FileEmit(emitter.Emit(), src.Count, dst);
        //     return buffer;

        // }

        Index<AsmRoutine> EmitAsm(ICompositeDispenser symbols, PartId part, Index<CollectedEncoding> src)
        {
            var dst = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(dst,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            FileEmit(emitter.Emit(), src.Count, CodeFiles.AsmPath(part));
            return dst;
        }

        Index<AsmRoutine> EmitAsm(ICompositeDispenser symbols, ApiHostUri host, Index<CollectedEncoding> src)
        {
            var dst = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(dst,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            FileEmit(emitter.Emit(), src.Count, CodeFiles.AsmPath(host));
            return dst;
        }
    }
}