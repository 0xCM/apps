//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedPatterns;
    using static core;
    using Asm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/inst")]
        Outcome CheckInstDefs(CmdArgs args)
        {
            var specs = Xed.Rules.CalcRuleSpecs(RuleTableKind.Enc);
            var specLU = dict<string,RuleTableSpec>();
            iter(specs, spec => specLU.TryAdd(spec.Sig.Name, spec));
            var name = "MODRM_MOD_ENCODE";
            var xSpec = specLU[name];
            Write(xSpec.Format());
            var defs = XedRules.reify(specs);
            var defsLU = dict<string,RuleTable>();
            iter(defs, def => defsLU.TryAdd(def.Sig.Name, def));
            var def = defsLU[name];

            var table = text.buffer();
            var buffer = text.buffer();
            table.AppendLine(def.Sig.Format());
            table.AppendLine(Chars.LBrace);
            foreach(var statement in def.Body)
            {

                foreach(var c in statement.Premise)
                {
                    buffer.Append(XedRender.format(c));
                    buffer.Append(Chars.Space);
                }

                foreach(var c in statement.Consequent)
                {
                    if(c.IsCall)
                        buffer.Append(XedRender.format(c.AsCall()));
                    buffer.Append(Chars.Space);
                }
                table.IndentLine(4, buffer.Emit().TrimEnd());
            }
            table.AppendLine(Chars.RBrace);
            Write(table.Emit());
            return true;
        }
    }
}