//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;
    using static Markdown;
    using static core;


    partial class AsmCoreCmd
    {
        [CmdOp("xed/emit/grids")]
        Outcome EmitGrids(CmdArgs args)
        {
            //XedDb.EmitGrids(CalcRuleCells());
            return true;
        }

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

        void CalcRuleDeps()
        {
            var src = CellTables;
            var count = src.Count;
            var left = alloc<HashSet<FieldKind>>(count);
            var right = alloc<HashSet<FieldKind>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref src[i];
                collect(table, out seek(left,i), out seek(right,i));
            }

            var dst = text.emitter();
            for(var i=0; i<count; i++)
            {
                var q=0;
                ref readonly var table =ref src[i];
                dst.AppendFormat("{0,-4} | {1,-32}", table.Kind, table.Name);
                ref readonly var fLeft = ref skip(left,i);
                foreach(var f in fLeft)
                {
                    if(q != 0)
                        dst.Append(Chars.Comma);
                    else
                        q = 1;

                    dst.Append(f.ToString());
                }

                ref readonly var fRight = ref skip(right,i);
                foreach(var f in fRight)
                {
                    if(q != 0)
                        dst.Append(Chars.Comma);
                    else
                        q = 1;

                    dst.Append(f.ToString());
                }

                dst.AppendLine();
            }

            Write(dst.Emit());

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

        [CmdOp("xed/check/rules/names")]
        Outcome CheckRuleNames(CmdArgs args)
        {
            const uint RuleCount = RuleNames.MaxCount;

            var src = Symbols.index<RuleName>();

            var names = src.Kinds;
            for(var i=0; i<names.Length; i++)
            {
                var name = names[i];
                if((ushort)name != i)
                {
                    return (false,$"{name}");
                }
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

            return true;
        }
    }
}