//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public AsmIdDescriptors SelectAsmIdDescriptors()
        {
            return (AsmIdDescriptors)DataSets.GetOrAdd(nameof(AsmIdDescriptors), key => Load());

            AsmIdDescriptors Load()
            {
                var asmid = SelectList("AsmId");
                var lu = list<AsmIdDescriptor>();
                foreach(var id in asmid)
                    lu.Add(new AsmIdDescriptor((ushort)id.Key, id.Value.Trim()));
                return lu.Array();
            }
        }
    }
}