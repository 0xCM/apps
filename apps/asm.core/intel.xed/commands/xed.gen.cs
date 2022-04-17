//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;

    partial class XedCmdProvider
    {

        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {
            //var docs = CalcDocs(Context());

            // var summaries = CalcSummaryDocs(context);
            // var details = CalcDetailBlocks(summaries);

            // EmitSummaries(context, summaries);
            // EmitDetails(context, details);

            // ref readonly var fields = ref XedFields.ByPosition;
            // var bits = fields[0,51];
            // var dst = BitVector64.Zero;
            // var set = FieldSet.create();
            // for(var i=z8; i<bits.Length; i++)
            // {
            //     ref readonly var field = ref skip(bits,i);
            //     Write(string.Format("{0,-8} | {1,-24} | {2}", field.Pos, field.Field, field.FieldSize));

            // }


            return true;
        }

    }
}