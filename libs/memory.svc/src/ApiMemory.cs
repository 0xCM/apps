//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiMemory : WfSvc<ApiMemory>
    {
        public void EmitSymHeap(SymHeap src, IApiPack dst)
            => TableEmit(Heaps.entries(src), dst.Metadata().Table<SymHeapRecord>(), TextEncodingKind.Unicode);
    }
}