//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/check/bits")]
        void CheckBitfields()
        {
            var bitfield = RuleBits.create();
            Write(bitfield.Dataset.Intervals.Format());

            var bits = bitfield.Bits(CellTables);
            for(var i=0; i<bits.Count; i++)
            {
                ref readonly var field = ref bits[i];
                Write(bitfield.Format(field));
            }
        }
    }
}