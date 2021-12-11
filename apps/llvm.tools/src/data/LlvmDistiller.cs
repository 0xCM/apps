//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public class LlvmDistiller : AppService<LlvmDistiller>
    {
        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        public Index<LlvmInstOpCode> ToRecords(LlvmOpCodeMap ocmap)
        {
            var asmids = DataProvider.SelectAsmIdDefs();
            var entries = ocmap.Entries;
            var count = entries.Length;
            var instcount = gcalc.sum(ocmap.Values.Select(x => x.Count));
            var buffer = alloc<LlvmInstOpCode>(instcount);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var map = entry.Key;
                var mapped = entry.Value;
                for(var j=0; j<mapped.Count; j++)
                {
                    ref var dst = ref seek(buffer,counter++);
                    ref readonly var src = ref mapped[j];
                    var name = src.InstName;
                    dst.AsmId = asmids.AsmId(name);
                    dst.InstName = name;
                    dst.Map = src.OpMap;
                    dst.Bits = BitStrings.scalar(src.Opcode.Packed);
                    dst.Scalar = src.Opcode.Packed;
                }
            }
            return buffer;
        }

        public LlvmOpCodeMap DistillOpCodes(ReadOnlySpan<InstEntity> src)
        {
            var count = src.Length;
            var dst = dict<Identifier,DataList<InstEntity>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var inst = ref skip(src,i);
                if(text.nonempty(inst.OpMap))
                {
                    if(dst.TryGetValue(inst.OpMap, out var map))
                    {
                        map.Add(inst);
                    }
                    else
                    {
                        dst[inst.OpMap] = new();
                        dst[inst.OpMap].Add(inst);
                    }
                }
            }
            return dst.Map(x => (x.Key, new Index<InstEntity>(x.Value.Array()))).ToDictionary();
        }
    }
}