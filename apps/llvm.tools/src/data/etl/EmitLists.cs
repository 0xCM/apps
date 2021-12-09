//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmEtl
    {
        public Index<LlvmList> EmitLists()
        {
            FS.Files paths = LlvmPaths.ListNames().Map(x => LlvmPaths.ListImportPath(x));
            paths.Delete();
            DataEmitter.Emit(DiscoverAsmIdDefs());
            DataEmitter.Emit(DiscoverRegIdDefs());
            return DataEmitter.EmitLists(DataProvider.SelectEntities(), ListNames());
        }
    }
}