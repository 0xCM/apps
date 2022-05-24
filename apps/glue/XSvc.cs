//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Toolz;

    using static core;

    public static partial class XTend
    {


    }

    [ApiHost]
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
            => Toolz.Robocopy.create(wf);

        [Op]
        public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Z0.CultProcessor.create(wf);

        [Op]
        public static BdDisasm BdDisasm(this IWfRuntime wf)
            => Toolz.BdDisasm.create(wf);

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

        [Op]
        public static CliEmitter CliEmitter(this IWfRuntime wf)
            => Z0.CliEmitter.create(wf);

        [Op]
        public static AppModules AppModules(this IWfRuntime wf)
            => Z0.AppModules.create(wf);

        [Op]
        public static PdbSymbolStore PdbSymbolStore(this IWfRuntime wf)
            => Z0.PdbSymbolStore.create(wf);

        [Op]
        public static PdbReader PdbReader(this IWfRuntime wf, in PdbSymbolSource src)
            => Z0.PdbReader.create(wf,src);

        [Op]
        public static PdbIndex PdbIndex(this IWfRuntime wf)
            => Z0.PdbIndex.create(wf);

        [Op]
        public static PdbIndexBuilder PdbIndexBuilder(this IWfRuntime wf)
            => Z0.PdbIndexBuilder.create(wf);

        [Op]
        public static DumpParser DumpParser(this IWfRuntime wf)
            => Z0.DumpParser.create(wf);

        [Op]
        public static MsDocsService MsDocs(this IWfRuntime wf)
            => Z0.MsDocsService.create(wf);
    }
}