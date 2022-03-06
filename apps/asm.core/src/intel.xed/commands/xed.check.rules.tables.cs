//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;

    using static core;
    using static XedRules;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static void AppendLineFormat(this StreamWriter dst, string pattern, params object[] args)
            => dst.WriteLine(string.Format(pattern,args));

        [MethodImpl(Inline)]
        public static void AppendFormat(this StreamWriter dst, string pattern, params object[] args)
            => dst.Write(string.Format(pattern,args));

        [MethodImpl(Inline)]
        public static void AppendLine(this StreamWriter dst)
            => dst.WriteLine();

        [MethodImpl(Inline)]
        public static void AppendLine(this StreamWriter dst, object src)
            => dst.WriteLine(src);

        [MethodImpl(Inline)]
        public static void Append(this StreamWriter dst, object src)
        {
            if(src != null)
                dst.Write(src);
        }
    }

    partial class XedCmdProvider
    {
        void EmitDetails(Index<InstDef> defs, FS.FilePath path)
        {
            const string LabelPattern = "{0,-16} | {1}";
            var parser = RuleOpParser.create();
            var result = Outcome.Success;
            var seq = 0u;
            var emitting = EmittingFile(path);
            using var dst = path.AsciWriter();
            for(var i=0; i<defs.Count; i++)
            {
                ref readonly var def = ref defs[i];
                var patterns = def.PatternSpecs;
                Xed.Rules.ExpandMacros(patterns);
                for(var j=0; j<patterns.Count; j++)
                {
                    ref readonly var pattern = ref patterns[j];
                    dst.AppendLineFormat(LabelPattern, "Pattern", seq++);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Class), def.Class);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Form), def.Form);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Category), def.Category);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Extension), def.Extension);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Flags), def.Flags.IsNonEmpty ? def.Flags.Delimit(fence:RenderFence.Embraced) : EmptyString);
                    dst.AppendLineFormat(LabelPattern, nameof(pattern.Expression), pattern.Expression);
                    dst.AppendLineFormat(LabelPattern, "Operands", RP.PageBreak80);
                    ref readonly var ops = ref pattern.Operands;
                    for(var k=0; k<ops.Count; k++)
                    {
                        ref readonly var op = ref ops[k];
                        dst.AppendFormat("{0,-16}", op.Name);
                        var spec = parser.ParseOp(op.Name, op.Expression);
                        var attribs = spec.Attributes;
                        dst.AppendFormat(" | {0,-32}", op.Expression);

                        for(var m=0; m<attribs.Count; m++)
                            dst.AppendFormat(" | {0,-16}", attribs[m]);

                        dst.AppendLine();
                    }
                    dst.AppendLine(RP.PageBreak100);
                }
            }
            EmittedFile(emitting,seq);
        }

        [CmdOp("xed/check/ops")]
        Outcome CheckOps(CmdArgs args)
        {
            const string LabelPattern = "{0,-16} | {1}";

            EmitDetails(Xed.Rules.CalcEncInstDefs(), AppDb.XedPath("xed.rules.enc.detail", FileKind.Txt));
            EmitDetails(Xed.Rules.CalcDecInstDefs(), AppDb.XedPath("xed.rules.dec.detail", FileKind.Txt));
            return true;
        }

        [CmdOp("xed/check/macros")]
        Outcome CheckMacros(CmdArgs args)
        {
            var macros = XedRules.macros().Storage.Map(x => (x.Name, x)).ToDictionary();
            var fields = RuleMachine.fields();
            var patterns = Xed.Rules.CalcPatterns(RuleSetKind.Enc);
            Xed.Rules.ExpandMacros(patterns);
            var buffer = text.buffer();
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var tokens = ref pattern.Tokens;
                buffer.AppendLine(text.delimit(tokens," | ", -24));

                // for(var j=0; j<tokens.Count; j++)
                // {
                //     ref readonly var token = ref tokens[j];
                //     if(token.Kind == RuleTokenKind.Macro)
                //     {
                //         var macro = token.AsMacro();
                //         Write(macro.Format());
                //     }
                // }
            }
            return true;
        }


        [CmdOp("xed/check/fields")]
        Outcome CheckFields(CmdArgs args)
        {
            var src = RuleMachine.specs();
            TableEmit(src.View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());
            return true;
        }

        [CmdOp("xed/check/rules/tables")]
        Outcome CheckRuleTables(CmdArgs args)
        {
            var encrules = Xed.Rules.CalcEncRuleTables();
            var encnames = RuleNames(encrules).ToHashSet();
            var calls = Calls(encrules);
            iter(calls, call => Write(call));
            var decrules = Xed.Rules.CalcDecRuleTables();
            var decnames = RuleNames(decrules);
            return true;
        }

        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var rules = Xed.Rules.ExpandMacros(Xed.Rules.CalcRuleSet(RuleSetKind.EncDec));
            void Traversed(string src)
            {
                Write(src);
            }
            var traverser = new RuleTraverserX(Traversed);
            traverser.Traverse(rules);
            var tables = traverser.Tables;
            var sigs = tables.Keys;
            var count = sigs.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                Write(string.Format("{0}()", sig.Name));
                var rows = tables[sig];
                for(var j=0; j<rows.Count; j++)
                {
                    ref readonly var row = ref rows[j];
                    Write(string.Format("    {0}", row.Format()));
                }

                Write(EmptyString);
            }

            return true;
        }

        [CmdOp("xed/check/seq")]
        Outcome CheckEncSeq(CmdArgs args)
        {
            XedRuleChecks.create(Wf).CheckRuleSeq();
            return true;
        }

        void ShowTableMacros(Index<RuleTable> tables)
        {
            var count = tables.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref tables[i];
                ref readonly var expressions = ref table.Expressions;
                for(var j=0; j<expressions.Count; j++)
                {
                    ref readonly var expr = ref expressions[j];
                    ref readonly var premise = ref expr.Premise;
                    ref readonly var consequent = ref expr.Consequent;
                    for(var k0 = 0; k0<premise.Count; k0++)
                    {
                        ref readonly var p = ref premise[k0];
                        if(p.Value.Contains("macro<"))
                        {
                            Write(string.Format("premise: {0}", p));
                        }
                    }

                    for(var k1 = 0; k1<consequent.Count; k1++)
                    {
                        ref readonly var c = ref consequent[k1];
                        if(c.Value.Contains("macro<"))
                        {
                            Write(string.Format("consequent: {0}", c));
                        }
                    }
                }
            }
        }

        Index<string> RuleNames(Index<RuleTable> src)
            => src.Select(x => x.Name.Format()).Where(nonempty).Distinct().Sort();

        Index<RuleCall> Calls(Index<RuleTable> src)
        {
            var count = src.Count;
            var dst = text.buffer();
            var buffer = list<RuleCall>();
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref src[i];
                ref readonly var name = ref table.Name;
                var sig = table.Sig;
                dst.AppendLine(sig);
                var expr = table.Expressions;
                if(Calls(table, out var calls))
                {
                    for(var j=0; j<calls.Count; j++)
                    {
                        var source = name;
                        var target = calls[j].Value;
                        var call = new RuleCall(source, target);
                        buffer.Add(call);
                    }
                }
            }

            return buffer.ToArray();
        }

        bool Calls(in RuleTable src, out Index<RuleCriterion> dst)
        {
            var expr = src.Expressions;
            var count = src.Expressions.Count;
            ref readonly var name = ref src.Name;
            var buffer = hashset<RuleCriterion>();
            dst = sys.empty<RuleCriterion>();
            for(var i=0; i<expr.Length; i++)
            {
                ref readonly var x = ref expr[i];
                ref readonly var c = ref x.Consequent;
                for(var j=0; j<c.Count; j++)
                {
                    ref readonly var rc = ref c[j];
                    if(rc.Operator == RuleOperator.Call)
                        buffer.Add(rc);
                }
            }
            if(buffer.Count != 0)
                dst = buffer.ToArray();

            return buffer.Count != 0;
        }
    }
}