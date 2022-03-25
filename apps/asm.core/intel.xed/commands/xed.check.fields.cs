//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/fields")]
        Outcome CheckFields(CmdArgs args)
        {
            var selected = XedFields.set(FieldKind.VEXDEST210, FieldKind.VEXDEST3, FieldKind.VEXDEST4);
            Write(selected.Format());
            return true;
        }

        void CheckFields(N0 n)
        {
            var tables = XedTables.Data;
            var lu = tables.FieldLookup;
            var matched = lu.Match(lu.LU(3), array(FieldKind.VEXDEST210, FieldKind.VEXDEST3, FieldKind.VEXDEST4));
            for(byte i=0; i<32; i++)
            {
                var match = matched[i];
                if(match != 0)
                    Write(match.ToString());
            }
        }
   }
}