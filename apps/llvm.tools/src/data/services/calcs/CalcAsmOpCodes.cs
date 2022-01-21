//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataCalcs
    {
        public LlvmOpCodeMap CalcOpCodeMap(ReadOnlySpan<InstEntity> src)
        {
            var count = src.Length;
            var dst = dict<Identifier,DataList<InstEntity>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var inst = ref src[i];
                if(inst.isCodeGenOnly || inst.isPseudo)
                    continue;

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

        public LlvmOpCodeMap CalcOpCodeMap(ReadOnlySpan<LlvmEntity> entities)
        {
            var src = entities.Where(e => e.IsInstruction()).Select(e => e.ToInstruction());
            return CalcOpCodeMap(src);
        }

        public Index<LlvmAsmOpCode> CalcAsmOpCodes(AsmIdentifiers asmids, LlvmOpCodeMap src)
        {
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

            return buffer.Sort();
        }
    }
}