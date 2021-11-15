//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    partial class AsmCmdService
    {
        ReadOnlySpan<AsmHostRoutines> CapturePart(PartId part)
        {
            var dst = Db.CaptureRoot();
            var catalog = ApiRuntimeLoader.catalog();
            var hosts = catalog.ApiHosts.Where(h => h.PartId == part);
            return Wf.CaptureRunner().Capture(hosts, dst);
        }
    }
}