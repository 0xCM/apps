//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        void EmitEncPatternOps(ReadOnlySpan<InstDef> src)
            => EmitPatternOps(src, XedPaths.DocTarget(XedDocKind.OpEnc));

        void EmitDecPatternOps(ReadOnlySpan<InstDef> src)
            => EmitPatternOps(src, XedPaths.DocTarget(XedDocKind.OpDec));

        void EmitPatternOps(ReadOnlySpan<InstDef> defs, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var count = defs.Length;
            var buffer = text.buffer();
            var counter = 0u;
            var ockinds = Symbols.index<OpCodeKind>();
            for(var i=0; i<count; i++)
            {
                ref readonly var def = ref skip(defs,i);
                var ops = def.PatternSpecs;
                var patterns = CalcRulePatterns(def);
                var k = ops.Count;
                Require.equal(patterns.Count, k);
                for(var j=0; j<k; j++)
                {
                    ref readonly var op = ref ops[j];
                    ref readonly var pattern = ref patterns[j];
                    var oc = opcode(pattern);

                    ockinds.MapKind(oc.Kind, out var sym);
                    writer.WriteLine(string.Format("{0,-6} | {1,-16} | {2,-12} | {3,-12} | {4,-8} | {5}", i, def.Class, sym.Expr, oc.Value, EmptyString, op.PatternExpr));
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