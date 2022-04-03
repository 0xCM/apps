//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedPatterns;
    using static XedDocs;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/docs")]
        Outcome EmitDocs(CmdArgs args)
        {
            XedDocs.EmitDocs(Xed.Rules.CalcRules(),Xed.Rules.CalcInstPatterns());
            return true;
        }

        [CmdOp("xed/check/ops")]
        Outcome CheckOps(CmdArgs args)
        {
            var src = Xed.Rules.CalcOpNames();
            for(var i=0; i<src.Length; i++)
            {
                Write(string.Format("{0,-2} | {1,-6} | {2}",  (byte)src[i].Kind, src[i], src[i].Indicator));
            }
            return true;
        }


        void CheckFields(N0 n)
        {
            var tables = XedLookups.Data;
            var lu = tables.Fields;
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