//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ServiceCache : AppServices<ServiceCache>
    {
        [Op]
        public HexCsvReader HexCsvReader(IWfRuntime wf)
            => Service<HexCsvReader>(wf);

        [Op]
        public HexCsvWriter HexCsvWriter(IWfRuntime wf)
            => Service<HexCsvWriter>(wf);

        [Op]
        public HexDataReader HexDataReader(IWfRuntime wf)
            => Service<HexDataReader>(wf);

        [Op]
        public HexEmitter HexEmitter(IWfRuntime wf)
            => Service<HexEmitter>(wf);
    }

    public static class XSvc
    {
        static ServiceCache Services => ServiceCache.Instance;

        [Op]
        public static HexCsvReader HexCsvReader(this IWfRuntime wf)
            => Services.HexCsvReader(wf);

        [Op]
        public static HexCsvWriter HexCsvWriter(this IWfRuntime wf)
            => Services.HexCsvWriter(wf);

        [Op]
        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        [Op]
        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Services.HexEmitter(wf);
    }
}