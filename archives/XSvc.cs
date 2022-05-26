//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
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

        static Svc Services => Svc.Instance;

        public static HexCsvReader HexCsvReader(this IWfRuntime wf)
            => Services.HexCsvReader(wf);

        public static HexCsvWriter HexCsvWriter(this IWfRuntime wf)
            => Services.HexCsvWriter(wf);

        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Services.HexEmitter(wf);
    }
}