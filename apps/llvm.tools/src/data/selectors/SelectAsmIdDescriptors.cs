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
            return (AsmIdDefs)DataSets.GetOrAdd(nameof(AsmIdDefs), key => Load());

            AsmIdDefs Load()
            {
                var asmid = SelectList("AsmId");
                var lu = list<AsmIdDef>();
                foreach(var id in asmid)
                    lu.Add(new AsmIdDef((ushort)id.Key, id.Value.Trim()));
                return lu.Array();
            }
        }
    }
}