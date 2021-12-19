//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;
    using Z0.Tools;

    using static core;

    public static partial class XTend
    {


    }

    public static partial class XSvc
    {
        [Op]
        public static Roslyn Roslyn(this IWfRuntime wf)
            => Z0.Roslyn.create(wf);

        [Op]
        public static SourceSymbolic SourceSymbolic(this IWfRuntime wf)
            => Z0.SourceSymbolic.create(wf);

        [Op]
        public static Robocopy Robocopy(this IWfRuntime wf)
            => Tools.Robocopy.create(wf);

        [Op]
        public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Tools.CultProcessor.create(wf);

        [Op]
        public static DumpBin DumpBin(this IWfRuntime wf)
            => Z0.DumpBin.create(wf);

        [Op]
        public static BdDisasm BdDisasm(this IWfRuntime wf)
            => Tools.BdDisasm.create(wf);

        [Op]
        public static WinSdk WinSdk(this IWfRuntime wf)
            => Z0.WinSdk.create(wf);

        [Op]
        public static Msvs Msvs(this IWfRuntime wf)
            => Z0.Msvs.create(wf);

        public static Index<IToolResultHandler> ResultHandlers(this IEnvPaths paths)
        {
            var buffer = sys.alloc<IToolResultHandler>(2);
            ref var dst = ref first(buffer);
            seek(dst,0) = new MsBuildResultHandler(paths);
            seek(dst,1) = new RobocopyResultHandler(paths);
            return buffer;
        }
    }
}