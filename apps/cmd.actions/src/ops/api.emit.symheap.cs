//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class GlobalCommands
    {
        [CmdOp("api/emit/symheap")]
        Outcome EmitSymHeap(CmdArgs args)
        {
            var symbolic = Service(Wf.Symbolism);
            var literals = symbolic.DiscoverLiterals(ApiRuntimeCatalog.Components);
            Status($"Creating heap for {literals.Length} literals");
            var heap = SymHeaps.define(literals);
            var count = heap.SymbolCount;
            var entries = SymHeaps.entries(heap);
            var dst = ProjectDb.Subdir("api") + FS.file(Tables.identify<SymHeapEntry>().Format(), FS.Csv);
            TableEmit(entries.View, SymHeapEntry.RenderWidths, dst);
            return true;
        }
    }
}