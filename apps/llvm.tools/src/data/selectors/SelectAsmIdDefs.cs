//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public AsmIdDefs SelectAsmIdDefs()
        {
            const string TableId = "llvm.asm.AsmId";

            return (AsmIdDefs)DataSets.GetOrAdd(nameof(SelectAsmIdDefs), key => Load());

            AsmIdDefs Load()
            {
                var src = LlvmPaths.Table(TableId);
                var items = SelectList(TableId, src);
                var dst = list<AsmIdDef>();
                foreach(var id in items)
                    dst.Add(new AsmIdDef((ushort)id.Key, id.Value.Trim()));
                return dst.Array();
            }
        }
    }
}