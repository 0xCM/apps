//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using static core;
    using static Root;
    using static LlvmNames;

    partial class LlvmDataLoader
    {
        public AsmIdDescriptors LoadAsmIdDescriptors()
        {
            return (AsmIdDescriptors)DataSets.GetOrAdd(nameof(AsmIdDescriptors), key => Load());

            AsmIdDescriptors Load()
            {
                var asmid = LoadList("AsmId");
                var lu = list<AsmIdDescriptor>();
                foreach(var id in asmid)
                    lu.Add(new AsmIdDescriptor((ushort)id.Key, id.Value.Trim()));
                return lu.Array();
            }
        }
    }
}