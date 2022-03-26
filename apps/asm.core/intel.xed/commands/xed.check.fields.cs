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
            var patterns = Xed.Rules.CalcInstPatterns();
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var body = ref pattern.Body;
                ref readonly var ops = ref pattern.Ops;
                var fields = XedFields.set();
                for(var j=0; j<body.FieldCount; j++)
                {
                    fields = fields.Include(body[j].FieldKind);
                }

                var dst = text.buffer();
                dst.AppendFormat("{0,-20} {1,-16}", pattern.OpCode, pattern.InstClass);

                if(ops.NonTerminal(out var op))
                {
                    op.Attribs.Search(OpClass.Nonterminal, out var nt);
                    dst.AppendFormat(" -> {0} -> {1}", fields, nt.AsNonTerm());
                }
                else
                    dst.AppendFormat(" -> {0}", fields.Format());

                Write(dst.Emit());
            }
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