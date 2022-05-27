//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using PCK = ProcessContextFlag;

    partial class RuntimeServices
    {
        public void LogRegions(Timestamp ts, Index<ProcessMemoryRegion> src)
            => AppSvc.TableEmit(src, Dumps.Archive("segments", ts).Table<ProcessMemoryRegion>());
    }
}