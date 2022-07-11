//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    public class ApiMemory : WfSvc<ApiMemory>
    {
        public void EmitSymHeap(SymHeap src, FS.FilePath dst)
            => TableEmit(Heaps.entries(src), dst);

        public void EmitSymHeap(SymHeap src)
            => TableEmit(Heaps.entries(src), AppDb.ApiTargets().Table<SymHeapRecord>(), TextEncodingKind.Unicode);

    }
}