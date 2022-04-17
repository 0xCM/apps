//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {
            ref readonly var fields = ref XedFields.ByPosition;
            var bits = fields[0,51];
            for(var i=0; i<bits.Length; i++)
            {
                ref readonly var b = ref skip(bits,i);
                Write(string.Format("{0,-8} | {1,-24} | {2}", b.Pos, b.Field, b.FieldSize));
            }


            return true;
        }

    }
}