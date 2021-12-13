//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataProvider
    {
        public Index<LlvmDataType> SelectDistinctFieldTypes(ReadOnlySpan<RecordField> src)
        {
            var types = hashset<LlvmDataType>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref src[i];
                if(text.contains(field.DataType, "AMDGPU") || text.contains(field.DataType, "WMMA_REGS"))
                    continue;

                var dt = LlvmTypes.type(field.DataType);
                if(dt.IsNonEmpty)
                    types.Add(dt);
            }

            return types.Array().Sort();
        }
    }
}