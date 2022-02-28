//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var result = Outcome.Success;
            result = Xed.Rules.LoadRulePatterns(out var patterns);
            if(result.Fail)
                return result;

            var reader = patterns.Reader();
            var maps = Symbols.index<OpCodeKind>();
            var counts = maps.Counts();
            while(reader.Next(out var pattern))
                counts.Inc(pattern.OpCodeKind);

            var total = counts.Total();
            Require.equal(total, patterns.Count);

            Write(counts.Format());

            CheckRuleDefs();

            var opcodes = Xed.Rules.ExtractOpCodes(patterns);

            return result;
        }

        void CheckRuleDefs()
        {
            var defs = Xed.Rules.ParseEncInstDefs();
            var dst = ProjectDb.Subdir("xed") + FS.file("xed.rules.encoding.operands", FS.Csv);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var count = defs.Count;
            var buffer = text.buffer();
            var counter = 0u;
            var ockinds = Symbols.index<OpCodeKind>();
            for(var i=0; i<count; i++)
            {
                ref readonly var def = ref defs[i];

                var ops = def.PatternSpecs;
                var patterns = Xed.Rules.ExtractRulePatterns(def);
                var k = ops.Count;
                Require.equal(patterns.Count, k);
                for(var j=0; j<k; j++)
                {
                    ref readonly var op = ref ops[j];
                    ref readonly var pattern = ref patterns[j];
                    var opcode = Xed.Rules.opcode(pattern);

                    ockinds.MapKind(opcode.Kind, out var sym);

                    writer.WriteLine(string.Format("{0,-6} | {1,-16} | {2,-12} | {3,-12} | {4,-8} | {5}", i, def.Class, sym.Expr, opcode.Value, EmptyString, op.PatternExpr));
                    counter++;

                    var specs = op.PatternOps;
                    var m = specs.Count;
                    for(var q=0; q<m; q++)
                    {
                        ref readonly var spec = ref specs[q];
                        writer.WriteLine(string.Format("{0,-6} | {1,-16} | {2,-12} | {3,-12} | {4,-8} | {5}", i, def.Class, q, spec.Name, spec.Kind, spec.Expression));
                        counter++;
                    }
                }
            }

            EmittedFile(emitting,counter);
        }
    }
}