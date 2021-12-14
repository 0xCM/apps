//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataEmitter
    {
        public Index<LlvmAsmOpCode> EmitAsmOpCodes(LlvmOpCodeMap src)
        {
            var asmids = DataProvider.SelectAsmIdentifiers();
            var entries = src.Entries;
            var count = entries.Length;
            var instcount = gcalc.sum(src.Values.Select(x => x.Count));
            var buffer = alloc<LlvmAsmOpCode>(instcount);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var key = entry.Key;
                var mapped = entry.Value;
                for(var j=0; j<mapped.Count; j++)
                {
                    ref var dst = ref seek(buffer,counter++);
                    ref readonly var map = ref mapped[j];
                    var name = map.InstName;
                    dst.AsmId = asmids.AsmId(name);
                    dst.InstName = name;
                    dst.Map = map.OpMap;
                    dst.Bits = BitStrings.scalar(map.Opcode.Packed);
                    dst.Scalar = map.Opcode.Packed;
                }
            }

            var records = buffer.Sort();
            TableEmit(@readonly(records), LlvmPaths.Table<LlvmAsmOpCode>());
            return records;
        }
    }
}