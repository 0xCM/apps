//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/symheap")]
        Outcome EmitSymHeap(CmdArgs args)
        {
            var literals = Symbolism.DiscoverLiterals(ApiRuntimeCatalog.Components);
            Status($"Creating heap for {literals.Length} literals");
            var heap = SymHeaps.define(literals);
            var count = heap.SymbolCount;
            var entries = SymHeaps.entries(heap);
            var dst = ProjectDb.Api() + FS.file(Tables.identify<SymHeapEntry>().Format(), FS.Csv);
            TableEmit(entries.View, SymHeapEntry.RenderWidths, dst);
            return true;
        }
    }
}