//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ProjectCollection
    {
        public FileCatalog Files;

        public ObjDumpBlocks ObjBlockData;

        public Index<ObjSymRow> ObjSyms;

        public CoffSymIndex SymIndex;

        public Index<AsmCodeIndexRow> AsmIndex;
    }
}