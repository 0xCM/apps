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
            exec(true,
                () => EmitStatements(RuleTableKind.Enc),
                () => EmitStatements(RuleTableKind.Dec),
                () => EmitStatements(RuleTableKind.EncDec)
            );
            return true;
        }

        void EmitStatements(RuleTableKind kind)
        {
            var src = RuleTableParser.describe(Xed.XedPaths.RuleSource(kind));
            var name = kind switch
            {
                RuleTableKind.Enc => "xed.rules.enc",
                RuleTableKind.Dec => "xed.rules.dec",
                RuleTableKind.EncDec => "xed.rules.encdec",
                _ => EmptyString
            };
            var dst = AppDb.XedPath("rules.tables", name, FileKind.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Length; i++)
                writer.WriteLine(src[i]);
            EmittedFile(emitting,src.Length);
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