//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Svc = Z0;

    [ApiHost]
    public static partial class XSvc
    {
        [Op]
        public static CliEmitter CliEmitter(this IWfRuntime wf)
            => Svc.CliEmitter.create(wf);

        [Op]
        public static MsilPipe MsilPipe(this IWfRuntime wf)
            => Svc.MsilPipe.create(wf);

        [Op]
        public static AppModules AppModules(this IWfRuntime wf)
            => Svc.AppModules.create(wf);

        [Op]
        public static PdbSymbolStore PdbSymbolStore(this IWfRuntime wf)
            => Svc.PdbSymbolStore.create(wf);

        [Op]
        public static PdbReader PdbReader(this IWfRuntime wf, in PdbSymbolSource src)
            => Svc.PdbServices.reader(wf,src);

        [Op]
        public static ProcessContextPipe ProcessContextPipe(this IWfRuntime wf)
            => Svc.ProcessContextPipe.create(wf);

        [Op]
        public static RegionProcessor RegionProcessor(this IWfRuntime wf)
            => Svc.RegionProcessor.create(wf);

        [Op]
        public static PdbIndex PdbIndex(this IWfRuntime wf)
            => Svc.PdbIndex.create(wf);

        [Op]
        public static PdbIndexBuilder PdbIndexBuilder(this IWfRuntime wf)
            => Svc.PdbIndexBuilder.create(wf);
    }
}