//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    //public delegate int SizeCalcFx<T>();

    public readonly struct SizeCalc<T>
    {
        [MethodImpl(Inline)]
        public static int calc()
            => Unsafe.SizeOf<T>();
    }

    public readonly struct SizeCalc
    {
        public static ByteSize size(Type src)
        {
            var type = typeof(SizeCalc<>).MakeGenericType(src);
            var method = first(type.StaticMethods().Public());
            return (int)method.Invoke(null, sys.empty<object>());
        }

        public static BitWidth width(Type src)
            => size(src);

        public static ByteSize size<T>()
            => size(typeof(T));

        public static BitWidth width<T>()
            => size<T>();

    }

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var rules = CalcRules();
            var lookup = CellParser.cells(rules);
            var tables = lookup.Tables;

            var @base = 'a' - 3;
            var top = text.emitter();
            top.Append("new byte[32]");
            top.Append(Chars.LBrace);
            top.Append($"{0}");
            top.Append(Chars.Comma);

            top.Append(Chars.Space);
            top.Append($"{1}");
            top.Append(Chars.Comma);

            top.Append(Chars.Space);
            top.Append($"{2}");
            top.Append(Chars.Comma);

            for(char i='a'; i<= 'z'; i++)
            {
                var c = i - @base;
                top.Append(Chars.Space);
                top.Append($"{(byte)c}");
                top.Append(Chars.Comma);
                //Write($"{(byte)c} = '{i}' = {(byte)i}");
            }
            top.Append(Chars.Space);
            top.Append("29");
            top.Append(Chars.Comma);

            top.Append(Chars.Space);
            top.Append("30");
            top.Append(Chars.Comma);

            top.Append(Chars.Space);
            top.Append("31");
            top.Append(Chars.Comma);

            top.Append(Chars.RBrace);


            var left = text.emitter();
            left.Append("new byte[32]");
            left.Append(Chars.LBrace);

            left.Append((byte)'0');
            left.Append(Chars.Comma);

            left.Append(Chars.Space);
            left.Append((byte)Chars.Underscore);
            left.Append(Chars.Comma);

            left.Append(Chars.Space);
            left.Append((byte)'0');
            left.Append(Chars.Comma);

            for(char i='a'; i<= 'z'; i++)
            {
                left.Append(Chars.Space);
                left.Append((byte)i);
                left.Append(Chars.Comma);
            }
            left.Append(Chars.Space);
            left.Append("0");
            left.Append(Chars.Comma);

            left.Append(Chars.Space);
            left.Append("0");
            left.Append(Chars.Comma);

            left.Append(Chars.Space);
            left.Append("0");
            left.Append(Chars.Comma);

            left.Append(Chars.RBrace);


            var right = text.emitter();
            right.Append("new char[32]");
            right.Append(Chars.LBrace);

            right.Append("'0'");
            right.Append(Chars.Comma);

            right.Append(Chars.Space);
            right.Append("'_'");
            right.Append(Chars.Comma);

            right.Append(Chars.Space);
            right.Append("'0'");
            right.Append(Chars.Comma);

            for(char i='a'; i<= 'z'; i++)
            {
                right.Append(Chars.Space);
                right.Append($"'{i}'");
                right.Append(Chars.Comma);
            }

            right.Append(Chars.Space);
            right.Append("'0'");
            right.Append(Chars.Comma);

            right.Append(Chars.Space);
            right.Append("'0'");
            right.Append(Chars.Comma);

            right.Append(Chars.Space);
            right.Append("'0'");
            right.Append(Chars.Comma);

            right.Append(Chars.RBrace);

            Write(top.Emit());
            Write(left.Emit());
            Write(right.Emit());

            // var size = SizeCalc.width<CellKey>();
            // Write(size.ToString());

            // var dst = text.emitter();
            // var count = CellRender.render(lookup,dst);
            // var data = Require.equal(dst.Emit(), lookup.Description);
            // FileEmit(data, count, XedPaths.RuleTarget("cells.raw", FS.Csv), TextEncodingKind.Asci);

            // var sigs = lookup.Keys;
            // var tables = sigs.ToArray().Map(x => lookup.Table(x)).Index().Sort();
            // for(var i=0; i<tables.Count; i++)
            // {
            //     ref readonly var table = ref tables[i];
            //     Write(table.Sig.Format());
            // }


            return true;
        }


        void LoadRuleBlocks()
        {
            var known = Symbols.kinds<RuleName>().Where(x => x != 0).ToArray().Map(x => x.ToString()).ToHashSet();
            var found = hashset<string>();
            var dst = text.emitter();
            var encBlocks = TableCalcs.blocks(RuleTableKind.ENC);
            var decBlocks  = TableCalcs.blocks(RuleTableKind.DEC);
            var blocks = (encBlocks + decBlocks).Sort();
            var count = blocks.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                var seq = string.Format("{0:D3}",i);
                var offset = string.Format("{0:D5}", block.Offset);
                found.Add(block.TableName);
                dst.AppendLine($"{seq} {block.TableKind} {string.Format(RP.slot(0,-32),block.TableName)} | {offset}");
            }

            FileEmit(dst.Emit(), count, XedPaths.RuleTarget("names", FS.Csv));

            foreach(var f in found)
            {
                if(!known.Contains(f))
                    Write($"Not known: {f}");
            }

        }
        void CheckNonTerms()
        {
            var patterns = CalcPatterns();
            var count = patterns.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var fields = ref pattern.Fields;
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    if(op.Nonterminal(out var nt))
                    {
                        Require.invariant(nt.IsNonEmpty);
                        GprWidth.widths(nt, out var widths);
                        Write(string.Format("{0,-18} | {1}={2,-24} | {3}", pattern.InstClass, op.Name, nt, widths), FlairKind.StatusData);
                    }

                }
            }
        }

        void CheckGprWidths()
        {
            var ntk = RuleName.GPR8_R;
            var result = GprWidth.widths(ntk, out var widths);
            Write(widths.Format());
        }

        bool Match(Index<string> a, Index<string> b)
        {
            var result = true;
            var count = a.Count;
            result = (count == b.Count);
            if(result)
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var x = ref a[i];
                    ref readonly var y = ref b[i];
                    result = x == y;
                    if(!result)
                        break;
                }
            }

            return result;
        }
    }
}