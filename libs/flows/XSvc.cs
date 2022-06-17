//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        public static void RedirectEmissions(this IWfRuntime wf, Assembly src, FS.FolderPath dst, Timestamp? ts = null, string name = null)
            => wf.RedirectEmissions(Loggers.emission(src, dst, ts ?? core.timestamp(), name));
    }
}