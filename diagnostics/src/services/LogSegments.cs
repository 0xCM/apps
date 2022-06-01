//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RuntimeServices
    {
        public ProcAddresses LogSegments(Timestamp ts)
            => LogSegments(ts, ImageMemory.regions());

        public ProcAddresses LogSegments(Timestamp ts, Index<ProcessMemoryRegion> src)
        {
            var bank = ImageMemory.addresses(src);
            AppSvc.TableEmit(bank.Segments, Dumps.Archive("segments", ts).Table<ProcessSegment>());
            return bank;
        }
    }
}