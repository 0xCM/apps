//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public static partial class XTend
    {

    }

    public static partial class XSvc
    {

        sealed class Svc : AppServices<Svc>
        {

        }

        static Svc Services => Svc.Instance;

        public static Roslyn Roslyn(this IWfRuntime wf)
            => Z0.Roslyn.create(wf);

        public static SourceSymbolic SourceSymbolic(this IWfRuntime wf)
            => Z0.SourceSymbolic.create(wf);

        public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Z0.CultProcessor.create(wf);

        public static BdDisasm BdDisasm(this IWfRuntime wf)
            => Z0.BdDisasm.create(wf);

        public static WinSdk WinSdk(this IWfRuntime wf)
            => Z0.WinSdk.create(wf);

        public static Msvs Msvs(this IWfRuntime wf)
            => Z0.Msvs.create(wf);

        // public static Index<IToolResultHandler> ResultHandlers(this IEnvPaths paths)
        // {
        //     var buffer = sys.alloc<IToolResultHandler>(2);
        //     ref var dst = ref first(buffer);
        //     seek(dst,0) = new MsBuildResultHandler(paths);
        //     seek(dst,1) = new RobocopyResultHandler(paths);
        //     return buffer;
        // }

        public static DumpParser DumpParser(this IWfRuntime wf)
            => Z0.DumpParser.create(wf);

        public static MsDocsService MsDocs(this IWfRuntime wf)
            => Z0.MsDocsService.create(wf);
    }
}