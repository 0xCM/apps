//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [ApiHost]
    public static class XSvc
    {
        [Op]
        public static AsmRowBuilder AsmRowBuilder(this IWfRuntime wf)
            => Asm.AsmRowBuilder.create(wf);

        [Op]
        public static HostAsmEmitter HostAsmEmitter(this IWfRuntime wf)
            => Asm.HostAsmEmitter.create(wf);

        [Op]
        public static ApiResPackUnpacker ResPackUnpacker(this IWfRuntime wf)
            => Asm.ApiResPackUnpacker.create(wf);

        [Op]
        public static AsmJmpPipe AsmJmpPipe(this IWfRuntime wf)
            => Asm.AsmJmpPipe.create(wf);

        [Op]
        public static AsmImmWriter ImmWriter(this IWfRuntime wf, in ApiHostUri host)
            => new AsmImmWriter(wf, host);

        [Op]
        public static AsmImmWriter ImmWriter(this IWfRuntime wf, in ApiHostUri host, FS.FolderPath root)
            => new AsmImmWriter(wf, host, root);

        [Op]
        public static AsmDecoder AsmDecoder(this IWfRuntime wf)
            => Asm.AsmDecoder.create(wf);

        [Op]
        public static ProcessAsmSvc ProcessAsm(this IWfRuntime wf)
            => Asm.ProcessAsmSvc.create(wf);

        [Op]
        public static ApiCodeBlockTraverser ApiCodeBlockTraverser(this IWfRuntime src)
            => Asm.ApiCodeBlockTraverser.create(src);

        [Op]
        public static AsmCallPipe AsmCallPipe(this IWfRuntime wf)
            => Asm.AsmCallPipe.create(wf);

        [Op]
        public static ApiExtractor ApiExtractor(this IWfRuntime wf)
            => Z0.ApiExtractor.create(wf);

        [Op]
        public static SegmentTraverser SegmentTraverser(this IWfRuntime wf)
            => Z0.SegmentTraverser.create(wf);

        [Op]
        public static ApiSegmentLocator ApiSegmentLocator(this IWfRuntime wf)
            => Z0.ApiSegmentLocator.create(wf);

        [Op]
        public static AsmAnalyzer AsmAnalyzer(this IWfRuntime wf)
            => Z0.AsmAnalyzer.create(wf);

        [Op]
        public static ApiExtractWorkflow ApiExtractWorkflow(this IWfRuntime wf)
            => Z0.ApiExtractWorkflow.create(wf);
    }
}