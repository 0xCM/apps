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
            public DumpArchive DumpArchive(IWfRuntime wf)
                => Service<DumpArchive>(wf);

        }

        static Svc AppServices => Svc.Instance;


        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => AppServices.DumpArchive(wf);
   }
}