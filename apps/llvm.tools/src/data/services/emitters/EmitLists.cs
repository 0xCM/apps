//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataEmitter
    {
        public Index<LlvmList> EmitLists(Index<LlvmEntity> entities)
        {
            FS.Files paths = LlvmPaths.ListNames().Map(x => LlvmPaths.ListImportPath(x));
            paths.Delete();
            return EmitLists(entities, DataProvider.SelectConfiguredListNames());
        }

        Index<LlvmList> EmitLists(Index<LlvmEntity> src, ReadOnlySpan<string> classes)
        {
            var lists = DataCalcs.CalcLists(src, classes);
            iter(lists, c => EmitList(c), true);
            return lists;
        }
    }
}