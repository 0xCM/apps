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
        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var src = RuleTableParser.specs(Xed.XedPaths.RuleSource(RuleTableKind.Dec));
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var desc = ref src[i];
                if(desc.Sig.Name == "A_GPR_B")
                {
                    Write(desc.Format());

                    var buffer = text.buffer();
                    buffer.AppendLine(string.Format("{0}()", desc.Sig.Name));
                    buffer.AppendLine(Chars.LBrace);
                    var sbuffer = text.buffer();
                    for(var j=0; j<desc.Statements.Count; j++)
                    {
                        var statement = RuleTableParser.reify(desc.Statements[j]);
                        for(var k=0; k<statement.Premise.Count; k++)
                        {
                            ref readonly var x = ref statement.Premise[k];
                            sbuffer.AppendFormat("{0}{1}{2}", XedRender.format(x.Field), XedRender.format(x.Operator), x.Data);
                        }

                        sbuffer.Append(" => ");

                        for(var k=0; k<statement.Consequent.Count; k++)
                        {
                            ref readonly var x = ref statement.Consequent[k];
                            sbuffer.AppendFormat("{0}{1}{2}", XedRender.format(x.Field), XedRender.format(x.Operator), x.AsNonterminal());
                        }

                        buffer.IndentLine(4, sbuffer.Emit());
                    }
                    buffer.AppendLine(Chars.RBrace);
                    Write(buffer.Emit());

                    break;
                }
            }

            return true;
        }

        void CheckRules2()
        {
            var tables = Xed.RuleTables.CalcTableDefs(RuleTableKind.Enc);
            var sigs = tables.Keys;
            var lookup = dict<RuleSig,Index<RuleCellSpec>>();
            for(var i=0; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                var table = tables[sig];
                var rows = Xed.RuleTables.CalcTableRows(table);
                var count = rows.Count;
                var pFields = hashset<RuleCellSpec>();
                var cFields = hashset<RuleCellSpec>();
                for(var j=0; j<count; j++)
                {
                    ref readonly var row = ref rows[j];
                    row.FieldSpecs('P', pFields);
                    row.FieldSpecs('C', cFields);
                }

                var fields = list<RuleCellSpec>();
                fields.AddRange(pFields);
                fields.AddRange(cFields);
                lookup[sig] = fields.ToArray().Sort();
            }

            var _sigs = lookup.Keys.Array().Sort();
            var path = AppDb.XedPath("xed.rules.cells.enc", FileKind.Csv);
            using var writer = path.AsciWriter();

            const string RenderPattern = "{0,-32} | {1,-8} | {2,-8} | {3,-24} | {4}";
            writer.AppendLineFormat(RenderPattern, "Name", "Kind", "Index", "Field", "DataKind");

            foreach(var sig in _sigs)
            {
                var specs = lookup[sig];
                var k=z8;
                foreach(var spec in specs)
                {
                    Require.nonzero(spec.DataKind);
                    writer.AppendLineFormat(RenderPattern,
                        sig.Name,
                        spec.Premise ? 'P' : 'C',
                        k++,
                        XedRender.format(spec.Field),
                        XedRender.format(spec.DataKind)
                    );
                }
            }



        }
    }

    partial class XTend
    {
        public static uint AddRange<T>(this HashSet<T> dst, ReadOnlySpan<T> src)
        {
            var counter = 0u;
            foreach(var item in src)
                if(dst.Add(item))
                    counter++;
            return counter;
        }

        public static uint AddRange<T>(this HashSet<T> dst, params T[] src)
            => dst.AddRange(@readonly(src));
    }
}