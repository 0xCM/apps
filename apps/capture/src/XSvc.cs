//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using Services = Z0.Asm;

    public static class XSvc
    {
        [Op]
        public static ApiCaptureService ApiCapture(this IWfRuntime wf)
            => Z0.ApiCaptureService.create(wf);

        [Op]
        public static ApiCaptureRunner CaptureRunner(this IWfRuntime wf)
            => ApiCaptureRunner.create(wf);

        [Op]
        public static ApiImmEmitter ImmEmitter(this IWfRuntime wf)
            => ApiImmEmitter.create(wf);

        [Op]
        public static AsmStatementProducer AsmStatementProducer(this IWfRuntime wf)
            => Asm.AsmStatementProducer.create(wf);

        [Op]
        public static ApiCaptureEmitter CaptureEmitter(this IWfRuntime wf)
            => ApiCaptureEmitter.create(wf);

        [Op]
        public static ICaptureCore CaptureCore(this IWfRuntime wf)
            => Services.CaptureCore.create(wf);

        [Op]
        public static ImmSpecializer ImmSpecializer(this IWfRuntime wf)
            => Z0.Asm.ImmSpecializer.create(wf);

        [Op]
        public static GlobalCommands GlobalCommands(this IWfRuntime wf)
            => Z0.GlobalCommands.create(wf);
    }
}