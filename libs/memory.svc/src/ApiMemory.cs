//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiMemory : WfSvc<ApiMemory>
    {
        public void EmitSymHeap(SymHeap src, IApiPack dst)
            => Heaps.emit(src, dst.Metadata().Table<SymHeapRecord>(), EventLog);

        public void EmitSymHeap(SymHeap src)
            => Heaps.emit(src, AppDb.ApiTargets().Table<SymHeapRecord>(), EventLog);
    }
}