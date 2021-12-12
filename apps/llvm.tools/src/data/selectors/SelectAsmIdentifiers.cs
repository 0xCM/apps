//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public AsmIdentifiers SelectAsmIdentifiers()
        {
            const string TableId = "llvm.asm.AsmId";

            return (AsmIdentifiers)DataSets.GetOrAdd(nameof(SelectAsmIdentifiers), key => Load());

            AsmIdentifiers Load()
            {
                var src = LlvmPaths.Table(TableId);
                var items = SelectList(TableId, src);
                var dst = list<AsmIdentifier>();
                foreach(var id in items)
                    dst.Add(new AsmIdentifier((ushort)id.Key, id.Value.Trim()));
                return dst.Array();
            }
        }
    }
}