//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class XedDisasm
    {
        internal partial class DisasmParse
        {
            const string XDIS = "XDIS ";

            const string YDIS = "YDIS:";

            public static void parse(DisasmProps src, out DisasmState dst)
            {
                var parser = new FieldParser();
                dst = parser.Parse(src);
            }

            public static void parse(ReadOnlySpan<Facet<string>> src, out DisasmState dst)
            {
                var parser = new FieldParser();
                dst = parser.Parse(src);
            }

            public static Outcome parse(string src, out DisasmOpInfo dst)
            {
                dst = default;
                if(text.length(src) < 3)
                    return (false,RP.Empty);

                var result = Outcome.Success;
                var data = span(src);

                var idx = text.trim(text.left(src,2));
                result = DataParser.parse(idx, out dst.Index);
                if(result.Fail)
                    return (false,AppMsg.ParseFailure.Format(nameof(dst.Index), idx));

                var aspects = text.trim(text.right(src,2));
                var parts = text.split(aspects, Chars.FSlash);
                if(parts.Length != 6)
                    return (false, string.Format("Unexpected number of operand aspects in {0}", aspects));

                var i=0;
                result = XedParsers.parse(skip(parts,i++), out dst.Kind);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Kind), skip(parts,i-1)));

                result = DataParser.eparse(skip(parts,i++), out dst.Action);
                if(result.Fail)
                    return result;

                result = DataParser.eparse(skip(parts,i++), out dst.WidthCode);
                if(result.Fail)
                    return result;

                result = XedParsers.parse(skip(parts,i++), out dst.Visiblity);
                if(result.Fail)
                    return result;

                result = DataParser.eparse(skip(parts,i++), out dst.OpType);
                if(result.Fail)
                    return result;

                dst.Selector = text.trim(skip(parts,i++));
                return result;
            }

            public static Outcome parse(string src, out XDis dst)
            {
                var result = Outcome.Success;
                dst = default;
                if(!text.contains(src,XDIS))
                    return (false, $"'{XDIS}' marker not found");

                var i = text.index(src,Chars.Colon);
                var left = text.left(src,i);
                var right = text.trim(text.despace(text.right(src,i)));
                var parts = right.Split(Chars.Space);
                Demand.gt(parts.Length,3);
                result = XedParsers.parse(skip(parts,0), out dst.Category);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.Category), skip(parts,0)));

                if(result)
                    result = XedParsers.parse(skip(parts,1), out dst.Extension);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.Extension), skip(parts,1)));

                ref readonly var enc = ref skip(parts,2);
                var j = text.index(right, enc);
                if(j>0)
                    dst.Asm = text.trim(text.right(right, j + enc.Length));

                if(result)
                    result = parse(src, out dst.IP);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.IP), src));

                if(result)
                    result = parse(src, out dst.Encoded);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.Encoded), src));

                return result;
            }

            public static Outcome parse(string src, out MemoryAddress dst)
            {
                var result = Outcome.Failure;
                var i = text.index(src, XDIS);
                var j = XDIS.Length;
                var k = text.index(src, Chars.Colon);
                var length = k-j;
                dst = 0;
                if(j >= 0 && length > 0)
                    result = DataParser.parse(text.slice(src,j,length).Trim(), out dst);
                return result;
            }

            public static Outcome parse(string src, out AsmHexCode dst)
            {
                var result = Outcome.Failure;
                dst = AsmHexCode.Empty;
                var buffer = span<byte>(16);

                if(src.StartsWith(XDIS))
                {
                    var k = text.index(src, Chars.Colon);
                    if(k > 0)
                    {
                        var parts = text.words(text.right(src,k));
                        if(parts.Length >=3)
                        {
                            var count = HexParser.parse(parts[2], buffer);
                            if(count)
                            {
                                dst = slice(buffer,0,count).ToArray();
                                result = Outcome.Success;
                            }
                        }
                    }
                }

                return result;
            }

            public static Index<AsmExpr> expressions(ReadOnlySpan<DisasmLineBlock> src)
            {
                var dst = list<AsmExpr>();
                foreach(var block in src)
                {
                    foreach(var line in block.Lines)
                    {
                        var i = text.index(line.Content, YDIS);
                        if(i >= 0)
                            dst.Add(text.trim(text.right(line.Content, i + YDIS.Length)));
                    }
                }
                return dst.ToArray();
            }
        }
    }
}