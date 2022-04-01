//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/fields")]
        Outcome CheckFields(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var tables = Xed.Rules.CalcTableSet();
            var path = XedPaths.Targets() + FS.file("xed.fields.sets", FS.Txt);
            var emitting = EmittingFile(path);
            var nonterms = alloc<OpAttrib>(12);
            var ntops = alloc<PatternOp>(12);
            using var writer = path.AsciWriter();
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var body = ref pattern.Body;
                ref readonly var ops = ref pattern.Ops;
                var fields = XedFields.set();
                for(var j=0; j<body.FieldCount; j++)
                    fields = fields.Include(body[j].FieldKind);

                var dst = text.buffer();
                var ocmap = string.Format("{0}{1}",XedModels.indicator(pattern.OpCode.Class),text.bracket(pattern.OpCode.Digits.PadLeft(4,'0')));
                dst.AppendFormat("{0,-12} {1,-16} | {2}", ocmap, pattern.OpCode.Value, pattern.Classifier);
                dst.AppendFormat("({0})", fields.Format());

                var ntcount = XedPatterns.where(ops, OpClass.Nonterminal, ntops);
                if(ntcount > 0)
                {
                    dst.Append(" -> ");
                    dst.Append('<');
                }

                for(var k=0; k<ntcount; k++)
                {
                    ref readonly var ntop = ref skip(ntops,k);

                    if(k >0)
                        dst.Append(Chars.Comma);

                    var ntacount = XedPatterns.where(ntop.Attribs, OpClass.Nonterminal, nonterms);
                    for(var j=0; j<ntacount; j++)
                    {
                        var nt = skip(nonterms,j).ToNonTerm();
                        var ntname = nt.Name;
                        dst.Append(nt.Format());
                    }
                }

                if(ntcount >0)
                    dst.Append('>');

                writer.AppendLine(dst.Emit());
            }

            EmittedFile(emitting,patterns.Count);
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