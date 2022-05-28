//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static Markdown;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/check/rules")]
        void CheckRules()
        {
           CheckRuleNames();
           CheckInstDefs();
        }

        // void EmitRuleDeps()
        // {
        //     const string RenderPattern = "{0,-6} | {1,-6} | {2,-6} | {3,-3} | {4,-32} | {5,-32}";
        //     var headers = new string[]{"Seq", "Index", "Kind", "C", "Rule", "Field"};
        //     var dst = text.emitter();
        //     var usage = RuleTableDeps.fields(Xed.Views.CellTables);
        //     dst.AppendLineFormat(RenderPattern, headers);
        //     var j=z8;
        //     var rule = usage.First.Rule;
        //     for(var i=0; i<usage.Count; i++,j++)
        //     {
        //         ref readonly var u = ref usage[i];
        //         if(u.Rule != rule)
        //         {
        //             j=0;
        //             rule = u.Rule;
        //         }

        //         dst.AppendLineFormat(RenderPattern, i, j, u.TableKind, u.Consequent, u.RuleName, u.Field);
        //     }

        //     AppSvc.FileEmit(dst.Emit(), XedPaths.RuleTargets().Path("xed.rules.fields.deps", FileKind.Csv));
        // }

        void CheckInstDefs()
        {
            var a = "0x83 MOD[mm] MOD!=3 REG[0b010] RM[nnn] MODRM() SIMM8() LOCK=0";
            InstParser.parse(a, out var body);
            var dst = text.emitter();
            for(var i=0; i<body.CellCount; i++)
            {
                ref readonly var cell = ref body[i];
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(cell.Format());
            }
            Write(dst.Emit());
        }

        static void collect(in CellTable src, out HashSet<FieldKind> left, out HashSet<FieldKind> right)
        {
            ref readonly var rows = ref src.Rows;
            left = new();
            right = new();
            for(var i=0; i<rows.Count; i++)
            {
                ref readonly var row = ref rows[i];
                var antecedants = row.Antecedants();
                for(var j=0; j<antecedants.Length; j++)
                {
                    ref readonly var antecedant = ref skip(antecedants,j);
                    if(antecedant.Field != 0)
                        left.Include(antecedant.Field);
                }

                var consequents = row.Consequents();
                for(var j=0; j<consequents.Length; j++)
                {
                    ref readonly var consequent = ref skip(consequents,j);
                    if(consequent.Field != 0)
                        right.Include(consequent.Field);
                }
            }
        }

        SectionHeader header(RuleCaller target)
        {
            var rule = target.ToRule();
            return new(3,rule.Format());
        }

        void Emit(Index<NontermCall> calls)
        {
            var dst = text.buffer();
            var source = RuleCaller.Empty;
            for(var i=0; i<calls.Count; i++)
            {
                ref readonly var call = ref calls[i];
                if(source.IsEmpty)
                {
                    source = call.Source;
                    dst.AppendLine(header(source));
                    dst.AppendLine();
                }

                if(source != call.Source)
                {
                    dst.AppendLine();
                    source = call.Source;
                    dst.AppendLine(header(source));
                    dst.AppendLine();
                }

                dst.AppendLine(XedPaths.MarkdownLink(call.Target));
            }

            FileEmit(dst.Emit(), calls.Count, XedPaths.DbTarget("rules.tables.deps", FileKind.Md));
        }

        void CheckRuleNames()
        {
            const uint RuleCount = RuleNames.MaxCount;
            var src = Symbols.index<RuleName>();
            var names = src.Kinds;
            for(var i=0; i<names.Length; i++)
            {
                var name = names[i];
                if((ushort)name != i)
                    Errors.Throw(name);
            }
            Require.equal(RuleCount, (uint)names.Length);

            var dst = RuleNames.init(names);
            var buffer = alloc<RuleName>(RuleCount);
            var count = Require.equal(dst.Members(buffer), (uint)names.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(names,i);
                if(!dst.Contains(name))
                    Errors.Throw($"{name} is missing");
            }

            var smaller = slice(names,100,150);
            dst.Clear();
            dst.Include(smaller);
            for(var i=0; i<RuleNames.MaxCount; i++)
            {
                var min = skip(smaller,0);
                var max = skip(smaller,smaller.Length - 1);
                var kind = (RuleName)i;
                if(kind != 0)
                {
                    if(kind >= min & kind<= max)
                        Require.invariant(dst.Contains(kind));
                    else
                        Require.invariant(!dst.Contains(kind));
                }
            }
        }
    }
}