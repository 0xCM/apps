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

            var path = AppDb.Log("rulecheck", FileKind.Csv);
            using var writer = path.Writer();
            var emitting = EmittingFile(path);
            var specs = Xed.Rules.CalcRuleSpecs(RuleTableKind.Enc);
            var counter = 0u;
            for(var i=0; i<specs.Count; i++)
            {
                ref readonly var spec = ref specs[i];

                var statements = spec.Statements;
                for(var j=0; j<statements.Count; j++)
                {

                    ref readonly var s = ref statements[j];


                    for(var q=0; q<s.Premise.Count; q++)
                    {
                        ref readonly var x = ref s.Premise[q];
                        writer.WriteLine(string.Format("{0,-32} | {1,-32} | {2}", spec.Sig, XedRender.format(x.Field), x));
                        counter++;
                    }

                    for(var q=0; q<s.Consequent.Count; q++)
                    {
                        ref readonly var x = ref s.Consequent[q];
                        writer.WriteLine(string.Format("{0,-32} | {1,-32} | {2}", spec.Sig, XedRender.format(x.Field), x));
                        counter++;
                    }
                }
            }
            // var defs = CalcMacroDefs();
            // var path = AppDb.XedPath("xed.rules.macros2",FileKind.Csv);
            //TableEmit(defs.View, MacroDef.RenderWidths, path);

            EmittedFile(emitting,counter);

            return true;
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