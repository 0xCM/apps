//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public LlvmOpCodeMap SelectOpCodeMap()
        {
            return (LlvmOpCodeMap)DataSets.GetOrAdd(nameof(SelectOpCodeMap), _ => Load());

            LlvmOpCodeMap Load()
            {
                var src = SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
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
        }
    }
}