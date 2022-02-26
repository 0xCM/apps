//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class AsmStatsCollector : AsmEventReceiver
    {
        Dictionary<string,uint> _AsmIdCounts;

        public AsmStatsCollector()
        {
            _AsmIdCounts = new();
        }

        void Collect(ReadOnlySpan<AsmInstructionRow> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];
                if(_AsmIdCounts.TryGetValue(row.AsmName, out var k))
                {
                    _AsmIdCounts[row.AsmName] = k+1;
                }
                else
                {
                    _AsmIdCounts[row.AsmName] = 1;
                }
            }
        }

        public Index<AsmStat> Stats()
        {
            Collect(CollectedInstructions());
            var count = _AsmIdCounts.Count;
            var buffer = alloc<AsmStat>(count);
            var keys = _AsmIdCounts.Keys.Array();
            for(var i=0;i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var name = ref skip(keys,i);
                dst.AsmName = name;
                dst.Count = _AsmIdCounts[name];
            }
            return buffer.Sort();
        }
    }
}